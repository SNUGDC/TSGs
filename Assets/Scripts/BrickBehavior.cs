using UnityEngine;
using System.Collections;

public class BrickBehavior : MonoBehaviour {

    private GameObject bricks;
    private GameManager gameManager;
    public int brickHP;
    public Sprite brickImage1;
    public Sprite brickImage2;
    public Sprite brickImage3;
    public Sprite brickImage4;

	void Start () {
        bricks = GameObject.Find("Bricks");
        transform.SetParent(bricks.transform);
        brickHP = 3;
        DrawBrick();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	void Update () 
    {

	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Ball")
        {
            TakeDamage();
        }
    }

    void DrawBrick()
    {
        if (brickHP == 0)
        {
            SetInactive();
        }
        else if (brickHP == 1)
        {
            GetComponent<SpriteRenderer>().sprite = brickImage1;
        }
        else if (brickHP == 2)
        {
            GetComponent<SpriteRenderer>().sprite = brickImage2;
        }
        else if (brickHP == 2)
        {
            GetComponent<SpriteRenderer>().sprite = brickImage3;
        }
        else if (brickHP == 3)
        {
            GetComponent<SpriteRenderer>().sprite = brickImage3;
        }
        else if (brickHP == 4)
        {
            GetComponent<SpriteRenderer>().sprite = brickImage4;
        }
    }

    void TakeDamage()
    {
        brickHP--;
        DrawBrick();
    }

    void SetInactive()
    {
        gameObject.SetActive(false);
        gameManager.CheckGameClear();
    }

}
