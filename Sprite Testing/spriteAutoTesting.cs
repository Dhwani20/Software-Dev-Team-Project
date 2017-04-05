using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteAutoTesting : MonoBehaviour {
    int spriteIndex = 0;
    int counterConst = 30;
    int counter;

    int errors = 0;

    Sprite currentSprite;

    void Start()
    {
        counter = counterConst;
        Debug.Log("Running sprite tests...");
        Debug.Log("Testing error handling sprite (Default case)");

        currentSprite = Resources.Load<Sprite>("ERROR");
        if (currentSprite == null) {
            Debug.Log("Failed to load sprite 'ERROR.png'");
            errors++;
        }
        else
            Debug.Log("Default sprite loaded successfully.");
    }


    // Update is called once per frame
    void Update () {
        GetComponent<SpriteRenderer>().sprite = currentSprite;
        if (counter <= 0)
        {
            if (spriteIndex < 6) {
                spriteIndex++;
                Debug.Log("Now testing sprite " + spriteIndex.ToString() + " of 6");
                UpdateSprite();
            }
            counter = counterConst;
        }
        else if (spriteIndex < 6)
        {
            counter--;
        }
        else if (spriteIndex == 6)
        {
            Debug.Log("All tests complete! " + errors.ToString() + " error(s) generated.");
            spriteIndex = 20;
        }
	}

    void UpdateSprite()
    {
        switch (spriteIndex)
        { //handles sprite changes
            case 1:
                currentSprite = Resources.Load<Sprite>("01");
                if (currentSprite == null)
                {   Debug.Log("Failed to load sprite '01.png'");
                    errors++;
                }
                else
                    Debug.Log("Sprite loaded successfully.");
                break;
            case 2:
                currentSprite = Resources.Load<Sprite>("02");
                if (currentSprite == null)
                {
                    Debug.Log("Failed to load sprite '02.png'");
                    errors++;
                }
                else
                    Debug.Log("Sprite loaded successfully.");
                break;
            case 3:
                currentSprite = Resources.Load<Sprite>("03");
                if (currentSprite == null)
                {
                    Debug.Log("Failed to load sprite '03.png'");
                    errors++;
                }
                else
                    Debug.Log("Sprite loaded successfully.");
                break;
            case 4:
                currentSprite = Resources.Load<Sprite>("04A");
                if (currentSprite == null)
                {
                    Debug.Log("Failed to load sprite '04A.png'");
                    errors++;
                }
                else
                    Debug.Log("Sprite loaded successfully.");
                break;
            case 5:
                currentSprite = Resources.Load<Sprite>("04B");
                if (currentSprite == null)
                {
                    Debug.Log("Failed to load sprite '04B.png'");
                    errors++;
                }
                else
                    Debug.Log("Sprite loaded successfully.");
                break;
            case 6:
                currentSprite = Resources.Load<Sprite>("05");
                if (currentSprite == null)
                {
                    Debug.Log("Failed to load sprite '05.png'");
                    errors++;
                }
                else
                    Debug.Log("Sprite loaded successfully.");
                break;
            default:
                currentSprite = Resources.Load<Sprite>("ERROR"); //This sprite should not be seen unless there is an error.
                break;


        }
    }
}
