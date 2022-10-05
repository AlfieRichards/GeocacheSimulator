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
        _gameManager = GameObject.Find("GameManager");
        _location = _gameManager.GetComponent<AccessGPS>();
        playerScript = GetComponent<Player>();
        _player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (debounce)
        {
            debounce = false;
            MovePlayer();
        }
        

    }

    IEnumerator MovePlayer()
    {
        _player.transform.position = new Vector2(_location.GetLongitude(),_location.GetLatitude());
        _player.transform.rotation = Quaternion.Euler(0, _location.GetHeading(), 0);
        yield return new WaitForSeconds(1);
        debounce = true;
        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.tag == "Crate")
        {
            playerScript.points += 10;
            playerScript.SavePlayer();
            Destroy(collision.gameObject);
        }    
    }


}
