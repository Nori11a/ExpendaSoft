using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Done_GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
	public Text coinText;
	public Text lifeText;

    private bool gameOver;
    private bool restart;
    private static int score = 0;
	public static int coin = 0;
	public static int lives = 3;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
		lifeText.text = "";

        UpdateScore();
		UpdateCoin();

		UpdateLives();

        StartCoroutine(SpawnWaves());
    }

    void Update()
    {

		if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
				lives--;
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                //GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                //Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

	public void AddCoin(int newCoinCount)
	{
		coin += newCoinCount;
		UpdateCoin();
	}

	void UpdateCoin()
	{
		coinText.text = "Coins: " + coin;
	}

	public void AddLives(int UP)
	{
		lives += UP;
		UpdateLives();
	}

	void UpdateLives()
	{
		if(lives < 10)
		{
			lifeText.text = "0" + lives;
		}
		else
		{
			lifeText.text = "" + lives;
		}
	}

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;

		while(gameOver == true)
		{
			restartText.text = "Press 'R' for Restart";
			restart = true;
			break;
		}
    }
}