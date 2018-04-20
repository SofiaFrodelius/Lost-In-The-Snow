using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad : MonoBehaviour {

    public static SaveLoad saveLoad;

    public float playerPositionX;
    public float playerPositionY;
    public float playerPositionZ;
    public float playerRotationX;
    public float playerRotationY;
    public float playerRotationZ;
    public float playerRotationW;
    public float lookX;
    public float lookY;
    public int sceneNumber;
    public bool newGame = true;
    CameraController cameraController;

    void Awake()
    {
       if (saveLoad == null)
        {
            DontDestroyOnLoad(gameObject);
            saveLoad = this;
        } 
       else if (saveLoad != this)
        {
            Destroy(gameObject);
        }
    }
    
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayData data = new PlayData();
        data.playerPosX = playerPositionX;
        data.playerPosY = playerPositionY;
        data.playerPosZ = playerPositionZ;
        data.lkX = lookX;
        data.lkY = lookY;
        data.SceneNr = sceneNumber;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

            PlayData data = (PlayData)bf.Deserialize(file);
            file.Close();

            playerPositionX = data.playerPosX;
            playerPositionY = data.playerPosY;
            playerPositionZ = data.playerPosZ;
            lookX = data.lkX;
            lookY = data.lkY;
            sceneNumber = data.SceneNr;
            newGame = false;
        }
    }

    public void Delete()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            File.Delete(Application.persistentDataPath + "/playerInfo.dat");
        }
    }

    public void Pause()
    {
        cameraController = GetComponent<CameraController>();
        Time.timeScale = 0;
        cameraController.enabled = false;
    }
}

[Serializable]
class PlayData
{
    public float playerPosX;
    public float playerPosY;
    public float playerPosZ;
    public float lkX;
    public float lkY;
    public int SceneNr;
}
