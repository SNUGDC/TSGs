using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

    public int enemyMaxHP;
    public int enemyDamage;
    private int enemyCurrentHP;
    private GameManager gameManager;

	void Start () {
        enemyCurrentHP = enemyMaxHP;
        enemyDamage = 1;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Ball")
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        enemyCurrentHP -= enemyDamage;
        if (enemyCurrentHP <= 0)
        {
            EnemyDefeated();
        }
    }

    void EnemyDefeated()
    {
        gameObject.SetActive(false);
        gameManager.CheckGameClear();
    }
}
