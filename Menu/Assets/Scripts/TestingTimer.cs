using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestingTimer : MonoBehaviour {
	public GameObject[] weatherSpriteArr;

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Alpha1)) {//checks for valid keys.
			//spriteIndex = 1;
			ClearSprite();
			weatherSpriteArr [1].SetActive (true);

		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			//spriteIndex = 2;
			ClearSprite();
			weatherSpriteArr [2].SetActive (true);


		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			//spriteIndex = 3;
			ClearSprite();
			weatherSpriteArr [3].SetActive (true);

		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			//spriteIndex = 4;
			ClearSprite();
			weatherSpriteArr [4].SetActive (true);


		} else if (Input.anyKeyDown && !(Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1) || Input.GetMouseButtonDown (2))) {  //sends error for invalid keys.
			//spriteIndex = 0;
			ClearSprite();
			weatherSpriteArr [0].SetActive (true);

		}
	}

	void ClearSprite ()
	{
		for (int i = 0; i < 5; i++) {
			weatherSpriteArr [i].SetActive (false);
		}
	}
}
