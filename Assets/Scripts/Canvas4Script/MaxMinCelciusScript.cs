using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MaxMinCelciusScript : MonoBehaviour {
	public bool knowsWeather;
	private WeatherAPI weather;
	Text tempText;
	// Use this for initialization
	// Use this for initialization
	void Start () {
		knowsWeather = false;
		tempText = GameObject.Find("MinMaxCelcius").GetComponent<Text>();
		weather = WeatherAPI.FindObjectOfType<WeatherAPI>();
	}

	// Update is called once per frame
	void Update () {
		if (!knowsWeather && weather.temp != 0) 
		{
			double temp_min = weather.temp_min - 273.15f;
			int celcius_min = Mathf.RoundToInt((float)temp_min);

			double temp_max = weather.temp_max - 273.15f;
			int celcius_max = Mathf.RoundToInt((float)temp_max);

			tempText.text = celcius_min.ToString() + "°  " + celcius_max.ToString() + "°";
			knowsWeather = true;
		}
	}
}
