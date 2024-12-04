using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {
    public static void SavePlayer (int scene) {
        BinaryFormatter formatter = new BinaryFormatter ();
        string path = Application.persistentDataPath + "/player.txt";
        FileStream stream = new FileStream (path, FileMode.Create);

        PlayerData playerData = new PlayerData (scene);

        formatter.Serialize (stream, playerData);
        stream.Close ();
    }
    public static PlayerData LoadPlayer () {
        string path = Application.persistentDataPath + "/player.txt";

        if (!File.Exists (path)) {
            SavePlayer (0);
        }

        try {
            BinaryFormatter formatter = new BinaryFormatter ();
            FileStream stream = new FileStream (path, FileMode.Open);

            PlayerData playerData = formatter.Deserialize (stream) as PlayerData;

            stream.Close ();

            return playerData;
        } catch {
            Debug.Log ("Save file not found: " + path);
            return null;
        }
    }
}
