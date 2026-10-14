using UnityEngine;

public class objectSpawner_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject objects;
    public float spawnRate = 2f;
    private float timer = 0f;
    public float heightOffset = 10f;

    void Start()
    {
        SpawnObjects(); 
    }

    private void SpawnObjects()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        float randomY = UnityEngine.Random.Range(lowestPoint, highestPoint);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);

        Instantiate(objects, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnObjects();
            timer = 0;
        }
    }
}
