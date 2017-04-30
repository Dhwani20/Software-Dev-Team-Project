using UnityEngine;
using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class timer2 : MonoBehaviour {
	public Text timerLabel;
	public Sprite[] playerSpriteArr;

	public GameObject sunnyPanel;
	public GameObject cloudyPanel;
	public GameObject rainyPanel;
	public GameObject snowyPanel;
	public GameObject errorPanel;

	public Text text;
	public float longitude = -105.0f;
	public float latitude = 40.0f;
	private float diff = 1.0f;
	public bool loadOnStart = true;
	private string MapUrl;
	private string qs;
	private WWW req;

	private SpriteRenderer playerSprite;

	private ManageChar manageChar;
	private int counter;

	private float time;
	private float val;
	private int num;

	private float nextActionTime = 0.0f;
	private float period = 2.0f;

	private string url;
	private string weather;

	void Start() {
		//url = "https://api.forecast.io/forecast/85e91ef04de9e5708cec369d78fc5f5f/" + string.Format("{0},{1}", longitude, latitude);//40.014984,-105.270546";
		url = "https://api.darksky.net/forecast/1e4d96dd43b8ad95a631558766bfea4c/" + string.Format("{0},{1}", latitude, longitude);//40.014984,-105.270546";
		//url = "https://api.darksky.net/forecast/85e91ef04de9e5708cec369d78fc5f5f/40,-105";

		Debug.Log(url);

		//_UpdateMap ();

		StartCoroutine(_UpdateMap());
		StartCoroutine(_UpdateWeather());

		text.text = "Lat: " + latitude +
			"\nLong: " + longitude;
	}

	void Update()
	{
		time += Time.deltaTime;

		var minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
		var seconds = time % 60;//Use the euclidean division for the seconds.
		var fraction = (time * 100) % 100;

		//update the label value
		timerLabel.text = string.Format ("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);


		if (seconds % 20 == 0) 
		{
			StartCoroutine(_UpdateWeather());
		}


		//StartCoroutine(_Update());

		StartCoroutine(_UpdateMap());
		//StartCoroutine(_UpdateWeather());

	}


	/*IEnumerator _Update()
	{
		StartCoroutine(_UpdateMap());
		StartCoroutine(_UpdateWeather());
	}*/

	IEnumerator _UpdateWeather()
	{
		
		url = "https://api.darksky.net/forecast/1e4d96dd43b8ad95a631558766bfea4c/" + string.Format("{0},{1}", latitude, longitude);//40.014984,-105.270546";
		Debug.Log("weather: " + url);
		WWW www = new WWW(url);
		yield return www;
		if (www.error == null)
		{
			JsonData jsonvale = JsonMapper.ToObject(www.text);
			weather = jsonvale["currently"]["icon"].ToString();
		}
		else
		{
			Debug.Log("Weather ERROR: " + www.error);
		}
		Debug.Log ("icon: " + weather);
		sunnyPanel.SetActive (false);
		cloudyPanel.SetActive (false);
		rainyPanel.SetActive (false);
		snowyPanel.SetActive (false);
		errorPanel.SetActive (false);

		if (weather == "clear-day" || weather == "clear-night" || weather == "wind") 
		{
			sunnyPanel.SetActive (true);
		} 
		else if (weather == "cloudy" || weather == "fog" || weather == "partly-cloudy-day" || weather == "partly-cloudy-night") 
		{
			cloudyPanel.SetActive (true);
		} 
		else if (weather == "rain" || weather == "sleet") 
		{
			rainyPanel.SetActive (true);
		}
		else if (weather == "snow") {
			snowyPanel.SetActive (true);
		} 
		else
			errorPanel.SetActive (true);

	}

	IEnumerator _UpdateMap()
	{
		Debug.Log("Entered IEnumerator");
		MapUrl = "http://maps.googleapis.com/maps/api/staticmap";
		qs = "center=" + WWW.UnEscapeURL(string.Format("{0},{1}", latitude, longitude)) + "&zoom=15&size=512x512&scale=2&maptype=terrain&sensor=false";
		Debug.Log("qs: " + qs);
		req = new WWW (MapUrl + "?" + qs);
		while (!req.isDone)
			yield return null;
		if (req.isDone)
		{
			GetComponent<Renderer>().material.mainTexture = req.texture;
			Update();
		}
		text.text = "Lat: " + latitude +
			"\nLong: " + longitude;
	}


	public void MoveMeLeft()
	{
		Debug.Log("left arrow key is held down");
		longitude = longitude - diff;
		//StartCoroutine(_Update());
		StartCoroutine(_UpdateMap());
		StartCoroutine(_UpdateWeather());
	}

	public void MoveMeRight()
	{
		Debug.Log("right arrow key is held down");
		longitude = longitude + diff;
		//StartCoroutine(_Update());
		StartCoroutine(_UpdateMap());
		StartCoroutine(_UpdateWeather());
	}

	public void MoveMeFwd()
	{
		Debug.Log("up arrow key is held down");
		latitude = latitude + diff;
		//StartCoroutine(_Update());
		StartCoroutine(_UpdateMap());
		StartCoroutine(_UpdateWeather());
	}

	public void MoveMeBwd()
	{
		Debug.Log("down arrow key is held down");
		latitude = latitude - diff;
		//StartCoroutine(_Update());
		StartCoroutine(_UpdateMap());
		StartCoroutine(_UpdateWeather());
	}
}