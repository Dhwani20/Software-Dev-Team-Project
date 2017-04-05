using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timer : MonoBehaviour {
	public Text timerLabel;
	public Sprite[] playerSpriteArr;
	public Sprite sprite1;

	public GameObject sunnyPanel;
	public GameObject cloudyPanel;
	public GameObject rainyPanel;
	public GameObject snowyPanel;
	public GameObject errorPanel;

	private SpriteRenderer playerSprite;

	private float time;
	private float val;
	private int num;

	private float nextActionTime = 0.0f;
	private float period = 2.0f;

	void Start() {
		sunnyPanel.SetActive (true);

		int num = 2;
		int[] seq = new int[num];
		for (int i = 0; i < seq.Length-1; i++)
			seq [i] = 0;

	}
	
	void Update() {
		time += Time.deltaTime;

		var minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
		var seconds = time % 60;//Use the euclidean division for the seconds.
		var fraction = (time * 100) % 100;

		//update the label value
		timerLabel.text = string.Format ("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);

		if (Time.time > nextActionTime) 
		{
			nextActionTime = nextActionTime + period;

			UpdateWeatherSim ();
		}

	}

	void UpdatePlayerSprite()
	{
		int r = Random.Range (0, num);

		if (r == 1) 
		{
			//playerImage = "01";
		}
		else if (r == 2) 
		{
			//playerImage = "02";
		}
		return;
	}

	void UpdateWeatherSim()
	{
		int r = Random.Range (1, 5);

		sunnyPanel.SetActive (false);
		cloudyPanel.SetActive (false);
		rainyPanel.SetActive (false);
		snowyPanel.SetActive (false);
		errorPanel.SetActive (false);

		if (r == 1) 
		{
			sunnyPanel.SetActive (true);
		} 
		else if (r == 2) 
		{
			cloudyPanel.SetActive (true);
		} 
		else if (r == 3) 
		{
			rainyPanel.SetActive (true);
		}
		else if (r == 4) {
			snowyPanel.SetActive (true);
		} 
		else
			errorPanel.SetActive (true);
			
		return;
	}
}
