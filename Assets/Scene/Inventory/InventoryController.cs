using UnityEngine;
using System.Collections;

public class InventoryController : MonoBehaviour 
{
	public GameObject CharacterSlot;

	void Start()
	{
	}

	public void Back()
	{
		Application.LoadLevel ("Start");
	}
}