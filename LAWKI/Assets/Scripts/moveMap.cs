using UnityEngine;
using System.Collections;

public class moveMap : MonoBehaviour
{
    public bool Testing = false;
    private float latitude = 105;
	private float longitude = 40;
	private string url;
	private string qs;
	private WWW req;

    public void QuitGame()
    {
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    void Start()
	{
        StartCoroutine(_Update());
        if (Testing)
		{
			StartCoroutine(Test());
		}

	}

    IEnumerator Test()
    {
        yield return new WaitForSeconds(3);
        latitude = latitude + 1;
        StartCoroutine(_Update());
        if (latitude == 106) Debug.Log("move success");
        else Debug.Log("move failed");
        yield return new WaitForSeconds(3);
        latitude = latitude - 1;
        StartCoroutine(_Update());
        if (latitude == 105) Debug.Log("move success");
        else Debug.Log("move failed");
        yield return new WaitForSeconds(3);
        longitude = longitude + 1;
        StartCoroutine(_Update());
        if (longitude == 41) Debug.Log("move success");
        else Debug.Log("move failed");
        yield return new WaitForSeconds(3);
        longitude = longitude - 1;
        StartCoroutine(_Update());
        if (longitude == 40) Debug.Log("move success");
        else Debug.Log("move failed");
        yield return new WaitForSeconds(22);
        latitude = latitude + 1;
        StartCoroutine(_Update());
        if (latitude == 106) Debug.Log("move success");
        else Debug.Log("move failed");
        yield return new WaitForSeconds(3);
        latitude = latitude - 1;
        StartCoroutine(_Update());
        if (latitude == 105) Debug.Log("move success");
        else Debug.Log("move failed");
        yield return new WaitForSeconds(3);
        longitude = longitude + 1;
        StartCoroutine(_Update());
        if (longitude == 41) Debug.Log("move success");
        else Debug.Log("move failed");
        yield return new WaitForSeconds(3);
        longitude = longitude - 1;
        StartCoroutine(_Update());
        if (longitude == 40) Debug.Log("move success");
        else Debug.Log("move failed");
        yield return new WaitForSeconds(3);
        QuitGame();
    }

	public void Update()
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{
			//Debug.Log("up arrow key is held down");
			latitude = latitude + 1;
            Debug.Log(latitude);
			StartCoroutine(_Update());
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			//Debug.Log("down arrow key is held down");
			latitude = latitude - 1;
            Debug.Log(latitude);
            StartCoroutine(_Update());
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			//Debug.Log("right arrow key is held down");
			longitude = longitude + 1;
            Debug.Log(longitude);
            StartCoroutine(_Update());
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			//Debug.Log("left arrow key is held down");
			longitude = longitude - 1;
            Debug.Log(longitude);
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
