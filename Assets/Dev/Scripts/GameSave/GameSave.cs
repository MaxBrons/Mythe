using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Random = UnityEngine.Random;

public static class GameSave
{
    public static int _randomSeed { get; private set; }
    public static void SavePlayer() {

    }

    public static void SaveLevel(object data, string name, int i) {
        //Save the data provided in a file with the given file name
        LoadSeed(i);
        Save(data, name + _randomSeed + i);
    }

    public static List<CaveSectionData> LoadLevel(int index) {
        //Return a list of CaveSectionData
        List<CaveSectionData> cave = Load(Constants._caveName + _randomSeed + index) as List<CaveSectionData>;
        return cave ?? null;
    }
    public static void LoadSeed(int index) {
        //Save or set the seed to the int stored in the saved file
        object seed = Load(Constants._caveSeedName + index);
        _randomSeed = seed == null ? UnityEngine.Random.Range(-999999999, 999999999) : int.Parse((string)seed);
        Save(_randomSeed.ToString(), Constants._caveSeedName + index);
        Random.InitState(_randomSeed);
    }

    public static void DeleteFile(int index) {
        string path = Application.persistentDataPath + Constants._caveSaveLocation + Constants._caveName + _randomSeed + index + Constants._saveLocationFileDataType;
        if (!File.Exists(path)) return;
        File.Delete(path);
    }
    public static void DeleteSaveFiles() => Directory.Delete(Application.persistentDataPath + Constants._caveSaveLocation, true);

    #region Save And Load
    private static bool Save(object obj, string file) {
        //Create the directory if it does not exist
        if (!Directory.Exists(Application.persistentDataPath + Constants._caveSaveLocation)) {
            Directory.CreateDirectory(Application.persistentDataPath + Constants._caveSaveLocation);
        }

        //Set the path where the file needs to be stored
        string path = Application.persistentDataPath + Constants._caveSaveLocation + file + Constants._saveLocationFileDataType;

        if (!File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter(); //Encrypts the file

            //Create a new seed file
            FileStream stream = new FileStream(path, FileMode.Create);

            //Serialize the data and store it in the file
            formatter.Serialize(stream, obj);
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
        object obj = formatter.Deserialize(stream);

        stream.Close(); //Closes the data stream
        return obj;
    }
    #endregion
}
