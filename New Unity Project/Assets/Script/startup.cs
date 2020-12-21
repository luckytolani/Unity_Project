using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startup : MonoBehaviour {

    public GameObject loader;
    public GameObject first;
    public GameObject second;
    float time;

	// Use this for initialization
	void Start ()
    {
        time = Time.fixedTime;
        first.SetActive(true);
    }
	
	// Update is called once per frame
	void Update ()
    {
     if(time+5==Time.fixedTime || time+15==Time.fixedTime)
        {
            loader.SetActive(true);
        }
     if(time+10==Time.fixedTime)
        {
            first.SetActive(false);
            loader.SetActive(false);
            second.SetActive(true);
        }
        if (time + 20 == Time.fixedTime)
        {
            first.SetActive(false);
            loader.SetActive(false);
            second.SetActive(false);
            Application.LoadLevel("mario");
            this.gameObject.SetActive(false);
        }
    }
}
