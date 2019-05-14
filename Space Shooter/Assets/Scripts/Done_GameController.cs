using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

namespace CompleteProject
{

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

		public Text gearText;

	    private bool gameOver;
	    private bool restart;
	    private static int score = 0;
		public static int coin = 0;
		public static int lives = 3;

		private string gear = "Fast";

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
	            if (Input.GetKeyDown(KeyCode.R) && lives > 0)
	            {
					lives--;
					SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	            }
				if(Input.GetKeyDown(KeyCode.Q))
				{
					AddScore(score * -1);


					lives = 3;
					Done_PlayerController.fireRate = 1.75f;
					Done_PlayerController.power = 0;
					Done_PlayerController.speed = 4;
					Done_PlayerController.reflector = 0;
					Done_PlayerController.node = 0;

					Application.LoadLevel(0);

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

		public void SetGear(float mode)
		{
			/*switch(mode);
			{
				case 0.5f:
				gear = "Slow";
				break;

				case 1f:
				gear = "Fast";
				break;
			}*/

			if(mode == 1f)
			{
				gear = "Fast";
			}
			else if(mode == 0.5f)
			{
				gear = "Slow";
			}

			UpdateGear();
		}

		void UpdateGear()
		{

			gearText.text = gear;

		}

	    public void GameOver()
	    {
	        gameOverText.text = "Game Over!";
	        gameOver = true;

			while(gameOver == true)
			{
				if(lives > 0)
				{
					restartText.text = "Press 'R' for Restart or 'Q' to Quit";
				}
				else
				{
					restartText.text = "Press 'Q' to Quit";
				}

				restart = true;
				break;
			}
	    }
	}

}