using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Skill : MonoBehaviour {

	IEnumerator Fire1()
	{
		GameObject ball = GameObject.FindGameObjectWithTag ("Ball");
		GameObject[] bricks = GameObject.FindGameObjectsWithTag ("Brick");
		GameObject enemy = GameObject.FindGameObjectWithTag ("Enemy");
		Sprite normalball = ball.GetComponent<SpriteRenderer> ().sprite;
		ball.GetComponent<SpriteRenderer> ().sprite = GetComponent<GameManager> ().fireball;
		int i;
		for (i=0; i<bricks.Length; i++) {
			bricks[i].GetComponent<BrickBehavior> ().brickDamage = 2;
		}
		enemy.GetComponent<EnemyBehavior> ().enemyDamage = 2;
		yield return new WaitForSeconds (5);
		ball.GetComponent<SpriteRenderer> ().sprite = normalball;
		for (i=0; i<bricks.Length; i++) {
			bricks[i].GetComponent<BrickBehavior> ().brickDamage = 1;
		}
		enemy.GetComponent<EnemyBehavior> ().enemyDamage = 1;
	}

	IEnumerator Water1()
	{
		GameObject[] bricks = GameObject.FindGameObjectsWithTag ("Brick");
		GameObject enemy = GameObject.FindGameObjectWithTag ("Enemy");
		int i;
		for (i=0; i<bricks.Length; i++) {
			bricks [i].GetComponent<BrickBehavior> ().brickHP--;
			bricks [i].GetComponent<BrickBehavior> ().DrawBrick ();
		}
		enemy.GetComponent<EnemyBehavior> ().enemyCurrentHP--;
		yield return null;
	}

	IEnumerator Water2()
	{
		GameObject ball = GameObject.FindGameObjectWithTag ("Ball");
		Vector3 ballScale = ball.transform.localScale;
		ballScale.x = 2;
		ballScale.y = 2;
		ball.transform.localScale=ballScale;
		yield return new WaitForSeconds (5);
		ballScale.x = 1;
		ballScale.y = 1;
		ball.transform.localScale=ballScale;
	}

	IEnumerator Grass1()
	{
		GameObject timebar = GameObject.Find ("TimeBar");
		float timeRestore=Time.deltaTime*5;
		float Maxtime=30;
		float timeLeft = timebar.GetComponent<Slider> ().value*Maxtime;
		timeLeft = timeLeft + timeRestore;
		timebar.GetComponent<Slider> ().value = timeLeft / Maxtime;
		yield return null;
	}

	IEnumerator Glow1()
	{
		GameObject timebar = GameObject.Find ("TimeBar");
		float Maxtime = 30;
		float timeLeft = timebar.GetComponent<Slider> ().value*Maxtime;
		timebar.GetComponent<Slider> ().value = timeLeft / Maxtime;
		yield return new WaitForSeconds (5);
	}

	void Dark1()
	{

	}
}
