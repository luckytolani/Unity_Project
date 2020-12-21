using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCOntroller : MonoBehaviour {

    int health = 2;
    public int score = 0;
    //GameOver Pannel components
    public GameObject GameOverPannel;
    public Text go_re_level;
    public Text go_level;
    public Text coins;

    public GameObject[] char_health;
    public GameObject key_text;

    public Text score_text;
    int old_score;
    private Player player;
    AudioSource ad;
    public GameObject cm;
    // Use this for initialization


    private levelController l_controller;
	void Start ()
    {

        l_controller = GetComponent<levelController>();
        ad = GetComponent<AudioSource>();
        player = GameObject.FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        score_text.text = score.ToString();
    }
    public void health_reduce()
    {
        if (health == -1)
        {
            GameOver();
        }
        if(health >= 0)
            char_health[health].SetActive(false);
        ad.Play();
        
        health -= 1;
      
       
    }
    public void Score(string str)
    {
        if (str == "coin")
            score += 100;
        else if (str == "key")
        {
            score += 500;
            key_text.SetActive(true);
        }
        else if (str == "gate")
        {
            key_text.SetActive(false);
            score += 1000;
            if (health < 2)
            {
                health++;
                char_health[health].SetActive(true);
            }
        }
    }
    void GameOver()
    {
        coins.text = score.ToString();
        go_re_level.text = (3 - l_controller.level_counter).ToString();
        go_level.text = (l_controller.level_counter).ToString();
        cm.gameObject.SetActive(true);
        l_controller.closeLevel();
       
        GameOverPannel.SetActive(true);
    }
    
}
