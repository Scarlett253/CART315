using UnityEngine;

public class Obstacles_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //speed
    public float moveSpeed = 10f;
    //limit
    public float deadZone = -30f;
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Bye Bye
        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
