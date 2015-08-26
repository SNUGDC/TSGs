using UnityEngine;
using System.Collections;

public class StageTransitionController : MonoBehaviour 
{
	public void TransferToStart()
	{
		Application.LoadLevel ("Start");
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
	}
}
