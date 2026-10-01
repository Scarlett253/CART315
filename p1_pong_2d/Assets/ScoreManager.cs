using UnityEngine;
using TMPro;

public class scoreManager : MonoBehaviour
{

    public TMP_Text scoreP1Text;
    public TMP_Text scoreP2Text;

    public GameObject ball;

    int scoreP1 = 0;
    int scoreP2 = 0;


    void ResetBall()
    {
        ball.transform.position = Vector2.zero;
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;

        float xDirection = Random.value < 0.5 ? -1f : 1f;
        float yDirection = Random.Range(-0.75f, 0.75f);
        Vector2 direction = new Vector2(xDirection, yDirection).normalized;
        rb.linearVelocity = direction * 5f;
    }


    public void Player1Scored()
    {
        scoreP1 += 15;
        scoreP1Text.text = scoreP1.ToString();
        ResetBall();
    }

    public void Player2Scored()
    {
        scoreP2 += 15;
        scoreP2Text.text = scoreP2.ToString();
        ResetBall();
    }



}
