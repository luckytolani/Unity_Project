using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_position : MonoBehaviour {

    public GameObject char_position;
	// Use this for initialization
	void Start ()
    {
        position();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void position()
    {
        char_position.transform.position = this.gameObject.transform.position;
    }
}
