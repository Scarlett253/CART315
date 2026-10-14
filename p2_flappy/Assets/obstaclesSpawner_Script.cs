using UnityEngine;

public class objectSpawner_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject objects;
    public float spawnRate = 2f;
    private float timer = 0f;

    void Start()
    {
        SpawnObjects(); 
    }

    private void SpawnObjects()
    {
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
