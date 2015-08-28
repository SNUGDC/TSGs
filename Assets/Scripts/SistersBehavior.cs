using UnityEngine;
using System.Collections;

public class SistersBehavior : EnemyBehavior {

    bool isMoving;
    bool resurrectionStart;
    public GameObject sister;
    public GameObject resurrectionSmoke;
    Vector2 nextPosition;

    void Start()
    {
        base.Start();
        resurrectionStart = false;
    }

	void Update () {
        if (gameManager.IsGameOnGoing())
        {
            if (!isMoving)
            {
                StartCoroutine("SearchForNextPosition");
                isMoving = true;
            }
            Move();
        }
        if (!sister.active && resurrectionStart == false)
        {
            StartCoroutine("Resurrection");
            resurrectionStart = true;
        }
	}

    IEnumerator Resurrection()
    {
        Instantiate(resurrectionSmoke, sister.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(10.0f);
        sister.GetComponent<SistersBehavior>().enemyCurrentHP = sister.GetComponent<SistersBehavior>().enemyMaxHP;
        sister.SetActive(true);
    }

    IEnumerator SearchForNextPosition()
    {
        while (true)
        {
            SetNextPosition();
            yield return new WaitForSeconds(5.0f);
        }
    }

    void SetNextPosition()
    {
        nextPosition = new Vector2(Random.Range(-2.5f, 2.5f), Random.Range(0.5f, 5.5f));
    }

    void Move()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(nextPosition.x - transform.position.x, nextPosition.y - transform.position.y);
    }

}
