using UnityEngine;
using System.Collections;

public class CityGirlBehavior : EnemyBehavior {

    public GameObject flareGuard;
    private GameObject[] bricks;
    private bool isMoving;

    void Start () 
    {
        base.Start();
        bricks = GameObject.FindGameObjectsWithTag("Brick");
        isMoving = false;
	}

    void Update()
    {
        if (gameManager.IsGameOnGoing() && !isMoving)
        {
            isMoving = true;
            StartCoroutine("Move");
        }
    }

    protected override void TakeDamage()
    {
        if (!BrickExistance())
        {
            base.TakeDamage();
        }
        else
        {
            Instantiate(flareGuard, transform.position, Quaternion.identity);
        }
    }

    bool BrickExistance()
    {
        for (int i = 0; i < bricks.Length; i++)
        {
            if (bricks[i].activeSelf)
            {
                return true;
            }
        }
        return false;
    }

    IEnumerator Move()
    {
        while (true)
        {
            int randomNumber = Random.Range(0, 4);

            if (randomNumber == 0)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.up * 2;
            }
            else if (randomNumber == 1)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.down * 2;
            }
            else if (randomNumber == 2)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.right * 2;
            }
            else if (randomNumber == 3)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.left * 2;
            }

            yield return new WaitForSeconds(1.5f);

            if (randomNumber == 0)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.down * 2;
            }
            else if (randomNumber == 1)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.up * 2;
            }
            else if (randomNumber == 2)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.left * 2;
            }
            else if (randomNumber == 3)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.right * 2;
            }

            yield return new WaitForSeconds(1.5f);

            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            yield return new WaitForSeconds(3f);
        }
    
    }

    override protected IEnumerator KnockBack()
    {
        isKnockBacking = true;
        yield return new WaitForSeconds(1);
        isKnockBacking = false;
    }

}
