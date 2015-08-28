using UnityEngine;
using System.Collections;

namespace TSGs.Inventory
{
	public class InventoryController : MonoBehaviour 
	{
		public GameObject CharacterSlot;
		public GameObject Bar1;
		public GameObject Bar2;
		public GameObject Bar3;
		public GameObject Bar4;

		void Start()
		{
			SaveLoad.Load ();
			if(UserData.CH1 != null)
			Bar1.AddComponent<Character> ().Name = UserData.CH1.Name;
			if(UserData.CH2 != null)
			Bar2.AddComponent<Character> ().Name = UserData.CH2.Name;
			if(UserData.CH3 != null)
			Bar3.AddComponent<Character> ().Name = UserData.CH3.Name;
			if(UserData.CH4 != null)
			Bar4.AddComponent<Character> ().Name = UserData.CH4.Name;
		}

		void Update()
		{
			if (Bar1.transform.childCount > 0) 
			{
				UserData.CH1 = Bar1.GetComponentInChildren<Character>();
				SaveLoad.Save();
			}
			
			if (Bar2.transform.childCount > 0) 
			{
				UserData.CH2 = Bar2.GetComponentInChildren<Character>();
				SaveLoad.Save();
			}
			
			if (Bar3.transform.childCount > 0) 
			{
				UserData.CH3 = Bar3.GetComponentInChildren<Character>();
				SaveLoad.Save();
			}
			
			if (Bar4.transform.childCount > 0) 
			{
				UserData.CH4 = Bar4.GetComponentInChildren<Character>();
				SaveLoad.Save();
			}
		}

		public void Back()
		{
			Application.LoadLevel ("Start");
		}
	}
}