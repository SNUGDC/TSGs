using UnityEngine;
using System.Collections;

[System.Serializable]
public class Character : MonoBehaviour
{
	public string Name;
	public string Skill;

	public Character()
	{
		this.Name = "";
		this.Skill = "";
	}
}
