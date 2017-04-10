mapsTes

Project tested the functionality of a GoogleMaps script acquired from the web.
The instances of "HTTP" in the original script had to be changed to "WWW.UnEscapeURL" and the end of the IEnumerator _Refresh function was changed to the following:
"var req = new WWW (url + "?" + qs);
		yield return req;
		GetComponent<Renderer>().material.mainTexture = req.texture;"


After these alterations, the GoogleMap.cs script properly displayed a map onto cube and sphere objects when applied. These alterations may be Mac specific.
The script allows maps to be in street, terrain, or hybrid format.

FURTHER DIRECTIONS:
Apply the map to a flat object such as a Terrain or a plane object to use as our ground.
Customize the map to simplify the image and to make it fit our nature theme.
Gather and update location data via Android.

Developed with Unity
Tested on Android and Mac. Alterations may or may not be Mac specific
REFERENCES:
	Google maps
	Stack Overflow
