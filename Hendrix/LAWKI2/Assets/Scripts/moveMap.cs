using UnityEngine;
using System.Collections;

public class moveMap : MonoBehaviour
{
	private float latitude = 105;
	private float longitude = 40;
	public bool loadOnStart = true;
	private string url;
	private string qs;
	private WWW req;


	void Start()
	{
		if (loadOnStart)
		{
			StartCoroutine(_Update());
		}

	}

	public void Update()
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{
			Debug.Log("up arrow key is held down");
			latitude = latitude + 1;
			StartCoroutine(_Update());
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			Debug.Log("down arrow key is held down");
			latitude = latitude - 1;
			StartCoroutine(_Update());
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			Debug.Log("right arrow key is held down");
			longitude = longitude + 1;
			StartCoroutine(_Update());
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			Debug.Log("left arrow key is held down");
			longitude = longitude - 1;
			StartCoroutine(_Update());
		}
	}

	IEnumerator _Update()
	{
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
}
