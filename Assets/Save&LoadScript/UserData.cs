using UnityEngine;
using System.Collections;

namespace TSGs
{
    [System.Serializable]
    public class UserData : MonoBehaviour
    {
        public static UserData current;
        public static Character CH1;
        public static Character CH2;
        public static Character CH3;
        public static Character CH4;

        public UserData()
        {
            CH1 = new Character();
			CH2 = new Character();
            CH3 = new Character();
            CH4 = new Character();
        }
    }
}