using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class moveMapButtons : MonoBehaviour
{
	public Text text;
	private float latitude = 105.0f;
	private float longitude = 40.0f;
	private float diff = 1.0f;
	public bool loadOnStart = true;
	private string url;
	private string qs;
	private WWW req;

	//public float moveSpeed = 10f;
	//public float turnSpeed = 50f;
	private bool moveLeft;
	private bool moveRight;
	private bool moveFwd;
	private bool moveBwd;


	void Start()
	{
		if (loadOnStart)
		{
			StartCoroutine(_Update());
		}
		moveLeft = false;
		moveRight = false;
		moveFwd = false;
		moveBwd = false;

		text.text = "Lat: " + latitude +
			"\nLong: " + longitude;

	}

	public void Update()
	{
		if (/*(moveFwd && !moveBwd) || */Input.GetKey(KeyCode.UpArrow))
		{
			Debug.Log("up arrow key is held down");
			MoveMeFwd ();
			//latitude = latitude + 1;
			//StartCoroutine(_Update());
		}

		if (/*(moveBwd && !moveFwd) || */Input.GetKey(KeyCode.DownArrow))
		{
			Debug.Log("down arrow key is held down");
			MoveMeBwd ();
			//latitude = latitude - 1;
			//StartCoroutine(_Update());
		}

		if (/*(moveRight && !moveLeft) || */Input.GetKey(KeyCode.RightArrow))
		{
			Debug.Log("right arrow key is held down");
			MoveMeRight ();
			//longitude = longitude + 1;
			//StartCoroutine(_Update());
		}

		if (/*(moveLeft && !moveRight) || */Input.GetKey(KeyCode.LeftArrow))
		{
			Debug.Log("left arrow key is held down");
			MoveMeLeft ();
			//longitude = longitude - 1;
			//StartCoroutine(_Update());
		}

	}

	IEnumerator _Update()
	{
		Debug.Log("Entered IEnumerator");
		url = "http://maps.googleapis.com/maps/api/staticmap";
		qs = "center=" + WWW.UnEscapeURL(string.Format("{0},{1}", latitude, longitude)) + "&zoom=15&size=512x512&scale=2&maptype=terrain&sensor=false";
		//Debug.Log(qs);
		req = new WWW (url + "?" + qs);
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
		//moveLeft = true;
		Debug.Log("left arrow key is held down");
		longitude = longitude - diff;
		StartCoroutine(_Update());
	}

	public void MoveMeRight()
	{
		//moveRight = true;
		Debug.Log("right arrow key is held down");
		longitude = longitude + diff;
		StartCoroutine(_Update());
	}

	public void MoveMeFwd()
	{
		//moveFwd = true;
		Debug.Log("up arrow key is held down");
		latitude = latitude + diff;
		StartCoroutine(_Update());
	}

	public void MoveMeBwd()
	{
		//moveBwd = true;
		Debug.Log("down arrow key is held down");
		latitude = latitude - diff;
		StartCoroutine(_Update());
	}
}
