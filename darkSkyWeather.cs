using UnityEngine;
using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class timer : MonoBehaviour {
	public Text timerLabel;
	public Sprite[] playerSpriteArr;

	public GameObject sunnyPanel;
	public GameObject cloudyPanel;
	public GameObject rainyPanel;
	public GameObject snowyPanel;
	public GameObject errorPanel;

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
        url = "https://api.forecast.io/forecast/85e91ef04de9e5708cec369d78fc5f5f/40.014984,-105.270546";
        StartCoroutine(_Update());
    }

    void Update()
    {
        StartCoroutine(_Update());
    }

	IEnumerator _Update()
	{
        //Debug.Log("weather update");
        WWW www = new WWW(url);
        yield return www;
        if (www.error == null)
        {
            JsonData jsonvale = JsonMapper.ToObject(www.text);
            weather = jsonvale["currently"]["icon"].ToString();
        }
        else
        {
            Debug.Log("ERROR: " + www.error);
        }
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
}
