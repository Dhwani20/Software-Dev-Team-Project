using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// THIS CODE IS CURRENTLY UNTESTED!
/// 
/// Jo, try to adapt this to the UI you're working on. Let me know if any problems or unexpected behavior arise.
/// </summary>

public class statsMaster : MonoBehaviour {
    int hpMax;              //Max Population (Health) this stat's value will ideally be determined based on a calculation involving the other stats + environmental factors. That aspect has not yet been implemented since this is mostly meant to test mutation behavior.
    int hunger;             //Hunger
    int atk;                //Attack
    int def;                //Defense
    int spd;                //Speed
    int rep;                //Reproduction Rate
    int size;               //Size
    int mutationChance = 1; //mutation chance
    int chance;

    // Use this for initialization
    void Start () {
        hpMax = 20;
        hunger = 100;
        atk = 1;                
        def = 1;                
        spd = 1;                
        rep = 2;                
        size = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if ((int)Random.Range(1, 200) <= mutationChance) { //chance to mutate is Mutation Chance / 200
            if (Random.Range(1, 100) < 50) //50-50 chance to be a negative mutation
            {
                chance = 1;
            }
            else
                chance = 0;
            Mutate(chance); //once mutation chance is determined, mutate.
        }
		
	}

    void Mutate(int isNegative) { //mutation
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
