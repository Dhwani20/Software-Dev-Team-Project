using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestingSprites : MonoBehaviour {
	public GameObject[] playerSpriteArr;
	public GameObject[] selectCharArr;
	public Text text;

	private string type;

	private int baseHP;
	private int baseHunger;
	private int baseAttack;
	private int baseDefense;
	private int baseSpeed;
	private int baseRep;
	private int baseSize;

	private int hpMax; //Max Population (Health) this stat's value will ideally be determined based on a calculation involving the other stats + environmental factors. That aspect has not yet been implemented since this is mostly meant to test mutation behavior.
	private int hunger;
	private int atk;
	private int def;
	private int spd;
	private int rep;
	private int size;

	private int HP;
	private int HUN;
	private int ATK;
	private int DEF;
	private int SPD;
	private int REP;
	private int SZ;

	private int chance;
	private int mutationChance = 10;

	private SelectChar selectChar;										//Reference to ShowPanels script on UI GameObject, to show and hide panels
	private int myCount;

	void Awake () {
		//Get a reference to ShowPanels attached to UI object
		selectChar = GetComponent<SelectChar> ();
	}

	// Use this for initialization
	void Start () {
		myCount = selectChar.getCount ();
		playerSpriteArr [myCount].SetActive (true);

		hpMax = 20;
		hunger = 1;
		atk = 1;                
		def = 1;                
		spd = 1;                
		rep = 2;                
		size = 1;

		//playerSpriteArr [2].SetActive (true);

		type = "Eukaryote";
		baseHP = 100;
		baseHunger = 100;
		baseAttack = 50;
		baseDefense = 50;
		baseSpeed = 10;
		baseRep = 10;
		baseSize = 10;
	}

	// Update is called once per frame
	void FixedUpdate () {

		if ((int)Random.Range (1, 100) <= mutationChance) { //chance to mutate is Mutation Chance / 200
			if (Random.Range (1, 100) < 50) { //50-50 chance to be a negative mutation
				chance = 1;
			} else
				chance = 0;
			Mutate (chance); //once mutation chance is determined, mutate.
		}
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Alpha1)) {//checks for valid keys.
			//spriteIndex = 1;
			ClearSprite();
			playerSpriteArr [1].SetActive (true);

			type = "Bacteria";
			baseHP = 100;
			baseHunger = 100;
			baseAttack = 50;
			baseDefense = 20;
			baseSpeed = 20;
			baseRep = 60;
			baseSize = 1;

		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			//spriteIndex = 2;
			ClearSprite();
			playerSpriteArr [2].SetActive (true);

			type = "Eukaryote";
			baseHP = 100;
			baseHunger = 100;
			baseAttack = 50;
			baseDefense = 50;
			baseSpeed = 10;
			baseRep = 10;
			baseSize = 10;

		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			//spriteIndex = 3;
			ClearSprite();
			playerSpriteArr [3].SetActive (true);

			type = "Alge";
			baseHP = 100;
			baseHunger = 100;
			baseAttack = 50;
			baseDefense = 30;
			baseSpeed = 20;
			baseRep = 20;
			baseSize = 6;
		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			//spriteIndex = 4;
			ClearSprite();
			playerSpriteArr [4].SetActive (true);

			type = "Protozoa";
			baseHP = 100;
			baseHunger = 100;
			baseAttack = 50;
			baseDefense = 40;
			baseSpeed = 20;
			baseRep = 30;
			baseSize = 6;
		} else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			//spriteIndex = 5;
			ClearSprite();
			playerSpriteArr [5].SetActive (true);

			type = "Protozoa";
			baseHP = 100;
			baseHunger = 100;
			baseAttack = 50;
			baseDefense = 30;
			baseSpeed = 30;
			baseRep = 30;
			baseSize = 6;

		} else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			//spriteIndex = 6;
			ClearSprite();
			playerSpriteArr [6].SetActive (true);

			type = "Bacteria";
			baseHP = 100;
			baseHunger = 100;
			baseAttack = 50;
			baseDefense = 20;
			baseSpeed = 50;
			baseRep = 60;
			baseSize = 1;

		} else if (Input.anyKeyDown && !(Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1) || Input.GetMouseButtonDown (2) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.R))) {  //sends error for invalid keys.
			//spriteIndex = 0;
			ClearSprite();
			playerSpriteArr [0].SetActive (true);

			type = "";
			baseHP = 0;
			baseHunger = 0;
			baseAttack = 0;
			baseDefense = 0;
			baseSpeed = 0;
			baseRep = 60;
			baseSize = 0;

		}

		HP = baseHP;
		HUN = baseHunger + hunger;
		ATK = baseAttack + atk;
		DEF = baseDefense + def;
		SPD = baseSpeed + spd;
		REP = baseRep + rep;
		SZ = baseSize + size;


		text.text = "TYPE: " + type +
			"\nHEALTH: " + HP +
			"\nHUNGER: " + HUN +
			"\nATTACK: " + ATK + 
			"\nDEFENSE: " + DEF + 
			"\nSPEED: " + SPD +
			"\nREPRODUCTION: " + REP +
			"\nSIZE: " + SZ;

	}

	void ClearSprite ()
	{
		for (int i = 0; i < 7; i++) {
			playerSpriteArr [i].SetActive (false);
		}
	}


	void Mutate(int isNegative) 
	{ //mutation
		switch ((int)Random.Range(1, 5)) {
		case 1: //atk
			if (isNegative == 1)
			{
				atk -= 2;
				if (atk < 1) atk = 1;
			}
			else
				atk += 2;
			break;
		case 2: //def
			if (isNegative == 1)
			{
				def -= 2;
				if (def < 0) def = 0;
			}
			else
				def += 2;
			break;
		case 3: //spd
			if (isNegative == 1){
				spd -= 2;
				if (spd < 0)
						spd = 0;
			}
			else
				spd += 2;
			break;
		case 4: //size
			if (isNegative == 1){
				size -= 1;
				if (size <= 0)
					size = 1;
			}
			else
				size += 1;
			break;

		}
	}
}