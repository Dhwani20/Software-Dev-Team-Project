using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
/// <summary>
/// Script that controls how and when the players character is changed.
/// </summary>
public class ManageChar : MonoBehaviour
{
    /// <summary>
    /// Member to determine if test cases execute.
    /// </summary>
    public bool Testing = false;
    /// <summary>
    /// Member that holds the player character models for the selection screen.
    /// </summary>
	public GameObject[] playerSpriteArr;
    /// <summary>
    /// Member that holds the player character models for the player panel screen.
    /// </summary>
	public GameObject[] playerSpriteArr2;
    /// <summary>
    /// Member that holds the player character models for the map screen.
    /// </summary>
	public GameObject[] playerSpriteArr3;
    /// <summary>
    /// Member that holds text of the player stats.
    /// </summary>
	public Text text;
    /// <summary>
    /// Member that holds the player character model number corresponding to the model in the playerSpriteArr arrays.
    /// </summary>
	public int count;
    /// <summary>
    /// Member used to store player's character hp.
    /// </summary>
	public int hp;

    private int countMax;
    /// <summary>
    /// Member to hold player's character base stats.
    /// </summary>
	public GameObject[] charTextArr;
    private ShowPanels showPanels;
	private timer2 getWeather;

	private string type;

	private int baseHP;
	private int baseHunger;
	private int baseAttack;
	private int baseDefense;
	private int baseSpeed;
	private int baseRep;
	private int baseSize;

	private int hpMax; 
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
	
	int cold;
	int heat; 
	int wet;
	int dry; 

	int weatherbonus;
	private int chance;
	private int mutationChance = 10;

	bool isRaining;
	bool isSnowing;
	bool isSunny;
	bool isCloudy;

	private string weather;

	int frameCount = 0;

	void Awake()
	{
		showPanels = GetComponent<ShowPanels>();
		getWeather = GetComponent<timer2> ();
	}

	void Start()
	{
		ClearSprite();
		playerSpriteArr[1].SetActive(false);
		playerSpriteArr2[1].SetActive(false);
		playerSpriteArr3[1].SetActive(false);
		charTextArr[1].SetActive(false);
		count = 1;
		playerSpriteArr[count].SetActive(true);
		charTextArr[count].SetActive(true);

		playerSpriteArr2[count].SetActive(true);
		playerSpriteArr3[count].SetActive(true);

		type = "Bacteria";
		baseHP = 100;
		baseHunger = 100;
		baseAttack = 50;
		baseDefense = 20;
		baseSpeed = 20;
		baseRep = 60;
		baseSize = 1;

		getBaseStats(count);

		countMax = playerSpriteArr.Length;
		hpMax = 20;
		hp = hpMax;
		hunger = 100;
		atk = 1;
		def = 1;
		spd = 1;
		rep = 2;
		size = 1;

		

		if (Testing) 
		{
			StartCoroutine(Test());
		}

		getWeather = GetComponent<timer2> ();
		if (getWeather.rainyPanel.activeInHierarchy == true)
		{
			isRaining = true;
		}
		else if (getWeather.snowyPanel.activeInHierarchy == true)
		{
			isSnowing = true;
		}

	}
    /// <summary>
    /// Takes care of the automated test cases.
    /// </summary>
    IEnumerator Test()
	{
		yield return new WaitForSeconds (48);
		ClearSprite ();
		count = 2;
		type = "Amoeba";
		yield return new WaitForSeconds(6);
		ClearSprite ();
		count = 3;
		type = "Cocci Bacteria";
		yield return new WaitForSeconds(6);
		ClearSprite();
		count = 4;
		type = "Ciliate Protozoa";
		yield return new WaitForSeconds(6);
		ClearSprite ();
		count = 5;
		type = "Caudovirus";
	}

	
	void Update()
	{
		isRaining = false;
		isSnowing = false;

		getWeather = GetComponent<timer2> ();
		if (getWeather.rainyPanel.activeInHierarchy == true)
		{
			isRaining = true;
		}
		else if (getWeather.snowyPanel.activeInHierarchy == true)
		{
			isSnowing = true;
		}

		playerSpriteArr[count].SetActive(true);
		charTextArr[count].SetActive(true);
		playerSpriteArr2[count].SetActive(true);
		playerSpriteArr3[count].SetActive(true);

		HP = hpMax;
		HUN = hunger;
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

	void FixedUpdate()
	{

		if ((int)Random.Range(1, 100) <= mutationChance)
		{
			if (Random.Range(1, 100) < 50)
			{ 
				chance = 1;
			}
			else
				chance = 0;
			Mutate(chance); 
		}

		if (frameCount > 30)
		{ 
			frameCount = 0;
			weatherUpdate();
			calchp();
		}
		else frameCount++;
	}

    /// <summary>
    /// Used to increase count to change palyer character.
    /// </summary>
    public void increaseCount()
    {
        ClearSprite();
        count = count + 1;
        if (count == countMax)
        {
            count = 1;
        }
        getBaseStats(count);

    }
    /// <summary>
    /// used to decrease cound to change player character.
    /// </summary>
	public void decreaseCount()
    {
        ClearSprite();
        count = count - 1;
        if (count == 0)
        {
            count = countMax - 1;
        }
        getBaseStats(count);
    }

    void ClearSprite()
	{
		for (int i = 0; i < countMax; i++)
		{
			playerSpriteArr[i].SetActive(false);
			playerSpriteArr2[i].SetActive(false);
			playerSpriteArr3[i].SetActive(false);
			charTextArr[i].SetActive(false);
		}
	}
    /// <summary>
    /// Used to get the starting stats of the character the player chooses to start as.
    /// </summary>
	public void getBaseStats(int myCount)
	{
		switch (myCount)
		{
		case (1):
			type = "Bacillus Bacteria";
			baseHP = 100;
			baseHunger = 100;
			baseAttack = 50;
			baseDefense = 20;
			baseSpeed = 20;
			baseRep = 60;
			baseSize = 1;
			break;
		case (2):
			type = "Amoeba";
			baseHP = 100;
			baseHunger = 100;
			baseAttack = 50;
			baseDefense = 50;
			baseSpeed = 10;
			baseRep = 10;
			baseSize = 10;
			break;
		case (3):
			type = "Cocci Bacteria";
			baseHP = 100;
			baseHunger = 100;
			baseAttack = 50;
			baseDefense = 30;
			baseSpeed = 20;
			baseRep = 20;
			baseSize = 6;
			break;
		case (4):
			type = "Ciliate Protozoa";
			baseHP = 100;
			baseHunger = 100;
			baseAttack = 50;
			baseDefense = 40;
			baseSpeed = 20;
			baseRep = 30;
			baseSize = 6;
			break;
		case (5):
			type = "Caudovirus";
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
	{ 
		switch ((int)Random.Range(1, 5))
		{
		case 1: 
			if (isNegative == 1)
			{
				atk -= 2;
				if (atk < 1) atk = 1;
			}
			else
				atk += 2;
			break;
		case 2:
			if (isNegative == 1)
			{
				def -= 2;
				if (def < 0) def = 0;
			}
			else
				def += 2;
			break;
		case 3: 
			if (isNegative == 1)
			{
				spd -= 2;
				if (spd < 0)
					spd = 0;
			}
			else
				spd += 2;
			break;
		case 4:
			if (isNegative == 1)
			{
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


	void weatherUpdate() 
	{
		
		if (isRaining)
		{
			if ((int)Random.Range(1, 200) <= mutationChance)
			{
				if (wet < 200)
					wet++;
			}
			if (wet >= 75)
			{ 
				if ((int)Random.Range(1, 1000) <= 2 && hp == hpMax && hunger > 80)
				{
					weatherbonus++;
				}
			}
			else if ((2 * wet) < dry)
			{
				if (hp > 1) hp--; 
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
			{ 
				if ((int)Random.Range(1, 1000) <= 2 && hp == hpMax && hunger > 80)
				{
					weatherbonus++;
				}
			}
			else if ((2 * cold) < heat)
			{ 
				if (hp > 1) hp--;
				if (weatherbonus > 0)
					weatherbonus--;
			}

		}
		else
		{
			if (weatherbonus > 0)
				weatherbonus--;
		}
	}




	void calchp() 
	{
		int starve = 0;
		int deathrate = 0;
		int bonus = 0;

		if (hunger > 80)
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

		deathrate = starve + (50 / (1 + def)) + (50 / (1 + rep));

		hpMax = 20 + bonus + weatherbonus - deathrate; 

		
		if (hpMax < 1) 
		{
			hpMax = 1;
		}

	}

}