using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CelciusScript : MonoBehaviour {
	public bool knowsWeather;
	private WeatherAPI weather;
	Text tempText;
	// Use this for initialization
	// Use this for initialization
	void Start () {
		knowsWeather = false;
		tempText = GameObject.Find("Celcius").GetComponent<Text>();
		weather = WeatherAPI.FindObjectOfType<WeatherAPI>();
	}

	// Update is called once per frame
	void Update () {
		if (!knowsWeather && weather.temp != 0) 
		{
			double temp = weather.temp - 273.15f;
			int celcius = Mathf.RoundToInt((float)temp);
			tempText.text = celcius.ToString() + "°C";
			knowsWeather = true;
		}
	}
}
