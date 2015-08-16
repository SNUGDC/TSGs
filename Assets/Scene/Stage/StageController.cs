using UnityEngine;
using System.Collections;

public class StageController : MonoBehaviour 
{
	bool Win;

	public void Back()
	{
		Application.LoadLevel ("Start");
	}

	public void BossClearEevent()
	{
		int CharacterGotcha = Random.Range (0, 1);
		if (CharacterGotcha >= 0.5) 
		{

		}
	}
}