using UnityEngine;

public class snowManCreepy : MonoBehaviour
{
    public Transform player;
    public float teleportDistance = 8f;
    public float checkInterval = 0.2f;

    private float timer;
    
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = checkInterval;
            if (IsBeingLookedAt())
            {
               TeleportBehindPlayer();
            }
        }
    }

    bool IsBeingLookedAt()
    {
        Vector3 toSnowman = (transform.position - player.position).normalized;
        float dot = Vector3.Dot(player.forward, toSnowman);
        return dot > 0.8f;

        
    }
     void TeleportBehindPlayer()
        {
            //Stays behind the player from an specific distance 
            Vector3 behind = player.position - player.forward * teleportDistance;
            transform.position = behind;
        }

}

