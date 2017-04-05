using UnityEngine;
using System.Collections;

public class moveMap : MonoBehaviour
{
    private float latitude = 105;
    private float longitude = 40;
    public bool loadOnStart = true;
    private string url;
    private string qs;
    private HTTP.Request req;

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
        qs = "center=" + HTTP.URL.Encode(string.Format("{0},{1}", latitude, longitude)) + "&zoom=15&size=512x512&scale=2&maptype=terrain&sensor=false";
        //Debug.Log(qs);
        req = new HTTP.Request("GET", url + "?" + qs, true);
        req.Send();
        while (!req.isDone)
            yield return null;
        if (req.exception == null)
        {
            var tex = new Texture2D(512, 512);
            tex.LoadImage(req.response.Bytes);
            GetComponent<Renderer>().material.mainTexture = tex;
            Update();
        }
    }
}
