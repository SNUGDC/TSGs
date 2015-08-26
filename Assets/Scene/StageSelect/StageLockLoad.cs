using UnityEngine;
using System.Collections.Generic;

public class StageLockLoad : MonoBehaviour {
	public int level;

	void Start () 
	{
		for (int i = 0; i < level; i++) 
		{
				if(PlayerPrefs.GetInt("Level" + (i+1))==null)
				PlayerPrefs.SetInt("Level" + (i+1),0);
		}
	}
}
