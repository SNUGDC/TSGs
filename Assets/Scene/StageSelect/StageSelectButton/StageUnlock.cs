using UnityEngine;
using System.Collections;

public class StageUnlock : MonoBehaviour 
{
	public int levels;

	void Start () 
	{
		for (int i = 0; i < levels; i++) 
		{
			if (PlayerPrefs.GetInt("Level" + (i+2))==1)
			{
				GameObject.Find("StageLock" + (i+2)).SetActive(false);
			}
		}
	}
}