using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

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
    CharacterController characterController;

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

        characterController = FindObjectOfType<CharacterController>();
        cameraController = FindObjectOfType<CameraController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Delete();
        }
    }

    public void Save()
    {
        saveLoad.playerPositionX = characterController.transform.position.x;
        saveLoad.playerPositionY = characterController.transform.position.y;
        saveLoad.playerPositionZ = characterController.transform.position.z;
        saveLoad.lookX = cameraController.getLook().x;
        saveLoad.lookY = cameraController.getLook().y;
        saveLoad.sceneNumber = SceneManager.GetActiveScene().buildIndex;


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
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
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

            if (SceneManager.GetActiveScene().buildIndex != saveLoad.sceneNumber)
            {
                SceneHandler.ChangeScene(SaveLoad.saveLoad.sceneNumber);
            }
            else
            {
                characterController.transform.position = new Vector3
                (
                    saveLoad.playerPositionX,
                    saveLoad.playerPositionY,
                    saveLoad.playerPositionZ
                );
                cameraController.setLook(new Vector2(saveLoad.lookX, saveLoad.lookY));
            }
        }
    }

    public void Delete()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            File.Delete(Application.persistentDataPath + "/playerInfo.dat");
        }
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
