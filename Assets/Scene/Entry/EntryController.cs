using UnityEngine;
using System.Collections;

public class EntryController : MonoBehaviour 
{
	public void Back()
	{
		Application.LoadLevel ("StageSelect");
	}

	public void TrnasferToStage()
	{
		Application.LoadLevel ("Stage");
	}
}
