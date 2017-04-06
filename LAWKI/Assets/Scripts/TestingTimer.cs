using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestingTimer : MonoBehaviour {
    public bool Testing = false;
    public GameObject[] weatherSpriteArr;

	void Start(){
		weatherSpriteArr [1].SetActive (true);
        if (Testing)
        {
            StartCoroutine(Test());
        }
	}

    IEnumerator Test()
    {
        yield return new WaitForSeconds(4);
        ClearSprite();
        weatherSpriteArr[2].SetActive(true);
        if (weatherSpriteArr[2].activeSelf) Debug.Log("weather sprite set successful");
        else Debug.Log("weather sprite set fail");
        yield return new WaitForSeconds(4);
        ClearSprite();
        weatherSpriteArr[3].SetActive(true);
        if (weatherSpriteArr[3].activeSelf) Debug.Log("weather sprite set successful");
        else Debug.Log("weather sprite set fail");
        yield return new WaitForSeconds(4);
        ClearSprite();
        weatherSpriteArr[4].SetActive(true);
        if (weatherSpriteArr[4].activeSelf) Debug.Log("weather sprite set successful");
        else Debug.Log("weather sprite set fail");
        yield return new WaitForSeconds(21);
        ClearSprite();
        weatherSpriteArr[3].SetActive(true);
        if (weatherSpriteArr[3].activeSelf) Debug.Log("weather sprite set successful");
        else Debug.Log("weather sprite set fail");
        yield return new WaitForSeconds(4);
        ClearSprite();
        weatherSpriteArr[2].SetActive(true);
        if (weatherSpriteArr[2].activeSelf) Debug.Log("weather sprite set successful");
        else Debug.Log("weather sprite set fail");
        yield return new WaitForSeconds(4);
        ClearSprite();
        weatherSpriteArr[1].SetActive(true);
        if (weatherSpriteArr[1].activeSelf) Debug.Log("weather sprite set successful");
        else Debug.Log("weather sprite set fail");
    }

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Q)) {//checks for valid keys.
			//spriteIndex = 1;
			ClearSprite();
			weatherSpriteArr [1].SetActive (true);

		} else if (Input.GetKeyDown (KeyCode.W)) {
			//spriteIndex = 2;
			ClearSprite();
			weatherSpriteArr [2].SetActive (true);


		} else if (Input.GetKeyDown (KeyCode.E)) {
			//spriteIndex = 3;
			ClearSprite();
			weatherSpriteArr [3].SetActive (true);

		} else if (Input.GetKeyDown (KeyCode.R)) {
			//spriteIndex = 4;
			ClearSprite();
			weatherSpriteArr [4].SetActive (true);


		} else if (Input.anyKeyDown && !(Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1) || Input.GetMouseButtonDown (2) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Alpha4) || Input.GetKey(KeyCode.Alpha5) || Input.GetKey(KeyCode.Alpha6))) {  //sends error for invalid keys.
			//spriteIndex = 0;
			ClearSprite();
			weatherSpriteArr [0].SetActive (true);

		}
	}

	void ClearSprite ()
	{
		for (int i = 0; i < 5; i++) {
			weatherSpriteArr [i].SetActive (false);
		}
	}
}
