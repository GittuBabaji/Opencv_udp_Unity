using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject prefab;
    [SerializeField] protected float minhieght = -3f;
    [SerializeField] protected float spawnrate = 1f;
    [SerializeField] protected float maxhieght = 3f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnrate, spawnrate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject go = Instantiate(prefab, transform.position, Quaternion.identity);
        float y = Random.Range(minhieght, maxhieght);
        go.transform.position += Vector3.up * y;
    }
}
