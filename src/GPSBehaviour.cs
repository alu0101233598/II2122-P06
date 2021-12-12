using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Microsoft.Maps.Unity;
using Microsoft.Geospatial;

public class GPSBehaviour : MonoBehaviour
{
    public Text coordinatesText;
    public MapRenderer map;

    IEnumerator Start()
    {
        // Check if the user has location service enabled.
        if (!Input.location.isEnabledByUser)
            yield break;

        // Starts the location service.
        Input.location.Start();

        // Waits until the location service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // If the service didn't initialize in 20 seconds this cancels location service use.
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // If the connection failed this cancels location service use.
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            // If the connection succeeded, this retrieves the device's current location and displays it in the Console window.
            coordinatesText.text = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude;
            map.Center = new LatLon(Input.location.lastData.latitude, Input.location.lastData.longitude);
        }

        // Stops the location service if there is no need to query location updates continuously.
        Input.location.Stop();
    }
}