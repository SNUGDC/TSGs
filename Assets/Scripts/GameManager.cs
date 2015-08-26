using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	private bool ballExistence;
	private bool ballGenerationStarted;
	private bool readyToFire;
	private int startingIndex;
	private float timeLeft;
	private float maxTime;
	private GameObject timeBar;
	private GameObject ballInstance;
    private bool isGameOver;
    private bool isGameClear;
    private GameObject[] bricks;
    private GameObject[] enemies;
	public GameObject ball;
	public Transform[] startingPosition;
    public GameObject gameOverImage;
    public GameObject gameClearImage;
	public int level;

	void Start () 
    {
		ballExistence = false;
		ballGenerationStarted = false;
		readyToFire = false;
        isGameOver = false;
        isGameClear = false;
		timeLeft = maxTime = 30;
		timeBar = GameObject.Find("TimeBar");
        bricks = GameObject.FindGameObjectsWithTag("Brick");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
	}

	void Update () 
    {
        if (!IsGameEnded())
        {
            if (!ballExistence && !ballGenerationStarted)
            {
                StartCoroutine("BallGenerationStart");
            }
            SetBall();
            FireBall();
            CheckBall();
            TimeLapse();
            PrintGameOver();
        }
        else
        {	
			UnlockStage();
            PrintGameClear();
        }
	}
	
	IEnumerator BallGenerationStart()
	{
		ballGenerationStarted = true;
		yield return new WaitForSeconds(3.0f);
		BallGeneration();
		ballGenerationStarted = false;
	}
	
	void BallGeneration()
	{
        if (!(isGameOver || isGameClear))
        {
            GameObject instance = ball;
            instance.transform.position = startingPosition[startingIndex = Random.Range(0, startingPosition.Length)].position;
            ballInstance = Instantiate(instance) as GameObject;
            ballExistence = true;
            readyToFire = true;
        }
	}
	
	void SetBall()
	{
		if(readyToFire)
		{
			ballInstance.transform.position = startingPosition[startingIndex].position;
		}
	}
	
	void FireBall()
	{
		if(Input.GetMouseButton(1) && readyToFire)
		{
			Vector2 velocity = ballInstance.transform.position - startingPosition[startingIndex].parent.transform.position;
			ballInstance.GetComponent<Rigidbody2D>().velocity = velocity;
			readyToFire = false;
		}
	}
	
	void CheckBall()
	{
		if (ballInstance == null)
		{
			ballExistence = false;
		}
	}
	
	void TimeLapse()
	{
		if (timeLeft > 0)
		{
			timeLeft -= Time.deltaTime;
			timeBar.GetComponent<Slider>().value = timeLeft / maxTime;
		}
	}

	public void TransferToStart()
	{
		Application.LoadLevel ("Start");
	}

    void PrintGameOver()
    {
        if (timeLeft < 0)
        {
            gameOverImage.SetActive(true);
            isGameOver = true;
            if (ballExistence == true)
            {
                Destroy(GameObject.FindWithTag("Ball"));
            }
        }
    }

    void PrintGameClear()
    {
        if (isGameClear)
        {
            gameClearImage.SetActive(true);
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void CheckGameClear()
    {
        bool brickClear = true, enemyClear = true;
        for (int i = 0; i < bricks.Length; i++)
        {
            if (bricks[i].activeSelf)
            {
                brickClear = false;
                break;
            }
        }
        
        if (brickClear)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].activeSelf)
                {
                    enemyClear = false;
                    break;
                }
            }
        }

        if (brickClear && enemyClear)
        {
            isGameClear = true;
        }
    }

	public void UnlockStage()
	{
		int nextlevel = level + 1;
		if (isGameClear) 
		{
			PlayerPrefs.SetInt("Level" + nextlevel, 1);
		}
	}

    public bool IsGameClear()
    {
        return isGameClear;
    }

    public bool IsGameEnded()
    {
        return isGameClear || isGameOver;
    }
}