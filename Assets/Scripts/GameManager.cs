using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	private bool ballExistence;
	private bool ballGenerationStarted;
	private int startingIndex;
	private float timeLeft;
	private float maxTime;
	private GameObject timeBar;
	private GameObject ballInstance;
    private bool isGameOver;
    private bool isGameClear;
    private bool isGameStarted;
    private GameObject[] bricks;
    private GameObject[] enemies;
    private Camera mainCamera;
	public GameObject ball;
	public Sprite fireball;
	public Transform[] startingPosition;
    public GameObject gameOverImage;
    public GameObject gameClearImage;
	public int level;
    public bool readyToFire;

	void Start () 
    {
		ballExistence = false;
		ballGenerationStarted = false;
		readyToFire = false;
        isGameOver = false;
        isGameClear = false;
        isGameStarted = false;
		timeLeft = maxTime = 90;
		timeBar = GameObject.Find("TimeBar");
        bricks = GameObject.FindGameObjectsWithTag("Brick");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
	}

	void Update () 
    {
        if (IsGameOnGoing())
        {
            TimeLapse();
        }
        if (!IsGameEnded())
        {
            if (!ballExistence && !ballGenerationStarted)
            {
                StartCoroutine("BallGenerationStart");
            }
            SetBall();
            FireBall();
            CheckBall();
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
        if (readyToFire && Input.GetMouseButton(0) && IsMouseOnBoard())
		{
            Vector2 velocity = mainCamera.ScreenToWorldPoint(Input.mousePosition) - startingPosition[startingIndex].parent.transform.position;
            velocity.Normalize();
			ballInstance.GetComponent<Rigidbody2D>().velocity = velocity;
			readyToFire = false;
            if (!isGameStarted)
            {
                isGameStarted = true;
            }
		}
	}

    bool IsMouseOnBoard()
    {
        Vector2 clickedPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        return (Mathf.Abs(clickedPosition.x) < 5) && (clickedPosition.y > -1.5f) && (clickedPosition.y < 7.5f);
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

    public bool IsGameOnGoing()
    {
        return !IsGameEnded() && isGameStarted;
    }
}