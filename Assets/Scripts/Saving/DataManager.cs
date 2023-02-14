#region
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEditor;
using UnityEngine.SceneManagement;
#endregion

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    #region Publics 
    public int Level1Silver { get; set; } = 0; // number of silver coins the player got in level 1
    public int Level1Gold { get; set; } = 0; // number of silver coins the player got in level 1
    public bool Level1Complete { get; set; } // checks for the completion of the level
    public bool Level1Green { get; set; } // checks for getting green gem in l1
    public bool Level1Red { get; set; } // checks for getting red gem in l1
    public bool Level1Blue { get; set; } // checks for getting blue gem in l1
    #endregion

    public void Awake()
    {
        if (Instance != null) // if an instance of the datamanager already exists, and it's not supposed to
        { Destroy(gameObject); } // destroy it
        else
        { Instance = this; } // and make this one the real slim shady. makes sure the thing works, and stops the game from making more when a new scene's loaded.

        DontDestroyOnLoad(gameObject);
        LoadGame();
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/saveData.dat");

        PlayerData data = new PlayerData(Level1Complete, Level1Silver, Level1Gold, Level1Green, Level1Red, Level1Blue);

        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/saveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveData.dat", FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file);

            Level1Complete = data.Level1Complete;
            Level1Silver = data.Level1Silver;
            Level1Gold = data.Level1Gold;
            Level1Green = data.Level1Green;
            Level1Red = data.Level1Red;
            Level1Blue = data.Level1Blue;  

            file.Close();
        }
    }
}

[Serializable]
public class PlayerData
{
    #region Level 1

    private bool level1Complete;
    public bool Level1Complete => level1Complete;

    private int level1Silver;
    public int Level1Silver => level1Silver;

    private int level1Gold;
    public int Level1Gold => level1Gold;

    private bool level1Green;
    public bool Level1Green => level1Green;

    private bool level1Red;
    public bool Level1Red => level1Red;

    private bool level1Blue;
    public bool Level1Blue => level1Blue;

    #endregion

    public PlayerData(bool l1c, int l1sc, int l1gc, bool l1g, bool l1r, bool l1b)
    {
        level1Complete = l1c;
        level1Silver = l1sc;
        level1Gold = l1gc;
        level1Green = l1g;
        level1Red = l1r;
        level1Blue = l1b;
    }
}