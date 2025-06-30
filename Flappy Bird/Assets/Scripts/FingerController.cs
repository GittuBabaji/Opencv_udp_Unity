using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class FingerControlListener : MonoBehaviour
{
    [SerializeField] private Player player; 

    private UdpClient client;
    private Thread receiveThread;

    private bool jumpRequested = false;
    private object lockObj = new object();

    void Start()
    {
        Debug.Log(" FingerControlListener is ACTIVE");

        client = new UdpClient(5055);
        receiveThread = new Thread(ReceiveData);
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    void Update()
    {
        lock (lockObj)
        {
            if (jumpRequested)
            {
                player.Jump();
                jumpRequested = false;
            }
        }
    }

    void ReceiveData()
    {
        IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
        while (true)
        {
            try
            {
                byte[] data = client.Receive(ref anyIP);
                string message = Encoding.UTF8.GetString(data);
                Debug.Log("Received: " + message);

                if (message == "JUMP")
                {
                    lock (lockObj)
                    {
                        jumpRequested = true;
                    }
                }
            }
            catch (System.Exception err)
            {
                Debug.LogError("UDP Receive error: " + err.Message);
            }
        }
    }

    private void OnApplicationQuit()
    {
        receiveThread?.Abort();
        client?.Close();
    }
}
