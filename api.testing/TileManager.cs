using UnityEngine;
//using Assets.Helpers;
using System;
using System.Collections;

public class TileManager : MonoBehaviour {

    [SerializeField]
    private Settings _settings;

    [SerializeField]
    private Texture2D texture;
    private GameObject tile;

    private float lat, lon;

    IEnumerator Start () {
        while (!Input.location.isEnabledByUser)
        {
            yield return new WaitForSeconds(1f);
        }

        Input.location.Start(10f, 5f);

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1f);
            maxWait--;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            yield break;
        } else
        {
            lat = Input.location.lastData.latitude;
            lon = Input.location.lastData.longitude;
        }

        StartCoroutine(loadTiles(_settings.zoom));

        while (Input.location.isEnabledByUser)
        {
            yield return new WaitForSeconds(1f);
        }

        yield return new WaitForSeconds(1f);

            
	}

    IEnumerator loadTiles (int zoom)
    {
        lat = Input.location.lastData.latitude;
        lon = Input.location.lastData.longitude;

        string url = String.format("https://api.mapbox.com/v4/mapbox.{5}/{0},{1},{2}/{3}@2x.png?access_token={4}", lon, lat, zoom, _settings.size, _settings.key, _settings.style);

        WWW www = new WWW(url);
        yield return www;

        texture = www.texture;

        if (tile == null)
        {
            tile = GameObject.CreatePrimitive(PrimitiveType.Plane);
            tile.transform.localScale = Vector3.one * _settings.scale;
            tile.GetComponent<Renderer>().material = _settings.material;
            tile.transform.parent = transform;

        }
        tile.GetComponent<Renderer> ().material.mainTexture = texture;

        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(loadTiles(_settings.zoom));

    }
	
	void Update () {
		
	}


