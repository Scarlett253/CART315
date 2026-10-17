using UnityEngine;

public class obstaclesSpawner_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject obstacles;
    public float spawnRate = 2f;
    public float minY = -3f;
    public float maxY = 3f;
    private float timer = 0f;
    //public float heightOffset = 5f;

    void Start()
    {
        SpawnObstacles(); 
    }

    private void SpawnObstacles()
    {
        //float lowestPoint = transform.position.y - heightOffset;
        //float highestPoint = transform.position.y + heightOffset;
        //float randomY = UnityEngine.Random.Range(lowestPoint, highestPoint);
        //Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);

        //Instantiate(obstacles, spawnPosition, transform.rotation);

        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);

        Instantiate(obstacles, spawnPosition, transform.rotation);
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
            SpawnObstacles();
            timer = 0;
        }
    }
}
