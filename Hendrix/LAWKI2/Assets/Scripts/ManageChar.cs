using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageChar : MonoBehaviour {
	public GameObject[] playerSpriteArr;
	public GameObject[] playerSpriteArr2;
	public GameObject[] playerSpriteArr3;
	public Text text;
	public int count;

	private int countMax;
	public GameObject[] charTextArr;
	private ShowPanels showPanels;

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

	void Awake(){
		//Get a reference to ShowPanels attached to UI object
		showPanels = GetComponent<ShowPanels> ();
	}

	// Use this for initialization
	void Start () {
		ClearSprite ();
		playerSpriteArr [1].SetActive (false);
		playerSpriteArr2 [1].SetActive (false);
		playerSpriteArr3 [1].SetActive (false);
		charTextArr [1].SetActive(false);
		count = 1;
		playerSpriteArr [count].SetActive (true);
		charTextArr [count].SetActive(true);

		playerSpriteArr2 [count].SetActive (true);
		playerSpriteArr3 [count].SetActive (true);

		type = "Bacteria";
		baseHP = 100;
		baseHunger = 100;
		baseAttack = 50;
		baseDefense = 20;
		baseSpeed = 20;
		baseRep = 60;
		baseSize = 1;

		getBaseStats (count);

		countMax = playerSpriteArr.Length;
		hpMax = 20;
		hunger = 1;
		atk = 1;                
		def = 1;                
		spd = 1;                
		rep = 2;                
		size = 1;
	}

	// Update is called once per frame
	void Update(){
		playerSpriteArr [count].SetActive (true);
		charTextArr [count].SetActive(true);
		playerSpriteArr2 [count].SetActive (true);
		playerSpriteArr3 [count].SetActive (true);

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

	public void increaseCount()
	{
		ClearSprite ();
		count = count + 1;
		if (count == countMax) {
			count = 1;
		}
		getBaseStats (count);

	}

	public void decreaseCount()
	{
		ClearSprite ();
		count = count - 1;
		if (count == 0) {
			count = countMax - 1;
		}
		getBaseStats (count);
	}

	void ClearSprite ()
	{
		for (int i = 0; i < countMax; i++) {
			playerSpriteArr [i].SetActive (false);
			playerSpriteArr2 [i].SetActive (false);
			playerSpriteArr3 [i].SetActive (false);
			charTextArr [i].SetActive (false);
		}
	}

	public void getBaseStats(int myCount)
	{
		switch (myCount) {
		case (1):
			type = "Bacteria";
			baseHP = 100;
			baseHunger = 100;
			baseAttack = 50;
			baseDefense = 20;
			baseSpeed = 20;
			baseRep = 60;
			baseSize = 1;
			break;
		case (2):
			type = "Eukaryote";
			baseHP = 100;
			baseHunger = 100;
			baseAttack = 50;
			baseDefense = 50;
			baseSpeed = 10;
			baseRep = 10;
			baseSize = 10;
			break;
		case (3):
			type = "Alge";
			baseHP = 100;
			baseHunger = 100;
			baseAttack = 50;
			baseDefense = 30;
			baseSpeed = 20;
			baseRep = 20;
			baseSize = 6;
			break;
		case (4):
			type = "Protozoa";
			baseHP = 100;
			baseHunger = 100;
			baseAttack = 50;
			baseDefense = 40;
			baseSpeed = 20;
			baseRep = 30;
			baseSize = 6;
			break;
		case(5):
			type = "Bacteria";
			baseHP = 100;
			baseHunger = 100;
			baseAttack = 50;
			baseDefense = 20;
			baseSpeed = 50;
			baseRep = 60;
			baseSize = 1;
			break;

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

	public int getCount()
	{
		int counter = 5;
		return counter;
	}

}