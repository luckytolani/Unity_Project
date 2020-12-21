using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverComponent : MonoBehaviour {

    public GameObject Selector;
    public GameObject GameOverPannel;
    public GameObject congratulation_;
    public void start()
    {
        Selector.SetActive(true);
    }
    public void mainMenu()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }

}
