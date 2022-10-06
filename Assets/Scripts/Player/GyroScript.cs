using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroScript : MonoBehaviour
{
    float tiltAngle;
    // Start is called before the first frame update
    void Start()
    {
        
        Input.gyro.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        tiltAngle = -Input.gyro.attitude.z;
        Physics2D.gravity = new Vector2(tiltAngle, 0);
    }
}
