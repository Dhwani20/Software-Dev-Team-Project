using UnityEngine;
using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
/// <summary>
/// This script controls the the weather, through the dark sky api, and the characters movement, through the google staticmaps api.
/// </summary>
public class timer2 : MonoBehaviour {
    /// <summary>
    /// Member to determine if test cases execute.
    /// </summary>
    public bool Testing = false;
    /// <summary>
    /// Member to organize time
    /// </summary>
	public Text timerLabel;
    /// <summary>
    /// Member that holds the character models.
    /// </summary>
	public Sprite[] playerSpriteArr;
    /// <summary>
    /// Member to hold sunny icon.
    /// </summary>
	public GameObject sunnyPanel;
    /// <summary>
    /// Member to hold cloudy icon.
    /// </summary>
	public GameObject cloudyPanel;
    /// <summary>
    /// Memeber to hold rainy icon.
    /// </summary>
	public GameObject rainyPanel;
    /// <summary>
    /// Member to hold snowy icon.
    /// </summary>
	public GameObject snowyPanel;
    /// <summary>
    /// Member to hold weather error icon
    /// </summary>
	public GameObject errorPanel;

    /// <summary>
    /// Member to hold text value of latitude and longitude of player.
    /// </summary>
	public Text text;
    /// <summary>
    /// Member to hold numerical value of longitude of player.
    /// </summary>
	public float longitude = -105.0f;
    /// <summary>
    /// Member to hold numerical value of latitude of player.
    /// </summary>
	public float latitude = 40.0f;
    private float diff = 0.01f;
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

    /// <summary>
    /// Initializes the url for the darksky api and determines if testing occurs or if application runs normally.
    /// </summary>
    void Start()
    {
        url = "https://api.darksky.net/forecast/85e91ef04de9e5708cec369d78fc5f5f/" + string.Format("{0},{1}", latitude, longitude);

        if (Testing)
        {
            sunnyPanel.SetActive(true);
            StartCoroutine(Test());
        }

        StartCoroutine(_UpdateMap());
        StartCoroutine(_UpdateWeather());

        text.text = "Lat: " + latitude +
            "\nLong: " + longitude;
    }

    /// <summary>
    /// Takes care of the automated test cases.
    /// </summary>
	IEnumerator Test()
    {
        yield return new WaitForSeconds(5);
        ClearSprite();
        cloudyPanel.SetActive(true);
        if (cloudyPanel.activeSelf) Debug.Log("weather sprite set successful");
        else Debug.Log("weather sprite set fail");
        latitude = latitude + diff;
        StartCoroutine(_UpdateMap());
        if (latitude == 40.01f) Debug.Log("move success");
        else Debug.Log("move failed");
        yield return new WaitForSeconds(3);
        latitude = latitude - diff;
        StartCoroutine(_UpdateMap());
        if (latitude == 40.0f) Debug.Log("move success");
        else Debug.Log("move failed");
        yield return new WaitForSeconds(4);

        ClearSprite();
        rainyPanel.SetActive(true);
        if (rainyPanel.activeSelf) Debug.Log("weather sprite set successful");
        else Debug.Log("weather sprite set fail");
        longitude = longitude + diff;
        StartCoroutine(_UpdateMap());
        if (longitude == -104.99f) Debug.Log("move success");
        else Debug.Log("move failed");
        yield return new WaitForSeconds(3);
        longitude = longitude - diff;
        StartCoroutine(_UpdateMap());
        if (longitude == -105.0f) Debug.Log("move success");
        else Debug.Log("move failed");
        yield return new WaitForSeconds(4);

        ClearSprite();
        snowyPanel.SetActive(true);
        if (snowyPanel.activeSelf) Debug.Log("weather sprite set successful");
        else Debug.Log("weather sprite set fail");
        yield return new WaitForSeconds(4);

        ClearSprite();
        rainyPanel.SetActive(true);
        if (rainyPanel.activeSelf) Debug.Log("weather sprite set successful");
        else Debug.Log("weather sprite set fail");
        longitude = longitude + diff;
        StartCoroutine(_UpdateMap());
        if (longitude == -104.99f) Debug.Log("move success");
        else Debug.Log("move failed");
        yield return new WaitForSeconds(3);
        longitude = longitude - diff;
        StartCoroutine(_UpdateMap());
        if (longitude == -105.0f) Debug.Log("move success");
        else Debug.Log("move failed");
        yield return new WaitForSeconds(4);

        ClearSprite();
        cloudyPanel.SetActive(true);
        if (cloudyPanel.activeSelf) Debug.Log("weather sprite set successful");
        else Debug.Log("weather sprite set fail");
        latitude = latitude + diff;
        StartCoroutine(_UpdateMap());
        if (latitude == 40.01f) Debug.Log("move success");
        else Debug.Log("move failed");
        yield return new WaitForSeconds(3);
        latitude = latitude - diff;
        StartCoroutine(_UpdateMap());
        if (latitude == 40.0f) Debug.Log("move success");
        else Debug.Log("move failed");
        yield return new WaitForSeconds(4);

        ClearSprite();
        sunnyPanel.SetActive(true);
        if (sunnyPanel.activeSelf) Debug.Log("weather sprite set successful");
        else Debug.Log("weather sprite set fail");

    }

    /// <summary>
    /// Executes each frame to ensure update of character movement and weather.
    /// </summary>
	void Update()
    {
        time += Time.deltaTime;

        var minutes = time / 60;
        var seconds = time % 60;
        var fraction = (time * 100) % 100;


        timerLabel.text = string.Format("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);


        if (seconds % 20 == 0)
        {
            StartCoroutine(_UpdateWeather());
        }


        StartCoroutine(_UpdateMap());

    }

    /// <summary>
    /// Calls the dark sky api each time it executes to update weather information.
    /// </summary>
	IEnumerator _UpdateWeather()
    {
        url = "https://api.darksky.net/forecast/85e91ef04de9e5708cec369d78fc5f5f/" + string.Format("{0},{1}", latitude, longitude);
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


        sunnyPanel.SetActive(false);
        cloudyPanel.SetActive(false);
        rainyPanel.SetActive(false);
        snowyPanel.SetActive(false);
        errorPanel.SetActive(false);

        if (weather == "clear-day" || weather == "clear-night" || weather == "wind")
        {
            sunnyPanel.SetActive(true);
        }
        else if (weather == "cloudy" || weather == "fog" || weather == "partly-cloudy-day" || weather == "partly-cloudy-night")
        {
            cloudyPanel.SetActive(true);
        }
        else if (weather == "rain" || weather == "sleet")
        {
            rainyPanel.SetActive(true);
        }
        else if (weather == "snow")
        {
            snowyPanel.SetActive(true);
        }
        else
            errorPanel.SetActive(true);

    }

    /// <summary>
    /// Calls the google staticmaps api each time it executes to update player movement information.
    /// </summary>
	IEnumerator _UpdateMap()
    {

        MapUrl = "http://maps.googleapis.com/maps/api/staticmap";
        qs = "center=" + WWW.UnEscapeURL(string.Format("{0},{1}", latitude, longitude)) + "&zoom=15&size=512x512&scale=2&maptype=satellite&sensor=false";
        req = new WWW(MapUrl + "?" + qs);
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

    /// <summary>
    /// Called to move character left.
    /// </summary>
    public void MoveMeLeft()
	{
		longitude = longitude - diff;
		
		StartCoroutine(_UpdateMap());
		StartCoroutine(_UpdateWeather());
	}
    /// <summary>
    /// Called to move character right.
    /// </summary>
    public void MoveMeRight()
	{
		longitude = longitude + diff;
		
		StartCoroutine(_UpdateMap());
		StartCoroutine(_UpdateWeather());
	}
    /// <summary>
    /// Called to move character up.
    /// </summary>
    public void MoveMeFwd()
	{
		latitude = latitude + diff;
		
		StartCoroutine(_UpdateMap());
		StartCoroutine(_UpdateWeather());
	}
    /// <summary>
    /// Called to move character down..
    /// </summary>
    public void MoveMeBwd()
	{
		latitude = latitude - diff;
		
		StartCoroutine(_UpdateMap());
		StartCoroutine(_UpdateWeather());
	}
    /// <summary>
    /// Is called before setting a new weather icon in the game.
    /// </summary>
    void ClearSprite ()
	{
		sunnyPanel.SetActive (false);
		cloudyPanel.SetActive (false);
		rainyPanel.SetActive (false);
		snowyPanel.SetActive (false);
	}
}