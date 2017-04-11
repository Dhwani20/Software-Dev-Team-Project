using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestingTimer : MonoBehaviour {
	public GameObject[] weatherSpriteArr;
	//private int org;

	void Start(){
		weatherSpriteArr [1].SetActive (true);
		//org = SelectChar.getCount ();
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Q)) {//checks for valid keys.
			//spriteIndex = 1;
			ClearSprite();
			weatherSpriteArr [1].SetActive (true);

		} else if (Input.GetKeyDown (KeyCode.W)) {
			//spriteIndex = 2;
			ClearSprite();
			weatherSpriteArr [2].SetActive (true);


		} else if (Input.GetKeyDown (KeyCode.E)) {
			//spriteIndex = 3;
			ClearSprite();
			weatherSpriteArr [3].SetActive (true);

		} else if (Input.GetKeyDown (KeyCode.R)) {
			//spriteIndex = 4;
			ClearSprite();
			weatherSpriteArr [4].SetActive (true);


		} else if (Input.anyKeyDown && !(Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1) || Input.GetMouseButtonDown (2) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))) {  //sends error for invalid keys.
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
