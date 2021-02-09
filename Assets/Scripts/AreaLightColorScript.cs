using UnityEngine;
using System.Collections;

public class AreaLightColorScript : MonoBehaviour {
	public bool knowsWeather;
	private WeatherAPI weather;
	public Light lt;
	// Use this for initialization
	void Start () {
		weather = WeatherAPI.FindObjectOfType<WeatherAPI>();
		lt = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!knowsWeather && weather.temp != 0) 
		{
			double temp = (weather.temp * 9 / 5) - 459.67;
			int farentheight = Mathf.RoundToInt((float)temp);
			if (farentheight > 90) {
				lt.color = new Color (239f / 255f, 65f / 255f, 54f / 255f, 1f);
			} else if (farentheight > 75) {
				lt.color = new Color(245f / 255f, 146f / 255f, 33f / 255f, 1f);
			} else if (farentheight > 60) {
				lt.color = new Color(156f / 255f, 189f / 255f, 60f / 255f, 1f);
			} else if (farentheight > 45) {
				lt.color = new Color(80f / 255f, 140f / 255f, 123f / 255f, 1f);
			} else {
				lt.color = new Color(53f / 255f, 167f / 255f, 193f / 255f, 1f);
			}
		}
	}
}
