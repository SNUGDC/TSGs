using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

    public int enemyMaxHP;
    public int enemyDamage;
    protected int enemyCurrentHP;
    protected bool isKnockBacking;
    [SerializeField]
    protected GameManager gameManager;

	protected void Start () {
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
        GetComponent<SpriteRenderer>().color = new Color(1, (float)enemyCurrentHP / enemyMaxHP, (float)enemyCurrentHP / enemyMaxHP);
        StartCoroutine("KnockBack");
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

    IEnumerator KnockBack()
    {
        isKnockBacking = true;
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        Vector2 nextPosition = transform.position;
        nextPosition -= velocity / 2;
        transform.position = nextPosition;
        yield return new WaitForSeconds(1);
        isKnockBacking = false;
    }

}
