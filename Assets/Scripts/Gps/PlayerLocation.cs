using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocation : MonoBehaviour
{
    public GameObject _gameManager;
    public AccessGPS _location;
    GameObject _player;
    bool debounce = true;
    Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player loc start");
        _gameManager = GameObject.Find("GameManager");
        _location = _gameManager.GetComponent<AccessGPS>();
        playerScript = GetComponent<Player>();
        _player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (_location.connected && debounce)
        {
            debounce = false;
            MovePlayer();
        }
        

    }

    void MovePlayer()
    {
        Debug.Log("Moving player");
        _player.transform.position = new Vector2(_location.GetLongitudeToX(),_location.GetLatitudeToY());
        _player.transform.rotation = Quaternion.Euler(0, _location.GetHeading(), 0);
        playerScript.coordinates[0] = _location.GetLongitudeToX();
        playerScript.coordinates[1] = _location.GetLatitudeToY();
        Invoke("ResetGpsDelay", 5);
        
    }

    void ResetGpsDelay(){
        debounce = true;
    }
}
