using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Skill : MonoBehaviour {

	IEnumerator Fire1()
	{
		GameObject ball = GameObject.FindGameObjectWithTag ("Ball");
		GameObject[] bricks = GameObject.FindGameObjectsWithTag ("Brick");
		int blockdamage;
		Sprite normalball = ball.GetComponent<SpriteRenderer> ().sprite;
		ball.GetComponent<SpriteRenderer> ().sprite = GetComponent<GameManager> ().fireball;
		int i;
		for (i=0; i<bricks.Length; i++) {
			bricks[i].GetComponent<BrickBehavior> ().brickDamage = 2;
		}
		yield return new WaitForSeconds (5);
		ball.GetComponent<SpriteRenderer> ().sprite = normalball;
		for (i=0; i<bricks.Length; i++) {
			bricks[i].GetComponent<BrickBehavior> ().brickDamage = 1;
		}
	}

	void Water1()
	{
		GameObject[] bricks = GameObject.FindGameObjectsWithTag ("Brick");
		int i;
		for (i=0; i<bricks.Length; i++) {
			bricks [i].GetComponent<BrickBehavior> ().brickHP--;
			bricks [i].GetComponent<BrickBehavior> ().DrawBrick ();
		}
	}

	IEnumerator Water2()
	{
		GameObject ball = GameObject.FindGameObjectWithTag ("Ball");
		Vector3 ballScale = ball.transform.localScale;
		ballScale.x *= 2;
		ballScale.y *= 2;
		ball.transform.localScale=ballScale;
		yield return new WaitForSeconds (5);
		ballScale.x /= 2;
		ballScale.y /= 2;
		ball.transform.localScale=ballScale;
	}

	void Grass1()
	{
		GameObject timebar = GameObject.Find ("TimeBar");
		float timeRestore=Time.deltaTime*5;
		float Maxtime=30;
		float timeLeft = timebar.GetComponent<Slider> ().value*Maxtime;
		timeLeft = timeLeft + timeRestore;
		timebar.GetComponent<Slider> ().value = timeLeft / Maxtime;
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
