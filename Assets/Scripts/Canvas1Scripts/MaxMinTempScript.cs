using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MaxMinTempScript : MonoBehaviour {
	public bool knowsWeather;
	private WeatherAPI weather;
	Text tempText;
	// Use this for initialization
	// Use this for initialization
	void Start () {
		knowsWeather = false;
		tempText = GameObject.Find("MinMaxTemp").GetComponent<Text>();
		weather = WeatherAPI.FindObjectOfType<WeatherAPI>();
	}

	// Update is called once per frame
	void Update () {
		if (!knowsWeather && weather.temp != 0) 
		{
			double temp_min = (weather.temp_min * 9 / 5) - 459.67;
			int farentheight_min = Mathf.RoundToInt((float)temp_min);

			double temp_max = (weather.temp_max * 9 / 5) - 459.67;
			int farentheight_max = Mathf.RoundToInt((float)temp_max);

			tempText.text = farentheight_min.ToString() + "°  " + farentheight_max.ToString() + "°";
			knowsWeather = true;
		}
	}
}
