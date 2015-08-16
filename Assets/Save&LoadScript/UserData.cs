using UnityEngine;
using System.Collections;

[System.Serializable]
public class UserData : MonoBehaviour
{
	public static UserData current;
	public Character CH1;
	public Character CH2;
	public Character CH3;
	public Character CH4;

	public UserData()
	{
		CH1 = new Character();
		CH2 = new Character();
		CH3 = new Character();
		CH4 = new Character();
	}
}
