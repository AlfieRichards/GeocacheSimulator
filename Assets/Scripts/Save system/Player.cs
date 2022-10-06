using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Player : MonoBehaviour
{
    //simple values
    public int points;
    public float[] coordinates = {0f,0f};
    public List<float[]> chests = new List<float[]>();



    public void SavePlayer()
    {
        GetCoordinates();
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    { 
        PlayerData data = SaveSystem.LoadPlayer();

        coordinates = data.coordinates;
        points = data.points;
        chests = data.chests;
    }

    private void GetCoordinates()
    {
        //finds required components and objects
        GameObject manager = GameObject.Find("GameManager");
        AccessGPS gpsScript = manager.GetComponent(typeof(AccessGPS)) as AccessGPS;

        //adds cords to array
        coordinates[0] = gpsScript.GetLongitudeToX();
        coordinates[1] = gpsScript.GetLatitudeToY();
        Debug.Log(gpsScript.ConvertLongitudeToX(50.791748f));
        Debug.Log(gpsScript.ConvertLatitudeToY(0.273161f));
    }

    private void GetCrates()
    {
        //finds required components and objects
        GameObject manager = GameObject.Find("GameManager");
        CrateManager chestScript = manager.GetComponent(typeof(CrateManager)) as CrateManager;

        chests = chestScript.chests;
    }


    private void Start() 
    {
        FirstLoad();
        Sync();
        //tells us the xyz for our range of lat and long
        GetCoordinates();
    }


    void Sync()
    {
        LoadPlayer();
        SavePlayer();
    }

    void FirstLoad()
    {
        string path = Application.persistentDataPath + "/player.ezeSave";
        if (File.Exists(path))
        {
            LoadPlayer();
        }
        else
        {
            SavePlayer();
        }
    }
}