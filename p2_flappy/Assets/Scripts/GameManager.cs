using UnityEngine;
using UnityEngine.UI;
using TMPro;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Player player;
    [SerializeField] private Spawner spawner;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text reasonText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;

    //limits to be Game Over
    public float fallLimit = -6f;
    public float pushBackLimit = -30f;
    public float riseLimit = 7f;

    public int score { get; private set; } = 0;

    private bool gameStarted = false;

    private void Awake()
    {
        if (Instance != null) {
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }

    private void Start()
    {
        Pause();
        gameOver.SetActive(false);
        playButton.SetActive(true);
        player.gameObject.SetActive(false);
    }

    

    private void Update()
    {
        //Pause
        if (Time.timeScale == 0f) return;
        if (!gameStarted) return;

        CheckDeath();
        CheckScore();

    }

    //Scoring
    private void CheckScore()
    {
        float playerX = player.transform.position.x;

        GameObject[] tops = GameObject.FindGameObjectsWithTag("ObsTop");
        foreach (GameObject top in tops)
        {
            if (top.transform.position.x < playerX)
            {
                ScoreMarker marker = top.GetComponent<ScoreMarker>();
                if (marker == null)
                {
                    top.AddComponent<ScoreMarker>();
                    IncreaseScore();
                }

            }
        }


    }

    //Game Over
    private void CheckDeath()
    {
        if (player.transform.position.y > riseLimit)
        {
            OnPlayerFell("Bambi flew out of the kitchen");
        }
        else if (player.transform.position.y < fallLimit)
        {
            OnPlayerFell("Bambi fell of the kitchen");
        }
        else if (player.transform.position.x < pushBackLimit)
        {
            OnPlayerFell("Bambi was pushed out of the kitchen");
        }
    }

    private void OnPlayerFell(string reason)
    {
        Debug.Log("GAME OVER: " + reason);
        reasonText.text = reason;
        GameOver();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void Play()
    {
        score = 0;
        gameStarted = true;
        scoreText.text = score.ToString();
        reasonText.text = "";

        //Reset Player (and game)
        player.gameObject.SetActive(true);
        player.transform.position = new Vector3(0f, 0f, 0f);
        player.my_Player_Rigidbody.linearVelocity = Vector2.zero;

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        GapObstacle_Script[] obstacles = FindObjectsByType<GapObstacle_Script>(FindObjectsSortMode.None);

        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i].gameObject);
        }
    }

    public void GameOver()
    {
        gameStarted = false;
        gameOver.SetActive(true);

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
 
}
