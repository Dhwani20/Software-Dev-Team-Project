using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectChar : MonoBehaviour {
	public GameObject[] playerSpriteArr;
	public Text text;
	public int count;

	private int countMax;
	public GameObject[] charTextArr;



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

	// Use this for initialization
	void Start () {

		playerSpriteArr [2].SetActive (true);
		countMax = playerSpriteArr.Length;
		count = 1;

	}

	// Update is called once per frame
	void Update(){
		ClearSprite ();
		playerSpriteArr [count].SetActive (true);

		charTextArr [count].SetActive(true);
		//text.text = 
	}

	public void increaseCount()
	{
		count = count + 1;
		if (count == countMax) {
			count = 1;
		}
	}

	public void decreaseCount()
	{
		count = count - 1;
		if (count == 0) {
			count = countMax - 1;
		}
	}

	void ClearSprite ()
	{
		for (int i = 0; i < 6; i++) {
			playerSpriteArr [i].SetActive (false);
			charTextArr [i].SetActive (false);
		}
	}

	public int getCount()
	{
		return count;
	}
		
}