using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	//public GameObject loadingImage;
	public int nextLevel;

	//public void LoadScene(int level)
	public void LoadScene()
	{
		//loadingImage.SetActive(true);
		//Application.LoadLevel(level);
		Application.LoadLevel(nextLevel);
	}
}
