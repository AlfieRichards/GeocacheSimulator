using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class debugUi : MonoBehaviour
{
    public GameObject _gameManager;
    public AccessGPS _location;
    GameObject _player;
    Player playerScript;

    public TextMeshProUGUI lat;
    public TextMeshProUGUI lon;
    public TextMeshProUGUI posX;
    public TextMeshProUGUI posY;
    public TextMeshProUGUI status;


    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager");
        _location = _gameManager.GetComponent<AccessGPS>();
        playerScript = GetComponent<Player>();
        _player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        lat.text = "Lat: " + Input.location.lastData.latitude.ToString();
        lon.text = "Long: " + Input.location.lastData.longitude.ToString();

        posX.text = "PosX: " + _location.GetLongitudeToX().ToString();
        posY.text = "PosY: " + _location.GetLatitudeToY().ToString();
        status.text = "Connected: " + _location.connected.ToString();
        
    }
}
