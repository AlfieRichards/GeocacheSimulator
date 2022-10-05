using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateManager : MonoBehaviour
{
    //simple values
    public int points;
    public float[] coordinates = {0f,0f};
    public List<float[]> chests = new List<float[]>();

    public Vector2 topRightCoordinate;
    public Vector2 BottomLeftCoordinate;

    public GameObject cratePrefab;

    void LoadData()
    {
        //finds required components and objects
        GameObject player = GameObject.Find("Player");
        Player playerData = player.GetComponent(typeof(Player)) as Player;

        //imports info
        chests = playerData.chests;
        points = playerData.points;
        coordinates = playerData.coordinates;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(chests.Count == 0)
        {
            Debug.Log("No chests found in save system");
            GenerateChests();
        }
        
    }

    void GenerateChests()
    {
        int cratesAmnt = Random.Range(0,12);
        for(int i = 0; i < cratesAmnt; i++)
        {
            //generates chest location
            float randomX = Random.Range(topRightCoordinate.x, BottomLeftCoordinate.x);
            float randomY = Random.Range(topRightCoordinate.y, BottomLeftCoordinate.y);

            //instantiates chest
            Vector2 finalRandomLoc = new Vector2(randomX, randomY);
            float[] crateLocation = {randomX, randomY};
            chests.Add(crateLocation);
            Instantiate(cratePrefab, finalRandomLoc, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}