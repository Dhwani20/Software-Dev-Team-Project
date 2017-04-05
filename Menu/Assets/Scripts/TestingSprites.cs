using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestingSprites : MonoBehaviour {
	public GameObject[] playerSpriteArr;
	public Text text;

	private string type;
	private int attack;
	private int defense;
	private int speed;

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Alpha1)) {//checks for valid keys.
			//spriteIndex = 1;
			ClearSprite();
			playerSpriteArr [1].SetActive (true);

			type = "Bacteria";
			attack = 50;
			defense = 20;
			speed = 20;
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			//spriteIndex = 2;
			ClearSprite();
			playerSpriteArr [2].SetActive (true);

			type = "Eukaryote";
			attack = 20;
			defense = 40;
			speed = 10;

		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			//spriteIndex = 3;
			ClearSprite();
			playerSpriteArr [3].SetActive (true);

			type = "Alge";
			attack = 20;
			defense = 30;
			speed = 20;
		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			//spriteIndex = 4;
			ClearSprite();
			playerSpriteArr [4].SetActive (true);

			type = "Protozoa";
			attack = 40;
			defense = 30;
			speed = 30;
		} else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			//spriteIndex = 5;
			ClearSprite();
			playerSpriteArr [5].SetActive (true);

			type = "Protozoa";
			attack = 35;
			defense = 30;
			speed = 15;
		} else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			//spriteIndex = 6;
			ClearSprite();
			playerSpriteArr [6].SetActive (true);

			type = "Bacteria";
			attack = 40;
			defense = 10;
			speed = 50;
		} else if (Input.anyKeyDown && !(Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1) || Input.GetMouseButtonDown (2))) {  //sends error for invalid keys.
			//spriteIndex = 0;
			ClearSprite();
			playerSpriteArr [0].SetActive (true);

			type = "";
			attack = 0;
			defense = 0;
			speed = 0;
		}

		text.text = "TYPE: " + type + "\nATTACK: " + attack + "\nDEFENSE: " + defense + "\nSPEED: " + speed;

	}

	void ClearSprite ()
	{
		for (int i = 0; i < 7; i++) {
			playerSpriteArr [i].SetActive (false);
		}
	}
}
