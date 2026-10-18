using UnityEngine;

public class GapObstacle_Script : MonoBehaviour
{
    //speed
    public float moveSpeed = 10f;

    //limits
    public float deadZone = -40f;


    [Header("OpenClose")]
    public bool isTop = true;
    public float gapSize = 5f;
    public float minGap = 2f;

    //speed of the movement
    public float openCloseSpeed = 2f;

    private float centerY;
    private float phase;

    public void Setup(float center, float startPhase)
    {
        centerY = center;
        phase = startPhase;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (centerY == 0f) centerY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //move to the left
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        //open and close settings
        float gap = Mathf.Lerp(minGap, gapSize, (Mathf.Sin(Time.time * openCloseSpeed + phase) + 1f) / 2f);
        float targetY = isTop ? centerY + gap / 2f : centerY - gap / 2f;

        Vector3 pos = transform.position;
        pos.y = Mathf.MoveTowards(pos.y, targetY, openCloseSpeed * moveSpeed * Time.deltaTime);
        transform.position = pos;

        //deadZone
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }

    }
}
