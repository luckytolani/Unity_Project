using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_position : MonoBehaviour {


    public Camera cam;
	// Use this for initialization
	void Start ()
    {
        cam.fieldOfView = 100f;
      
    }
	
	// Update is called once per frame
	void Update ()
    {

        cam.transform.position = this.transform.position;
    }
}
