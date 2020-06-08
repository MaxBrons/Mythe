using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class GameSave
{
    public static void SavePlayer() {

    }

    public static void SaveLevel() {
        //Create a new seed and save it in a file
        int rand = UnityEngine.Random.Range(-999999999, 999999999);

        //Save the seed to a new file if it doesn't exit already
        Save(rand.ToString(), Constants._caveSeedName + GameManager.Instance.NextToSpawnCaveLevelIndex);
        GameManager.Instance.NextToSpawnCaveLevelIndex++;
    }
    public static void LoadLevel(int index) {
        //Set the seed for Randomness in unity to the value of the file
        object obj = Load(Constants._caveSeedName + index);
        if (obj != null) Random.InitState(int.Parse((string)obj));
    }

    private static bool Save(object obj, string file) {
        //Create the directory if it does not exist
        if (!Directory.Exists(Application.persistentDataPath + Constants._caveSaveLocation)) {
            Directory.CreateDirectory(Application.persistentDataPath + Constants._caveSaveLocation);
        }

        //Set the path where the file needs to be stored
        string path = Application.persistentDataPath + Constants._caveSaveLocation + file + Constants._saveLocationFileDataType;

        if (!File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter(); //Encrypts the file

            //Sets a random seed for the random generation of the caves
            object _object = obj;

            //Create a new seed file
            FileStream stream = new FileStream(path, FileMode.Create);

            //Serialize the data and store it in the file
            formatter.Serialize(stream, _object);
            stream.Close(); //Closes the data stream
            return true;
        }
        return false;
    }

    private static object Load(string file) {
        BinaryFormatter formatter = new BinaryFormatter(); //Encrypts the file

        //Set the path where the file needs to be stored
        string path = Application.persistentDataPath + Constants._caveSaveLocation + file + Constants._saveLocationFileDataType;

        //Check if the seed file exists
        if (!File.Exists(path)) return null;

        //Eather add something to the file or create a new file
        FileStream stream = new FileStream(path, FileMode.Open);

        //DeSerialize the data from the file and store it in a variable
        object obj = (object)formatter.Deserialize(stream);

        stream.Close(); //Closes the data stream
        return obj;
    }
}
