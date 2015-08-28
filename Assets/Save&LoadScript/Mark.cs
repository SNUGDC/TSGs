using UnityEngine;
using System.Collections;

namespace TSGs
{
	public class Mark : Character 
	{
		public Mark()
		{
			Name = "Mark";
			SetSkill ();
		}

		public void SetSkill()
		{
			_skill.Water1 ();
		}
	}
}