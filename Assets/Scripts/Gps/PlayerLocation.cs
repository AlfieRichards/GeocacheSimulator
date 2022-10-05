using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocation : MonoBehaviour
{
    public GameObject _gameManager;
    public AccessGPS _location;
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager");
        _location = _gameManager.GetComponent<AccessGPS>();
        player = this.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        player.transform.position = new Vector2(_location.GetLongitude(),_location.GetLatitude());

    }


}
