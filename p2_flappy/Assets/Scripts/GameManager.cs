using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Player player;
    [SerializeField] private Spawner spawner;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;

    //limits to be Game Over
    public float fallLimit = -6f;
    public float pushBackLimit = -40f;

    public int score { get; private set; } = 0;

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
    }

    private void Update()
    {
        //Pause
        if (Time.timeScale == 0f) return;

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
        if (player.transform.position.y < fallLimit)
        {
            OnBambiFell("Bambi fell of the kitchen");
        }
        else if (player.transform.position.x < pushBackLimit)
        {
            OnBambiFell("Bambi was pushed out of the kitchen");
        }
    }

    private void OnBambiFell(string reason)
    {
        Debug.Log("GAME OVER: " + reason);
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
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Obstacles[] obstacles = FindObjectsByType<Obstacles>(FindObjectsSortMode.None);

        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i].gameObject);
        }
    }

    public void GameOver()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
 
}
