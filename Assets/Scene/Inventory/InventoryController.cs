using UnityEngine;
using System.Collections;

public class InventoryController : MonoBehaviour 
{
	public GameObject CharacterSlot;
	public Transform BoxPosition;

	void Start()
	{
		Instantiate (CharacterSlot, BoxPosition.position, BoxPosition.rotation);
	}

	public void Back()
	{
		Application.LoadLevel ("Start");
	}
}