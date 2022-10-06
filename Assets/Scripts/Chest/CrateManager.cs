using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateManager : MonoBehaviour
{
    //simple values
    public int points;
    public float[] coordinates = {0f,0f};
    public List<float[]> chests = new List<float[]>();
    public float[][] chestsArray;

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

    void saveData()
    {
        //finds required components and objects
        GameObject player = GameObject.Find("Player");
        Player playerData = player.GetComponent(typeof(Player)) as Player;
     
        playerData.SavePlayer();
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadData();
        if(chests.Count == 0)
        {
            Debug.Log("No chests found in save system");
            GenerateChests();
        }
        else
        {
            int i = 0;
            foreach(float[] chest in chests)
            {
                //instantiates chest
                Vector2 finalLoc = new Vector2(chest[0], chest[1]);
                GameObject crate = Instantiate(cratePrefab, finalLoc, Quaternion.identity);
            
                //sets the crate index on the crate script so that we know what it is
                CrateScript script = crate.GetComponent(typeof(CrateScript)) as CrateScript;
                script.crateIndex = i;
                i++;
            }
            //copies the list to an array
            chestsArray = chests.ToArray();
        }
        saveData();
    }

    void GenerateChests()
    {
        int cratesAmnt = Random.Range(0,12);
        for(int i = 0; i < cratesAmnt;)
        {
            //generates chest location
            float randomX = Random.Range(topRightCoordinate.x, BottomLeftCoordinate.x);
            float randomY = Random.Range(topRightCoordinate.y, BottomLeftCoordinate.y);

            //instantiates chest
            Vector2 finalRandomLoc = new Vector2(randomX, randomY);
            float[] crateLocation = {randomX, randomY};
            chests.Add(crateLocation);
            GameObject crate = Instantiate(cratePrefab, finalRandomLoc, Quaternion.identity);
            
            //sets the crate index on the crate script so that we know what it is
            CrateScript script = crate.GetComponent(typeof(CrateScript)) as CrateScript;
            script.crateIndex = i;
            i++;
            saveData();
        }

        //copies the list to an array
        chestsArray = chests.ToArray();
    }

    bool empty = false;
    bool tEmpty = false;
    public void CollectCrate(int index)
    {
        Debug.Log("FUCK: " + index);
        
        if(index >= 0)
        {
            chestsArray[index][0] = 0f;
            chestsArray[index][1] = 0f;
        }
        foreach (float[] tArray in chestsArray)
        {
            foreach(float value in tArray)
            {
                if(value != 0)
                {
                    tEmpty = false;
                }
                else
                {
                    tEmpty = true;
                }
            }
        }
        if(tEmpty){empty = true;}
    }

    // Update is called once per frame
    void Update()
    {
        if(empty)
        {
            Debug.Log("No chests found in save system");
            GenerateChests();
            empty = false;
        }
        
    }
}
