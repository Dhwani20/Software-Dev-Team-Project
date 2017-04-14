using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class statsMaster : MonoBehaviour {
    int hpMax;              //Max Population (Health) this stat's value will ideally be determined based on a calculation involving the other stats + environmental factors. That aspect has not yet been implemented since this is mostly meant to test mutation behavior.
    public int hp;          //Population
    int hunger;             //Hunger
    int atk;                //Attack
    int def;                //Defense
    int spd;                //Speed
    int rep;                //Reproduction Rate
    int lifespan;           //lifespan
    
    //Hidden Stats

    //Resistances
    int cold;
    int heat; //unused until temperature is implemented
    int wet;
    int dry; //unused until temperature is implemented

    int mutationChance = 1; //Mutation chance
    int chance;

    int weatherbonus;

    //placeholder variables. Mario, please adapt these to the proper variables if you can.
    bool isRaining;
    bool isSnowing;
    bool isSunny;
    bool isCloudy;

    // Use this for initialization
    void Start () {
        hpMax = 20;
        hunger = 100;
        atk = 1;                
        def = 1;                
        spd = 1;                
        rep = 2;                
        lifespan = 50;

        cold = 50;
        heat = 50;
        wet = 50;
        dry = 50;
        weatherbonus = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (hp < hpMax) //regenerate population over time
        {
            hp += rep;
            if (hp > hpMax)
            {
                hp = hpMax;
            }
        }
        if ((int)Random.Range(1, 200) <= mutationChance) { //chance to mutate is Mutation Chance / 200
            if (Random.Range(1, 100) < 50) //50-50 chance to be a negative mutation
            {
                chance = 1;
            }
            else
                chance = 0;
            Mutate(chance); //once mutation chance is determined, mutate.
        }
        weatherUpdate();
        calchp(); //Add a counter to control this.
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
                    lifespan -= 1;
                    if (lifespan <= 0)
                        lifespan = 1;
                }
                else
                    lifespan += 1;
                break;

        }

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
        else {//default
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
            bonus = (def/2) * rep;
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

        deathrate = starve + (100 / def) + (100 / rep); //Low durability + low birth rate = high death rate. High birth rate + low lifespan = low death rate

        hpMax = 20 + bonus + weatherbonus - deathrate; //final calculation
        
    }
}
