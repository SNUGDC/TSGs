using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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
			if (UserData.CH1 != null) {
				Bar1.AddComponent<Character> ().Name = UserData.CH1.Name;
				Bar1.AddComponent<Character> ().CharacterImage = UserData.CH1.CharacterImage;
			}
			if (UserData.CH2 != null) {
				Bar2.AddComponent<Character> ().Name = UserData.CH2.Name;
				Bar2.AddComponent<Character> ().CharacterImage = UserData.CH2.CharacterImage;
			}
			if (UserData.CH3 != null) {
				Bar3.AddComponent<Character> ().Name = UserData.CH3.Name;
				Bar3.AddComponent<Character> ().CharacterImage = UserData.CH3.CharacterImage;
			}
			if (UserData.CH4 != null) {
				Bar4.AddComponent<Character> ().Name = UserData.CH4.Name;
				Bar4.AddComponent<Character> ().CharacterImage = UserData.CH4.CharacterImage;
			}
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