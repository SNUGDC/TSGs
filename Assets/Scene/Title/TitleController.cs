using UnityEngine;
using System.Collections;

namespace TSGs
{
	public class TitleController : MonoBehaviour 
	{
		void Start()
		{
			SaveLoad.Save ();
			SaveLoad.Load ();
		}

		public void TransferToStart()
		{
			Application.LoadLevel ("Start");
		}
	}
}