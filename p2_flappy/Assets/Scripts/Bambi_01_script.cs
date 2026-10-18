using UnityEngine;

public class Bambi_01_script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D my_Bambi01_Rigidbody;
    public float flapStrenght = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            my_Bambi01_Rigidbody.linearVelocity = Vector2.up * flapStrenght;

        }
    }
}
