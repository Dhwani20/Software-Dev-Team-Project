using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Text ScoreText;
	public Button Rbutton;

	private int count;

	void Start()
	{
		Button btn = Rbutton.GetComponent<Button>();
		btn.onClick.AddListener (TaskOnClick);
		count = 0;
		SetScoreText ();
	}

	void TaskOnClick()
	{
			count = count + 1;
		SetScoreText ();
	}

	void SetScoreText()
	{
		ScoreText.text = "Count: " + count.ToString ();
	}
}
