using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freemove : MonoBehaviour {

   public Camera cm;
	// Use this for initialization
	void Start ()
    {
        cm = GetComponent<Camera>();
        cm.fieldOfView = 98;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(1.5f*Time.deltaTime,0,0);
      
	}
}
