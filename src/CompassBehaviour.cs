using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassBehaviour : MonoBehaviour
{
    public Text compassText;

    void Start()
    {
        Input.location.Start();
        Input.compass.enabled = true;
    }

    void Update()
    {
        // Orient an object to point to magnetic north.
        transform.rotation = Quaternion.Euler(0, -Input.compass.magneticHeading, 0);
        compassText.text = "Compass: " + -Input.compass.magneticHeading;
    }
}
