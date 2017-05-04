using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingSprites : MonoBehaviour {
    int spriteIndex = 1;

    Sprite currentSprite; 

    void Start () {
        currentSprite = Resources.Load<Sprite>("01");
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<SpriteRenderer>().sprite = currentSprite;

        if (Input.GetKeyDown(KeyCode.Alpha1))//checks for valid keys.
        {
            spriteIndex = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spriteIndex = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            spriteIndex = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            spriteIndex = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            spriteIndex = 5;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            spriteIndex = 6;
        }
        else if (Input.anyKeyDown && !(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)))  //sends error for invalid keys.
        {
            spriteIndex = 0;
        }

        UpdateSprite();

    }

    void UpdateSprite() {
        switch (spriteIndex)
        { //handles sprite changes
            case 1:
                currentSprite = Resources.Load<Sprite>("01");
                break;
            case 2:
                currentSprite = Resources.Load<Sprite>("02");
                break;
            case 3:
                currentSprite = Resources.Load<Sprite>("03");
                break;
            case 4:
                currentSprite = Resources.Load<Sprite>("04A");
                break;
            case 5:
                currentSprite = Resources.Load<Sprite>("04B");
                break;
            case 6:
                currentSprite = Resources.Load<Sprite>("05");
                break;
            default:
                currentSprite = Resources.Load<Sprite>("ERROR"); //This sprite should not be seen unless there is an error.
                break;


        }
    }
}
