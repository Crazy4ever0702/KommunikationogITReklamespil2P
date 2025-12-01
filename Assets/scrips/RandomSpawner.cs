using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;

    public float leftX = -8f;
    public float rightX = 8f;
    public float spawnY = 6f;
    public float spawnInterval = 1.5f;

    private float timer;
    public float chancePrefab1 = 75f;  // 70%
    public float chancePrefab2 = 30f;  // 30%

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            Spawn();
        }
    }

    void Spawn()
    {
        float x = Random.Range(leftX, rightX);
        Vector3 pos = new Vector3(x, spawnY, 0f);

        float roll = Random.value * 100f;

        GameObject prefabToUse;

        if (roll < chancePrefab1)
            prefabToUse = prefab1;
        else
            prefabToUse = prefab2;
        Instantiate(prefabToUse, pos, Quaternion.identity);
        
        // For debugging:
        Debug.Log("Spawned: " + prefabToUse.name + " at " + pos);
    }
}