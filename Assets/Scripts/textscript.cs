using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class textscript : MonoBehaviour {

    // Use this for initialization
    private WeatherAPI weather;
    Text tempText;

    void Start ()
    {
        tempText = GameObject.Find("taqi").GetComponent<Text>();
        weather = WeatherAPI.FindObjectOfType<WeatherAPI>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //int myaqi = Mathf.RoundToInt((int)weather.aqi);
        //tempText.text = "AQI: " + myaqi.ToString() ;
    }


    public void display()
    {
        int myaqi = Mathf.RoundToInt((int)weather.aqi);
        tempText.text = "AQI: " + myaqi.ToString();
    }
}
