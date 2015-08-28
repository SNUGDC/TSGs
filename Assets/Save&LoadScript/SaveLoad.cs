using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace TSGs
{
    public static class SaveLoad
    {
        public static List<UserData> savedGames = new List<UserData>();

        public static void Save()
        {
            savedGames.Add(UserData.current);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create((Application.persistentDataPath + "/savedGames.gd"));
            bf.Serialize(file, SaveLoad.savedGames);
            file.Close();
        }

        public static void Load()
        {
            if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
                SaveLoad.savedGames = (List<UserData>)bf.Deserialize(file);
                file.Close();
            }
        }
    }
}
