using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateScript : MonoBehaviour
{
    Animator animator;
    Player playerScript;


    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        animator = gameObject.GetComponent<Animator>();
        animator.Play("CrateAnim");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExplodeCrate()
    {
        animator.Play("CrateExplode");
        Invoke("DestroyCrate", 0.4f);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("collision with player");
            playerScript.points += 10;
            playerScript.SavePlayer();
            ExplodeCrate();
        }
    }

    void DestroyCrate()
    {
        Destroy(gameObject);
    }

}
