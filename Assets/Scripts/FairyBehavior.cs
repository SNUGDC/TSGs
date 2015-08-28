using UnityEngine;
using System.Collections;

public class FairyBehavior : EnemyBehavior {

    [SerializeField]
    private GameObject ball;
    private float fairySpeed = 2;
    private GameObject board;

	void Start () {
        base.Start();
        board = GameObject.Find("Board");
	}
	
	void Update () {
        if (gameManager.IsGameOnGoing() && !gameManager.readyToFire)
        {
            FindBall();
            ChaseBall();
        }
        if (isKnockBacking || gameManager.readyToFire)
        {
            StopMoving();
        }
	}

    void ChaseBall()
    {
        Vector2 targetPosition;
        if (ball != null)
        {
            targetPosition = ball.transform.position;
        }
        else
        {
            targetPosition = board.transform.position;
        }
        Vector2 currentPosition = transform.position;
        Vector2 velocity = (targetPosition - currentPosition);
        if (velocity.magnitude < 0.05)
        {
            StopMoving();
            return;
        }
        velocity.Normalize();
        velocity *= fairySpeed;
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    void FindBall()
    {
        if (GameObject.FindGameObjectWithTag("Ball") != null)
        {
            ball = GameObject.FindGameObjectWithTag("Ball");
        }   
    }

    void StopMoving()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

}
