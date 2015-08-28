using UnityEngine;
using System.Collections;

namespace TSGs
{
	public class Nozomi : Character {
		public Nozomi()
		{
			Name = "Nozomi";
			SetSkill ();
		}

		public void SetSkill()
		{
			_skill.Glow1 ();
		}
	}
}