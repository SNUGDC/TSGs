using UnityEngine;
using System.Collections;

public class StartController : MonoBehaviour 
{
	public void TransferToStageSelect()
	{
		Application.LoadLevel ("StageSelect");
	}
	
	public void TransferToInventory()
	{
		Application.LoadLevel ("Inventory");
	}
	
	public void TransferToSetting()
	{
		Application.LoadLevel ("Setting");
	}
}
