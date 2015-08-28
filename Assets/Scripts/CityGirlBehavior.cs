using UnityEngine;
using System.Collections;

public class CityGirlBehavior : EnemyBehavior {

    public GameObject flareGuard;
    private GameObject[] bricks;

    void Start () {
        base.Start();
        bricks = GameObject.FindGameObjectsWithTag("Brick");
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

}
