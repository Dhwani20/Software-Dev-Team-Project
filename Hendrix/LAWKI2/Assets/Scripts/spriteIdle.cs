using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteIdle : MonoBehaviour {

	bool shrinking = true;
	int counterConst = 3;
	int counter;

	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3(1.05f, 0.95f, 1);
		counter = counterConst;
	}

	// Update is called once per frame
	void Update () {
		if (counter == 0)
			//if (counter == 0 && GetComponent<SpriteRenderer>().sprite != (Sprite)Resources.Load("ERROR"))
		{
			counter = counterConst;
			if (shrinking)
			{
				transform.localScale += new Vector3(-0.01f, 0.01f, 0);
				if (transform.localScale.x <= 0.95f)
				{
					shrinking = false;
				}
			}
			else
			{
				transform.localScale += new Vector3(0.01f, -0.01f, 0);
				if (transform.localScale.x >= 1.05f)
				{
					shrinking = true;
				}
			}
		}
		else counter--;
	}
}
