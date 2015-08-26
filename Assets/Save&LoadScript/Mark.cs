using UnityEngine;
using System.Collections;

public class Mark : Character {

	public Mark()
	{
		name = "Mark";
	}

	public void skill()
	{
		GameObject[] bricks = GameObject.FindGameObjectsWithTag ("Brick");
		int i;
		for (i=0; i<bricks.Length; i++) {
			bricks [i].GetComponent<BrickBehavior> ().brickHP--;
			bricks [i].GetComponent<BrickBehavior> ().DrawBrick ();
		}
	}
}
