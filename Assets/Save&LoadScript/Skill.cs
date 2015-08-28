using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Skill : MonoBehaviour {

	public IEnumerator Fire1()
	{
		GameObject ball = GameObject.FindGameObjectWithTag ("Ball");
		GameObject[] bricks = GameObject.FindGameObjectsWithTag ("Brick");
		GameObject enemy = GameObject.FindGameObjectWithTag ("Enemy");
		Sprite normalball = ball.GetComponent<SpriteRenderer> ().sprite;
		ball.GetComponent<SpriteRenderer> ().sprite = GameObject.Find ("GameManager").GetComponent<GameManager> ().fireball;
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

	public IEnumerator Fire2()
	{
		GameObject ball = GameObject.FindGameObjectWithTag ("Ball");
		Sprite normalball = ball.GetComponent<SpriteRenderer> ().sprite;
		ball.GetComponent<SpriteRenderer> ().sprite = GameObject.Find ("GameManager").GetComponent<GameManager> ().fireball;
		ball.GetComponent<CircleCollider2D> ().isTrigger = true;
		yield return new WaitForSeconds(5);
		ball.GetComponent<CircleCollider2D> ().isTrigger = false;
	}

	public IEnumerator Water1()
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

	public IEnumerator Water2()
	{
		GameObject ball = GameObject.FindGameObjectWithTag ("Ball");
		Sprite normalball = ball.GetComponent<SpriteRenderer> ().sprite;
		ball.GetComponent<SpriteRenderer> ().sprite = GameObject.Find ("GameManager").GetComponent<GameManager> ().waterball;
		Vector3 ballScale = ball.transform.localScale;
		ballScale.x = 2;
		ballScale.y = 2;
		ball.transform.localScale=ballScale;
		yield return new WaitForSeconds (5);
		ball.GetComponent<SpriteRenderer> ().sprite = normalball;
		ballScale.x = 1;
		ballScale.y = 1;
		ball.transform.localScale=ballScale;
	}

	public IEnumerator Grass1()
	{
		GameObject timebar = GameObject.Find ("TimeBar");
		float timeRestore=Time.deltaTime*5;
		float Maxtime=90;
		float timeLeft = timebar.GetComponent<Slider> ().value*Maxtime;
		timeLeft = timeLeft + timeRestore;
		timebar.GetComponent<Slider> ().value = timeLeft / Maxtime;
		yield return null;
	}

	public IEnumerator Glow1()
	{
		GameObject timebar = GameObject.Find ("TimeBar");
		float Maxtime = 90;
		float timeLeft = timebar.GetComponent<Slider> ().value*Maxtime;
		timebar.GetComponent<Slider> ().value = timeLeft / Maxtime;
		yield return new WaitForSeconds (5);
	}

	public IEnumerator Dark1()
	{
		Transform bar;
		int entryNum=0;
		if (entryNum == 1) {
			bar = GameObject.Find ("LowerBar").transform.FindChild("MagicCircle");
			Vector3 barScale = bar.localScale;
			barScale.x = 3;
			bar.localScale = barScale;
			yield return new WaitForSeconds (5);
			barScale.x = 1;
			bar.localScale = barScale;
		} else if (entryNum == 2) {
			bar = GameObject.Find ("RightBar").transform.FindChild("MagicCircle");
			Vector3 barScale = bar.localScale;
			barScale.y = 3;
			bar.localScale = barScale;
			yield return new WaitForSeconds (5);
			barScale.y = 1;
			bar.localScale = barScale;
		} else if (entryNum == 3) {
			bar = GameObject.Find ("UpperBar").transform.FindChild("MagicCircle");
			Vector3 barScale = bar.localScale;
			barScale.x = 3;
			bar.localScale = barScale;
			yield return new WaitForSeconds (5);
			barScale.x = 1;
			bar.localScale = barScale;
		} else if (entryNum == 4) {
			bar = GameObject.Find ("LeftBar").transform.FindChild("MagicCircle");
			Vector3 barScale = bar.localScale;
			barScale.y = 3;
			bar.localScale = barScale;
			yield return new WaitForSeconds(5);
			barScale.y=1;
			bar.localScale=barScale;
		}
	}
}
