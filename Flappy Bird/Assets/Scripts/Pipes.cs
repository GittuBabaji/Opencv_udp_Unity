using UnityEngine;

public class Pipes : MonoBehaviour
{
    [SerializeField] protected float Speed = 5f;
    [SerializeField] protected float LeftEdge;

    private void Start()
    {
        LeftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 3f;
    }

    private void Update()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;
        if (transform.position.x < LeftEdge)
        {
            Destroy(gameObject);
        }
    }
}
