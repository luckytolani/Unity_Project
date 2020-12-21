using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selector : MonoBehaviour {

    public GameObject game_ui;

    public GameObject instructionPannel;
    private levelController lev;

    public GameObject quitPannel;
	// Use this for initialization
	void Start ()
    {
        lev = GameObject.FindObjectOfType<levelController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void new_game()
    {

        game_ui.SetActive(true);
        lev.newGame(this.gameObject);
       
    }
    public void exit()
    {
        quitPannel.SetActive(true);
       
    }
    public void instructions()
    {
        instructionPannel.SetActive(true);
    }
    public void closeInstructions()
    {
        instructionPannel.SetActive(false);
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void cancle()
    {
        quitPannel.SetActive(false);
    }
}
