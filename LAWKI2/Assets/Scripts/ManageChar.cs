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
    public int hp;

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
    //Hidden Stats

    //Resistances
    int cold;
    int heat; //unused until temperature is implemented
    int wet;
    int dry; //unused until temperature is implemented

    int weatherbonus;
    private int chance;
	private int mutationChance = 10;

    //placeholder variables. Mario, please adapt these to the proper variables if you can.
    bool isRaining;
    bool isSnowing;
    bool isSunny;
    bool isCloudy;

    int frameCount = 0;

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
        hp = hpMax;
		hunger = 100;
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

			HP = hpMax;
			HUN =hunger;
			ATK = baseAttack + atk;
			DEF = baseDefense + def;
			SPD = baseSpeed + spd;
			REP = baseRep + rep;
			SZ = baseSize + size;


			text.text = "TYPE: " + type +
				"\nPOPULATION: " + HP +
				"\nHUNGER: " + HUN +
				"\nATTACK: " + ATK +
				"\nDEFENSE: " + DEF +
				"\nSPEED: " + SPD +
				"\nREPRODUCTION: " + REP +
				"\nLIFESPAN: " + SZ;
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

        if (frameCount > 30)
        { //Things to update every 30 frames
            frameCount = 0;
            weatherUpdate();
            calchp();
        }
        else frameCount++;
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


    void weatherUpdate() //climate based mutation
    {
        //Sunny and Cloudy have no effect until temperature is implemented
        if (isRaining)
        {
            if ((int)Random.Range(1, 200) <= mutationChance)
            {
                if (wet < 200)
                    wet++;
            }
            if (wet >= 75)
            { //adapted so well to rain conditions that the species is thriving
                if ((int)Random.Range(1, 1000) <= 2 && hp == hpMax && hunger > 80)
                {
                    weatherbonus++;
                }
            }
            else if ((2 * wet) < dry)
            { //susceptible to rain
                if (hp > 0) hp--;
                if (weatherbonus > 0)
                    weatherbonus--;
            }

        }
        else if (isSnowing)
        {
            if ((int)Random.Range(1, 200) <= mutationChance)
            {
                if (cold < 200)
                    cold++;
            }
            if (cold >= 75)
            { //adapted so well to snowy conditions that the species is thriving
                if ((int)Random.Range(1, 1000) <= 2 && hp == hpMax && hunger > 80)
                {
                    weatherbonus++;
                }
            }
            else if ((2 * cold) < heat)
            { //susceptible to cold
                if (hp > 0) hp--;
                if (weatherbonus > 0)
                    weatherbonus--;
            }

        }
        else
        {//default
            if (weatherbonus > 0)
                weatherbonus--;
        }
    }




    void calchp() //calculate max population/regen.
    {
        int starve = 0;
        int deathrate = 0;
        int bonus = 0;

        if (hunger > 80) //plentiful food
        {
            bonus = def * rep;
        }

        if (hunger <= 30)
        { //starvation/food scarcity
            if (hunger == 0)
            {
                starve = hpMax / 4;
            }
            else
                starve = 300 / hunger;
        }

        deathrate = starve + (50 / (1 + def)) + (50 / (1 + rep)); //Low durability + low birth rate = high death rate. High birth rate + low lifespan = low death rate

        hpMax = 20 + bonus + weatherbonus - deathrate; //final calculation

    }

}