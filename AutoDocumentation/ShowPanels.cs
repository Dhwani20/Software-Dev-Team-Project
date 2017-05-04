using UnityEngine;
using System.Collections;
/// <summary>
/// Script that controls how and when player UI Panels are visualized.
/// </summary>
public class ShowPanels : MonoBehaviour {

    /// <summary>
    /// Member to determine if test cases execute.
    /// </summary>
    public bool Testing = false;
    /// <summary>
    /// Member to hold the options menu model.
    /// </summary>
	public GameObject optionsPanel;
    ///<summary>
    ///Member to hold the options menu layout.
    /// </summary>					 
	public GameObject optionsTint;
    ///<summary>
    ///Member to hold the begining menu model.
    /// </summary>					
    public GameObject menuPanel;
    ///<summary>
    ///Member to hold the pause menu model.
    /// </summary>						
    public GameObject pausePanel;
    ///<summary>
    ///Member to hold the player stats menu model. 
    /// </summary>							
	public GameObject playerPanel;
    ///<summary>
    ///Member to hold the player stats menu layout. 
    /// </summary>						
    public GameObject playerTint;
    ///<summary>
    ///Member to hold the player map layout. 
    /// </summary>							
    public GameObject playCanvas;
    ///<summary>
    ///Member to hold the player character select menu model. 
    /// </summary>		
	public GameObject charPanel;
    ///<summary>
    ///Member to hold the player interactive button layout. 
    /// </summary>		
	public GameObject buttonCanvas;



    void Start()
	{
		if(Testing)
		{
			StartCoroutine(TestPanels());
		}

	}
    ///<summary>
    ///Used to quit the game automatically after test cases execute.
    /// </summary>		
	public void Quit()
	{
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}
    /// <summary>
    /// Takes care of the automated test cases.
    /// </summary>
    IEnumerator TestPanels()
	{
		yield return new WaitForSeconds (3);
		charPanel.SetActive (false);
		buttonCanvas.SetActive (true);
		yield return new WaitForSeconds(38);
		ShowOptionsPanel();
		if (optionsPanel.activeSelf) Debug.Log("options menu open successful");
		else Debug.Log("options menu open fail");
		yield return new WaitForSeconds(2);
		HideOptionsPanel();
		if (!optionsPanel.activeSelf) Debug.Log("options menu close successful");
		else Debug.Log("options menu close fail");

		yield return new WaitForSeconds(3);
		ShowPlayerPanel();
		if (playerPanel.activeSelf) Debug.Log("player menu open successful");
		else Debug.Log("player menu open fail");
		yield return new WaitForSeconds(3);
		HidePlayerPanel();
		if (!playerPanel.activeSelf) Debug.Log("player menu close successful");
		else Debug.Log("player menu close fail");

		yield return new WaitForSeconds(3);
		ShowPlayerPanel();
		if (playerPanel.activeSelf) Debug.Log("player menu open successful");
		else Debug.Log("player menu open fail");
		yield return new WaitForSeconds(3);
		HidePlayerPanel();
		if (!playerPanel.activeSelf) Debug.Log("player menu close successful");
		else Debug.Log("player menu close fail");

		yield return new WaitForSeconds(3);
		ShowPlayerPanel();
		if (playerPanel.activeSelf) Debug.Log("player menu open successful");
		else Debug.Log("player menu open fail");
		yield return new WaitForSeconds(3);
		HidePlayerPanel();
		if (!playerPanel.activeSelf) Debug.Log("player menu close successful");
		else Debug.Log("player menu close fail");

		yield return new WaitForSeconds(3);
		ShowPlayerPanel();
		if (playerPanel.activeSelf) Debug.Log("player menu open successful");
		else Debug.Log("player menu open fail");
		yield return new WaitForSeconds(3);
		HidePlayerPanel();
		if (!playerPanel.activeSelf) Debug.Log("player menu close successful");
		else Debug.Log("player menu close fail");
		Quit ();
	}
    /// <summary>
    /// 
    /// </summary>
	public void ShowOptionsPanel()
	{
		optionsPanel.SetActive(true);
		optionsTint.SetActive(true);
	}

	public void HideOptionsPanel()
	{
		optionsPanel.SetActive(false);
		optionsTint.SetActive(false);
		
	}

	public void ShowMenu()
	{
		menuPanel.SetActive (true);
	}

	public void HideMenu()
	{
		menuPanel.SetActive (false);

		
	}
	
	public void ShowPausePanel()
	{
		pausePanel.SetActive (true);
		optionsTint.SetActive(true);
	}

	
	public void HidePausePanel()
	{
		pausePanel.SetActive (false);
		optionsTint.SetActive(false);

	}

	public void ShowPlayerPanel()
	{
		playerPanel.SetActive(true);
		playerTint.SetActive(true);
		
	}

	
	public void HidePlayerPanel()
	{
		playerPanel.SetActive(false);
		playerTint.SetActive(false);
	
	}

	public void HidePlayCanvas()
	{
		playCanvas.SetActive (false);
	}

	public void ShowPlayCanvas()
	{
		playCanvas.SetActive (true);
	}

	public void HideCharPanel()
	{
		charPanel.SetActive (false);
	}

	public void ShowButtonCanvas()
	{
		buttonCanvas.SetActive (true);
	}

	public void HideButtonCanvas()
	{
		buttonCanvas.SetActive (false);
	}

}
