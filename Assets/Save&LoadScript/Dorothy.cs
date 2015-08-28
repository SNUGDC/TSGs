using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace TSGs
{
	public class Dorothy : Character {

		public Dorothy()
		{
			Name = "Dorothy";
			SetSkill ();
		}

		public void SetSkill()
		{
			_skill.Dark1 ();
		}
	}
}