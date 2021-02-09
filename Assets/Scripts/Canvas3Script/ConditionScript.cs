using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConditionScript : MonoBehaviour {
	public bool knowsWeather;
	private WeatherAPI weather;
	Text tempText;
	// Use this for initialization
	// Use this for initialization
	void Start () {
		knowsWeather = false;
		tempText = GameObject.Find("Condition").GetComponent<Text>();
		weather = WeatherAPI.FindObjectOfType<WeatherAPI>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!knowsWeather && weather.temp != 0) 
		{
			tempText.text = weather.weatherDescription;
			knowsWeather = true;
		}
	}
}
