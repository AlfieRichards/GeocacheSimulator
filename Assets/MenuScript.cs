using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public GameObject _gameManager;
    public AccessGPS _location;
    Player playerScript;
    public TextMeshProUGUI pointsUiElement;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager");
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //pointsUiElement.text = playerScript.points.ToString();
        pointsUiElement.text = "You Have Collected: \n" + playerScript.points + " Crates";
    }
}
