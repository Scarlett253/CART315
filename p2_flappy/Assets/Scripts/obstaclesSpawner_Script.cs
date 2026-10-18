using UnityEngine;

public class obstaclesSpawner_Script : MonoBehaviour
{
    //make the obstacles appear
    public float spawnRate = 2f;

    //limits
    public float minY = -3f;
    public float maxY = 3f;

    //Prefabs open/close
    public GameObject topObstacle;
    public GameObject bottomObstacle;

    //lapses between spawns
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        SpawnObstacles(); 
    }

    private void SpawnObstacles()
    {
       
        float randomY = Random.Range(minY, maxY);
        float phase = Random.Range(0f, Mathf.PI * 2f);

        Vector3 topPos = new Vector3(transform.position.x, randomY + 1.5f, transform.position.z);
        Vector3 bottomPos = new Vector3(transform.position.x, randomY - 1.5f, transform.position.z);

        GameObject top = Instantiate(topObstacle, topPos, transform.rotation);
        GameObject bottom = Instantiate(bottomObstacle, bottomPos, transform.rotation);

        top.GetComponent<GapObstacle_Script>().Setup(randomY, phase);
        bottom.GetComponent<GapObstacle_Script>().Setup(randomY, phase);

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
