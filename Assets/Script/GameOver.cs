using UnityEngine;
using System.Collections;


public class GameOver : MonoBehaviour {

    public GameObject loseMenu;
    // Use this for initialization
    void Start () {
        loseMenu = GameObject.Find("GameOver");
        loseMenu.SetActive(true);
        Time.timeScale = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Quit()
    {
        Application.Quit();
    }
}
