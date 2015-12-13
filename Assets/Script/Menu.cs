using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject creditsMenu;
    public GameObject scoresMenu;
    public GameObject helpMenu;
    public GameObject tempMenu;
    public bool paused;
    public bool check;
    
    // Use this for initialization
	void Start () {
        paused = false;
        check = true;
        pauseMenu = GameObject.Find("PauseMenu");
        creditsMenu = GameObject.Find("CreditsMenu");
        creditsMenu.SetActive(false);
        scoresMenu = GameObject.Find("ScoresMenu");
        scoresMenu.SetActive(false);
        helpMenu = GameObject.Find("HelpMenu");
        helpMenu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        
            if (Input.GetKeyDown(KeyCode.Escape) && check)
            {
                paused = !paused;
                check = true;
            }
            if (paused)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else if (!paused)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
	}
    public void Resume()
    {
        paused = false;
    }
    public void Credits()
    {
        creditsMenu.SetActive(true);
        tempMenu = GameObject.Find("CreditsMenu");
        check = false;
    }
    public void Scores()
    {
        scoresMenu.SetActive(true);
        tempMenu = GameObject.Find("ScoresMenu");
        check = false;
    }
    public void Help()
    {
        helpMenu.SetActive(true);
        tempMenu = GameObject.Find("HelpMenu");
        check = false;
    }
    public void Exit()
    {
        tempMenu.SetActive(false);
        check = true;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
