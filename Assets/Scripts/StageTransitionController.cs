using UnityEngine;
using System.Collections;

public class StageTransitionController : MonoBehaviour 
{
	public void TransferToStart()
	{
		Application.LoadLevel ("Start");
	}
}
