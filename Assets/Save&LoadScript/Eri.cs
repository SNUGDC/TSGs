using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Eri : Character {

	public Eri()
	{
		name = "Eri";
	}

	public void skill()
	{
		GameObject timebar = GameObject.Find ("TimeBar");
		float timeRestore=Time.deltaTime*5;
		float Maxtime=30;
		float timeLeft = timebar.GetComponent<Slider> ().value*Maxtime;
		timeLeft = timeLeft + timeRestore;
		timebar.GetComponent<Slider> ().value = timeLeft / Maxtime;
	}
}
