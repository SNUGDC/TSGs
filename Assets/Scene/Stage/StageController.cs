using UnityEngine;
using System.Collections;

public class StageController : MonoBehaviour 
{
	public void Back()
	{
		Application.LoadLevel ("Start");
	}
}