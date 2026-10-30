//using UnityEngine;
//Script for creepy showing
//public class snowManCreepy : MonoBehaviour
//{
//    public Transform player;
//    public float teleportDistance = 8f;
//    public float checkInterval = 0.2f;

//    private float timer;

//    void Update()
//    {
//        timer -= Time.deltaTime;
//        if (timer <= 0f)
//        {
//            timer = checkInterval;
//            if (IsBeingLookedAt())
//            {
//               TeleportBehindPlayer();
//            }
//        }
//    }

//    bool IsBeingLookedAt()
//    {
//        Vector3 toSnowman = (transform.position - player.position).normalized;
//        float dot = Vector3.Dot(player.forward, toSnowman);
//        return dot > 0.8f;


//    }
//     void TeleportBehindPlayer()
//        {
//            //Stays behind the player from an specific distance 
//            Vector3 behind = player.position - player.forward * teleportDistance;
//            transform.position = behind;
//        }

//}

//New Script For the Snowman To Follow The Player

using UnityEngine;

public class snowManCreepy : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 8f;
    public float checkInterval = 0.2f;

    private float timer;

    void Update()
    {

        //the snowman chase you if u r not looking at him

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = checkInterval;

            
            if (!IsBeingLookedAt())
            {
                ChasePlayer();
            }
        }
    }

    bool IsBeingLookedAt()
    {
        Vector3 toSnowman = (transform.position - player.position).normalized;
        float dot = Vector3.Dot(player.forward, toSnowman);
        return dot > 0.8f;
    }

    void ChasePlayer()
    {
        //turns towards the player
        Vector3 lookDir = player.position - transform.position;
        lookDir.x = 0;
        transform.rotation = Quaternion.LookRotation(lookDir);

        //go towards player
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * chaseSpeed * Time.deltaTime;
    }
}

