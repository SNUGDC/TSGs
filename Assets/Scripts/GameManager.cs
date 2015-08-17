using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private bool ballExistence;
    private bool readyToFire;
    private int startingIndex;
    public GameObject ball;
    public GameObject ballInstance;
    public Transform[] startingPosition;
	// Use this for initialization
	void Start () {
        ballExistence = false;
        readyToFire = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (!ballExistence)
        {
            BallGeneration();
        }
        SetBall();
        FireBall();
        CheckBall();
	}

    void BallGeneration()
    {
        GameObject instance = ball;
        instance.transform.position = startingPosition[startingIndex = Random.Range(0, startingPosition.Length)].position;
        ballInstance = Instantiate(instance);
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
}
