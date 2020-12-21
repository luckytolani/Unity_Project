using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class levelController : MonoBehaviour {


   
    public int level_counter = 0;
    public GameObject[] level;
    public GameObject afterLevel;

    // Use this for initialization


    //player different positions
    public GameObject player_after_level_position;
    public GameObject player_in_level_position;
    public GameObject congratulation_;
    private Player player;

    public GameObject character;
    public GameObject level_alert_text;
    private GameCOntroller gm_controller;

    public Text coins;
     
    
    void Start()
    {
        gm_controller = GetComponent<GameCOntroller>();
        level_alert_text.SetActive(false);
        player = GameObject.FindObjectOfType<Player>();
      
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void changeLevel(string str)
    {

        if (str == "level")
        {
            level_alert_text.SetActive(true);
            level[level_counter].SetActive(false);
            afterLevel.SetActive(true);
            changePosition("after_level", character);
         //   player.in_after_level = true;

        }
        if (str == "after_level")
        {
            level_alert_text.SetActive(false);
            afterLevel.SetActive(false);
            level_counter++;
            if (level_counter < 3)
            {
                level[level_counter].SetActive(true);
                changePosition("death", character);
            }
            else
            {

                congratulation();
            }

        }

    }
    void congratulation()
    {
        coins.text = gm_controller.score.ToString();
        level[level_counter - 1].SetActive(true);
        character.SetActive(false);
        congratulation_.SetActive(true);
        level_counter = 0;
    }
    public void changePosition(string str,GameObject obj)
    {
        if (str == "death")
        {
            obj.transform.position = player_in_level_position.transform.position;
        }
        else if(str=="after_level")
        {
            obj.transform.position = new Vector3(player_after_level_position.transform.position.x, player_after_level_position.transform.position.y,0f);//player_after_level_position.transform.position;

        }



    }
    public void newGame(GameObject selectorPannel)
    {

            gm_controller.score = 0;
            selectorPannel.SetActive(false);
            level[level_counter].SetActive(true);
            character.SetActive(true);
            changePosition("death", character);

    }
    
    public void closeLevel()
    {
       
        level[level_counter].SetActive(false);
        character.SetActive(false);
        level_counter = 0;
    }
}
