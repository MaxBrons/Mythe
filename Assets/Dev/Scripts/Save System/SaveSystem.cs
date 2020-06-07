using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SavePlayer() {

    }

    public static void NewLevel() {
        //Create a new seed
        CreateRandomSeedValue();
        UnityEngine.Random.InitState(LoadSavedSeed());
    }
    private static void CreateRandomSeedValue() {
        //Create the directory if it does not exist
        if (!Directory.Exists(Application.persistentDataPath + Constants._caveSaveLocation)) {
            Directory.CreateDirectory(Application.persistentDataPath + Constants._caveSaveLocation);
        }

        //Set the path where the file needs to be stored
        string path = Application.persistentDataPath + Constants._caveSaveLocation + Constants._caveSeedName +
            GameManager.NextToSpawnCaveLevelIndex + Constants._saveLocationFileDataType;

        if (!File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter(); //Encrypts the file

            //Sets a random seed for the random generation of the caves
            string seed = UnityEngine.Random.Range(-999999999, 999999999).ToString();

            //Create a new seed file
            FileStream stream = new FileStream(path, FileMode.Create);

            //Serialize the data and store it in the file
            formatter.Serialize(stream, seed);
            stream.Close(); //Closes the data stream

            GameManager.NextToSpawnCaveLevelIndex++;

        }
    }

    private static int LoadSavedSeed() {
        BinaryFormatter formatter = new BinaryFormatter(); //Encrypts the file

        //Set the path where the file needs to be stored
        string path = Application.persistentDataPath + Constants._caveSaveLocation + Constants._caveSeedName +
            GameManager.CurrentCaveLevel + Constants._saveLocationFileDataType;

        //Check if the seed file exists
        if (!File.Exists(path)) return 0;

        //Eather add something to the file or create a new file
        FileStream stream = new FileStream(path, FileMode.Open);

        //DeSerialize the data from the file and store it in a variable
        int seed = int.Parse((string)formatter.Deserialize(stream));

        stream.Close(); //Closes the data stream
        return seed;
    }
}
