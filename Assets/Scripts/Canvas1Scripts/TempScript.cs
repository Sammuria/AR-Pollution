using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TempScript : MonoBehaviour {
	public bool knowsWeather;
	private WeatherAPI weather;
	Text tempText;
	// Use this for initialization
	// Use this for initialization
	void Start () {
		knowsWeather = false;
		tempText = GameObject.Find("Temp").GetComponent<Text>();
		weather = WeatherAPI.FindObjectOfType<WeatherAPI>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!knowsWeather && weather.temp != 0) 
		{
			double temp = (weather.temp * 9 / 5) - 459.67;
			int farentheight = Mathf.RoundToInt((float)temp);
			tempText.text = farentheight.ToString() + "°F";
			knowsWeather = true;
		}
	}
}
