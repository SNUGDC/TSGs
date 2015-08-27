using UnityEngine;
using System.Collections;

public class BallMover : MonoBehaviour
{
	
	private float radius;
	private float acceleration;
	
	void Start()
	{
		radius = GetComponent<CircleCollider2D>().radius;
		acceleration = 0.05f;
	}
	
	void Update()
	{
		SetBallVelocity();
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Board"))
		{
			BallDestroy();
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Bar"))
		{
			BarBounce(other);
		}
	}
	
	void BarBounce(Collider2D other)
	{
		Vector2 ballVelocity = GetComponent<Rigidbody2D>().velocity;
		float ballSpeed = ballVelocity.magnitude;
		if (other.GetComponent<BarMover>().isVertical)
		{
			ballVelocity.x *= -1;
			ballVelocity.y = (transform.position.y - other.transform.position.y) * Mathf.Abs(ballVelocity.x);
		}
		else
		{
			ballVelocity.y *= -1;
			ballVelocity.x = (transform.position.x - other.transform.position.x) * Mathf.Abs(ballVelocity.y);
		}
		ballVelocity.Normalize();
        ballVelocity *= (ballSpeed + acceleration);
		GetComponent<Rigidbody2D>().velocity = ballVelocity;
	}
	
	/*
    void BarBounce(Collider2D other)
    {
        Vector2 ballVelocity = GetComponent<Rigidbody2D>().velocity;
        float xDistance = transform.position.x - other.transform.position.x;
        float yDistance = transform.position.y - other.transform.position.y;
        if (other.GetComponent<BarMover>().isVertical)
        {
            float angle = 45 * 2 * yDistance / other.GetComponent<BoxCollider2D>().size.y;
            ballVelocity = new Vector2(ballVelocity.magnitude * Mathf.Cos(angle) * Mathf.Sign(xDistance), ballVelocity.magnitude * Mathf.Sin(angle));
            ballVelocity *= acceleration;
        }
        else
        {
            float angle = 45 * 2 * xDistance / other.GetComponent<BoxCollider2D>().size.x;
            ballVelocity = new Vector2(ballVelocity.magnitude * Mathf.Sin(angle), ballVelocity.magnitude * Mathf.Cos(angle) * Mathf.Sign(yDistance));
            ballVelocity *= acceleration;
        }
        GetComponent<Rigidbody2D>().velocity = ballVelocity;
    }
    */
	
	void BallBounce(Collision2D other)
	{
		float xDistance;
		float yDistance;
		Vector2 ballVelocity = GetComponent<Rigidbody2D>().velocity;
		if (Mathf.Abs(xDistance = other.transform.position.x - transform.position.x) > Mathf.Epsilon)
		{
			ballVelocity.x *= -Mathf.Abs(xDistance/radius);
			
		}
		if (Mathf.Abs(yDistance = other.transform.position.y - transform.position.y) > Mathf.Epsilon)
		{
			ballVelocity.y *= -Mathf.Abs(yDistance / radius);
		}
		GetComponent<Rigidbody2D>().velocity = ballVelocity;
	}
	
	void BallDestroy()
	{
		Destroy(gameObject);
	}
	
	void SetBallVelocity()
	{
		if (GetComponent<Rigidbody2D>().velocity.magnitude < 5)
		{
			Vector2 ballVelocity = GetComponent<Rigidbody2D>().velocity;
			ballVelocity = ballVelocity.normalized * 5;
			GetComponent<Rigidbody2D>().velocity = ballVelocity;
		}
		else if (GetComponent<Rigidbody2D>().velocity.magnitude > 10)
		{
			Vector2 ballVelocity = GetComponent<Rigidbody2D>().velocity;
			ballVelocity = ballVelocity.normalized * 10;
			GetComponent<Rigidbody2D>().velocity = ballVelocity;
		}
	}
	
}
