using System;
using Microsoft.Maps.Unity;
using Microsoft.Geospatial;
using UnityEngine;
using UnityEngine.UI;

public class AccelerometerBehaviour : MonoBehaviour
{
    public Text accText;
    public MapRenderer map;
    public float speed = 0.00015f;

    void Update()
    {
        Vector3 dir = Vector3.zero;
        dir.x = Input.acceleration.x;
        dir.y = Input.acceleration.y;
        dir.z = -Input.acceleration.z;
        accText.text = string.Format("x: {0}, y: {1}, z: {2}", Math.Round(dir.x, 2), Math.Round(dir.y, 2), Math.Round(dir.z, 2));
        map.Center = new LatLon(
            map.Center.LatitudeInDegrees + speed * dir.z,
            map.Center.LongitudeInDegrees + speed * dir.x
        );

    }
}
