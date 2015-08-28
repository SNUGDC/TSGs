using UnityEngine;
using System.Collections;

public class SnowFairyBehavior : EnemyBehavior {

    private GameObject ball;
    private bool readyToFreeze;
    private float skillEffectTime;
    private float skillCoolTime;
    private bool freezing;
    public GameObject freezeEffect;

    void Start()
    {
        base.Start();
        readyToFreeze = true;
        skillEffectTime = 5.0f;
        skillCoolTime = 5.0f;
        freezing = false;
    }

    void Update()
    {
        if (gameManager.IsGameOnGoing() && !gameManager.readyToFire)
        {
            if (readyToFreeze && GameObject.FindGameObjectWithTag("Ball") != null)
            {
                StartCoroutine("BallFreeze");
            }
            if (freezing)
            {
                FindBall();
                SlowerBall(ball);
            }
        }
        if (gameManager.ballExistence == false)
        {
            freezing = false;
        }
    }

    void FindBall()
    {
        if (GameObject.FindGameObjectWithTag("Ball") != null)
        {
            ball = GameObject.FindGameObjectWithTag("Ball");
        }
    }

    IEnumerator BallFreeze()
    {
        FindBall();
        readyToFreeze = false;
        freezing = true;
        ball.GetComponent<BallMover>().isFrozen = true;
        if ( ball != null)
        {
            Instantiate(freezeEffect, ball.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(skillEffectTime);
            freezing = false;
            if (ball != null)
            {
                ball.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                ball.GetComponent<BallMover>().isFrozen = false;
            }
            yield return new WaitForSeconds(skillCoolTime);
            readyToFreeze = true;
        }
    }

    void SlowerBall(GameObject ball)
    {
        if (ball != null)
        {
            ball.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 1);
        }
    }

}
