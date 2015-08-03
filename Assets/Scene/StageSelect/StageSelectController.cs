using UnityEngine;
using System.Collections;

public class StageSelectController : MonoBehaviour 
{
	public void Back()
	{
		Application.LoadLevel ("Start");
	}

	public void TransferToEntry()
	{
		Application.LoadLevel ("Entry");
	}
}