using UnityEngine;
using System.Collections;

public class WeatherCall : MonoBehaviour {
	public string url = "http://api.openweathermap.org/data/2.5/weather?lat=35&lon=139&APPID=446e2655762a7411c97c9da1916d5c96";

	// Use this for initialization
	IEnumerator Start () {
		WWW request = new WWW(url);
		yield return request;

		if (request.error == null || request.error == "") 
		{
			Debug.Log(request.text);
		} 
		else 
		{
			Debug.Log("Error: " + request.error);
		}
	}

	// Update is called once per frame
	void Update () {
	}
}