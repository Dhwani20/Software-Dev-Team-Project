using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class weatherSim : MonoBehaviour {
	public Text timerLabel;
	//public Sprite[] playerSprite;
	public Sprite[] playerSpriteArr;
	public Sprite sprite1;

	public GameObject sunnyPanel;
	public GameObject cloudyPanel;

	private SpriteRenderer playerSprite;

	private float time;
	private float val;
	private int num;

	//SpriteRenderer sr;

	void Start() {
		int num = 2;
		int[] seq = new int[num];
		for (int i = 0; i < seq.Length-1; i++)
			seq [i] = 0;

		// load all frames in playerSprites array
		//playerSprite = Resources.LoadAll<Sprite> ("Sprites");

		// create the object
		//GameObject organism = new GameObject();
		// add a "SpriteRenderer" component to the newly created object
		//organism.AddComponent<SpriteRenderer>();
		// assign "fruit_9" sprite to it
		//organism.GetComponent<SpriteRenderer>().sprite = playerSprite[2];
		// to assign the 5th frame
		//organism.GetComponent<SpriteRenderer>().sprite = playerSprite[3];

		//sr = GetComponent<SpriteRenderer> ();

		playerSprite = GetComponent<SpriteRenderer> ();
		playerSprite.sprite = playerSpriteArr [3];
		playerSprite.sprite = sprite1;
		if (playerSprite.sprite == null) 
		{
			playerSprite.sprite = playerSpriteArr [0];
		}
	}

	void Update() {
		time += Time.deltaTime;

		var minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
		var seconds = time % 60;//Use the euclidean division for the seconds.
		var fraction = (time * 100) % 100;

		//update the label value
		timerLabel.text = string.Format ("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);

		//sr.color = blue;


		if (seconds % 10 == 0) 
		{
			UpdatePlayerSprite ();
		}
	}

	void UpdatePlayerSprite()
	{
		//sr.sprite = red;
		int r = Random.Range (0, num);

		sunnyPanel.SetActive (false);
		cloudyPanel.SetActive (false);

		if (r == 1) 
		{
			sunnyPanel.SetActive(true);
		}
		else if (r == 2) 
		{
			cloudyPanel.SetActive (true);
		}
		return;
	}
}

