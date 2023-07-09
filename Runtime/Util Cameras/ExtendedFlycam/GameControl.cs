//https://unity3d.com/learn/tutorials/topics/scripting/persistence-saving-and-loading-data

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//save states
public class GameControl : MonoBehaviour
{
    public static GameControl control;
 
    //camera control
    public float cameraSensitivity;
    public float climbSpeed;
    public bool enableMouseToClimb;
    public float normalMoveSpeed;
    public float slowMoveFactor;
    public float fastMoveFactor;

    // Use this for initialization
    void Awake()
    {
        #region HIGHLANDER LOGIC
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
        #endregion
    }

    public void Save()
    {
        Debug.Log("GameControl.control.Save() being called");
        BinaryFormatter bf;
        FileStream file;


        //CameraControlData
        bf = new BinaryFormatter();
        file = File.Create(Application.persistentDataPath + "/camcontrolInfo.dat");
        CameraControlData cam_data = new CameraControlData();
        cam_data.cameraSensitivity = cameraSensitivity;
        cam_data.climbSpeed = climbSpeed;
        cam_data.enableMouseToClimb = enableMouseToClimb;
        cam_data.normalMoveSpeed = normalMoveSpeed;
        cam_data.slowMoveFactor = slowMoveFactor;
        cam_data.fastMoveFactor = fastMoveFactor;

        bf.Serialize(file, cam_data);
        file.Close();
        Debug.Log("<color=green> SAVED DATA </color>");
    }

    public void Load()
    {
        Debug.Log("GameControl.control.Load() being called");


        if (File.Exists(Application.persistentDataPath + "/camcontrolInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/camcontrolInfo.dat", FileMode.Open);
            CameraControlData cam_data = (CameraControlData)bf.Deserialize(file);
            file.Close();

            cameraSensitivity = cam_data.cameraSensitivity;
            climbSpeed = cam_data.climbSpeed;
            enableMouseToClimb = cam_data.enableMouseToClimb;
            normalMoveSpeed = cam_data.normalMoveSpeed;
            slowMoveFactor = cam_data.slowMoveFactor;
            fastMoveFactor = cam_data.fastMoveFactor;
            Debug.Log("<color=green> LOADED DATA </color>");
        }
    }

}

[Serializable]
class CameraControlData
{
    public float cameraSensitivity;
    public float climbSpeed;
    public bool enableMouseToClimb;
    public float normalMoveSpeed;
    public float slowMoveFactor;
    public float fastMoveFactor;
}