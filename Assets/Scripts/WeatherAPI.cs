using UnityEngine;
using System.Collections;
using SimpleJSON;
using UnityEngine.Networking;


public class WeatherAPI : MonoBehaviour {

    //public string url = "http://api.openweathermap.org/data/2.5/weather?q=melbourne&APPID=09c983f6e8fc5eebb04bfe1cf1b42e27";
    //public string url = "http://api.openweathermap.org/data/2.5/weather?id=2158177&APPID=446e2655762a7411c97c9da1916d5c96";
    //public string url = "http://api.openweathermap.org/data/2.5/weather?lat=12.9716&lon=77.5946&APPID=446e2655762a7411c97c9da1916d5c96";

    public ParticleSystem particleLauncher;
    public ParticleSystem particleLauncher1;
    public GameObject swipy;

    public GameObject cuby;


    public string city;
	public string country;
	public string weatherDescription;
	public float temp;
	public float temp_min;
	public float temp_max;
	public float rain;
	public float wind;
	public float clouds;

    public GameObject y20;
    public GameObject y19;



    public float aqi;


    // Use this for initialization
    IEnumerator Start () {
		//WWW request = new WWW(url);
		//yield return request;

        UnityWebRequest lalala = UnityWebRequest.Get("https://api.breezometer.com/air-quality/v2/current-conditions?lat=-37.8136&lon=144.9631&key=c750f0c3b1674a7bab19dde8f3e6d176&features=breezometer_aqi,local_aqi");
        yield return lalala.SendWebRequest();

        /*
        if (request.error == null || request.error == "") 
		{
			setWeatherAttributes(request.text);
            Debug.Log("blahhhh");
		} 
		else 
		{
			Debug.Log("Error: " + request.error);
		}
        */

        if (lalala.isNetworkError || lalala.isHttpError)
        {
            Debug.Log(lalala.error);
        }
        else
        {
            // Show results as text
            setPollutionAttributes(lalala.downloadHandler.text);
           
            Debug.Log(" Result:  "+lalala.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = lalala.downloadHandler.data;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}

	void setWeatherAttributes(string jsonString) {
		var weatherJson = JSON.Parse(jsonString);
		city = weatherJson["name"].Value;
        Debug.Log("city" + city);

        country = weatherJson["sys"]["country"].Value;
		weatherDescription = weatherJson["weather"][0]["description"].Value;
		temp = weatherJson["main"]["temp"].AsFloat;
		temp_min = weatherJson["main"]["temp_min"].AsFloat;
		temp_max = weatherJson["main"]["temp_max"].AsFloat;
		rain = weatherJson["rain"]["3h"].AsFloat;
		clouds = weatherJson["clouds"]["all"].AsInt;
		wind = weatherJson["wind"]["speed"].AsFloat;
	}


    void setPollutionAttributes(string jsonString)
    {
        var pollJson = JSON.Parse(jsonString);
        aqi = pollJson["data"]["indexes"]["baqi"]["aqi"].AsFloat;
        Debug.Log("The Air Quality Index of Melb is: " + aqi);
    }

    public void emitter()
    {
        particleLauncher.Emit((int)aqi*20);
        particleLauncher1.Emit((int)aqi * 80);

        Destroy(cuby);
     


    }
    private void OnMouseDown()
    {
        particleLauncher.Emit((int)aqi);
        Destroy(cuby);
    }








    private void Awake()
    {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }

    private void SwipeDetector_OnSwipe(SwipeData data)
    {
        Debug.Log("Swipe in Direction: " + data.Direction);
        if (data.Direction == SwipeDirection.Left)
        {
            //2019
            Debug.Log("yeeee it works");
            //particleLauncher.Emit((int)aqi * 20);
            particleLauncher.Emit(1000);

            //particleLauncher1.Emit((int)aqi * 80);
            y19.SetActive(true);
            y20.SetActive(false);
            swipy.SetActive(false);


        }

        if (data.Direction == SwipeDirection.Right)
        {
            //2020
            Debug.Log("yeeee it works");
            particleLauncher.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            particleLauncher1.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            particleLauncher.Emit(600);

            //particleLauncher.Emit((int)aqi);
            //particleLauncher1.Emit((int)aqi);
            y19.SetActive(false);
            y20.SetActive(true);
            swipy.SetActive(false);

        }
    }


}

//EXAMPLE RESPONSE OBJECT
//{"coord":{"lon":139,"lat":35},
//	"sys":{"country":"JP","sunrise":1369769524,"sunset":1369821049},
//	"weather":[{"id":804,"main":"clouds","description":"overcast clouds","icon":"04n"}],
//	"main":{"temp":289.5,"humidity":89,"pressure":1013,"temp_min":287.04,"temp_max":292.04},
//	"wind":{"speed":7.31,"deg":187.002},
//	"rain":{"3h":0},
//	"clouds":{"all":92},
//	"dt":1369824698,
//	"id":1851632,
//	"name":"Shuzenji",
//	"cod":200}