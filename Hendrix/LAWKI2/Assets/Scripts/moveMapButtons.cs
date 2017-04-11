using UnityEngine;
using System.Collections;

public class moveMapButtons : MonoBehaviour
{
	private float latitude = 105;
	private float longitude = 40;
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

	}

	public void Update()
	{
		/*if ((moveFwd && !moveBwd) || Input.GetKey(KeyCode.UpArrow))
		{
			Debug.Log("up arrow key is held down");
			latitude = latitude + 1;
			StartCoroutine(_Update());
		}

		if ((moveBwd && !moveFwd) || Input.GetKey(KeyCode.DownArrow))
		{
			Debug.Log("down arrow key is held down");
			latitude = latitude - 1;
			StartCoroutine(_Update());
		}

		if ((moveRight && !moveLeft) || Input.GetKey(KeyCode.RightArrow))
		{
			Debug.Log("right arrow key is held down");
			longitude = longitude + 1;
			StartCoroutine(_Update());
		}

		if ((moveLeft && !moveRight) || Input.GetKey(KeyCode.LeftArrow))
		{
			Debug.Log("left arrow key is held down");
			longitude = longitude - 1;
			StartCoroutine(_Update());
		}*/
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
	}

	public void MoveMeLeft()
	{
		//moveLeft = true;
		Debug.Log("left arrow key is held down");
		longitude = longitude - 1;
		StartCoroutine(_Update());
	}

	public void StopMeLeft()
	{
		//moveLeft = false;
	}
	public void MoveMeRight()
	{
		//moveRight = true;
		Debug.Log("right arrow key is held down");
		longitude = longitude + 1;
		StartCoroutine(_Update());
	}

	public void StopMeRight()
	{
		//moveRight = false;
	}

	public void MoveMeFwd()
	{
		//moveFwd = true;
		Debug.Log("up arrow key is held down");
		latitude = latitude + 1;
		StartCoroutine(_Update());
	}

	public void StopMeFwd()
	{
		//moveFwd = false;
	}

	public void MoveMeBwd()
	{
		//moveBwd = true;
		Debug.Log("down arrow key is held down");
		latitude = latitude - 1;
		StartCoroutine(_Update());
	}

	public void StopMeBwd()
	{
		//moveBwd = false;
	}
}
