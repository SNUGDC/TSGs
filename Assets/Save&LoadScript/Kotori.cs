using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace TSGs
{
	public class Kotori : Character {

		public Kotori()
		{
			Name = "Kotori";
			SetSkill ();
		}

		public void SetSkill()
		{
			_skill.Fire1 ();
		}
	}
}