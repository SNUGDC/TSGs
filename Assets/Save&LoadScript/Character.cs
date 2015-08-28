using UnityEngine;
using System.Collections;

namespace TSGs
{
	[System.Serializable]
	public class Character : MonoBehaviour
	{
		public string Name;
		public Skill _skill;

		public Character()
		{
			Name = "";
			SetSkill ();
		}

		public void SetSkill()
		{
			_skill.Fire1();
		}
	}
}