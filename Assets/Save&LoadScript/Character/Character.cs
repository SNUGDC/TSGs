using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace TSGs
{
	[System.Serializable]
	public class Character : MonoBehaviour
	{
		public string Name;
		public Sprite CharacterImage;
		public GameObject character;

		public void GetSprite()
		{
			character.GetComponent<Image>().sprite = CharacterImage;
		}

	}
}