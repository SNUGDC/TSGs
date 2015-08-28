using UnityEngine;
using System.Collections;

public class StageTransition : MonoBehaviour 
{
	public void Back()
	{
		Application.LoadLevel ("Start");
	}
	
	public void TransferToStage1()
	{
		Application.LoadLevel ("Stage01");
	}
}
