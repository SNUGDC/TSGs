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
	public GameObject ball;
	public Transform[] startingPosition;

	void Start () {
		ballExistence = false;
		ballGenerationStarted = false;
		readyToFire = false;
		timeLeft = maxTime = 60;
		timeBar = GameObject.Find("TimeBar");
	}

	void Update () {
		if (!ballExistence && !ballGenerationStarted)
		{
			StartCoroutine("BallGenerationStart");
		}
		SetBall();
		FireBall();
		CheckBall();
		TimeLapse();
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
		GameObject instance = ball;
		instance.transform.position = startingPosition[startingIndex = Random.Range(0, startingPosition.Length)].position;
		ballInstance = Instantiate(instance) as GameObject;
		ballExistence = true;
		readyToFire = true;
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
}