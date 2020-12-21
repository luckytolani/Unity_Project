using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 5f;
    public float jump_power = 6f;
   
    bool key = false;
    public int level_counter = 0;
    public bool in_after_level = false;
    public Camera cm;



    bool isGround = false;
    private GameCOntroller gameController;
    public AudioClip jump;
    public AudioClip coin;
    AudioSource ad;
    Vector3 cm_position;
    private levelController level_controller;
    Animator anim;
    Rigidbody2D rigib;
    public GameObject child;
	void Start ()
    {
        rigib = GetComponent<Rigidbody2D>();
        cm_position = cm.transform.position;
        ad = GameObject.FindObjectOfType<AudioSource>();
        level_controller = GameObject.FindObjectOfType<levelController>();
        gameController = GameObject.FindObjectOfType<GameCOntroller>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (in_after_level == true)
        {
            key = false;
            this.transform.Translate(2f*Time.deltaTime,0,0);
            cm.transform.Translate(2f* Time.deltaTime, 0, 0);
            anim.SetBool("jump", true);

        }
        else
        {
            if (Input.GetKey(KeyCode.Space)&& isGround==true)
            {
                
                ad.PlayOneShot(jump);
                anim.SetBool("jump",true);
                isGround = false;
                rigib.velocity = Vector2.up * jump_power;//jump the character
                                                         // rigib.AddForce(Vector2.up * (jump_power * rigib.mass * rigib.gravityScale * 20f));  

            }
            else
            {
           //     rigib.AddForce(Vector2.down * (jump_power));
            }
            float x_diirection = Input.GetAxis("Horizontal") * Time.deltaTime * 5f; //get the movement values +ve as well as -Ve
            float old_pos = this.gameObject.transform.position.x;
            transform.Translate(x_diirection, 0, 0);
            float pos= this.gameObject.transform.position.x-old_pos;
           
          if (level_counter>1)
            {
                cm.gameObject.SetActive(false);
                child.SetActive(true);
            }
        }
      
    }


   void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Gate" && key==true)
        {
            cm.gameObject.SetActive(true);
            child.SetActive(false);
            gameController.Score("gate");
            level_controller.changeLevel("level");
            in_after_level = true;

        }
        if(other.gameObject.tag=="Gate1")
        {
            
            level_controller.changeLevel("after_level");
            in_after_level = false;
            cm.transform.position = cm_position;
            level_counter++;
            if(level_counter>1)
            {
                cm.transform.position = new Vector3(transform.position.x+2.59f,cm.transform.position.y,cm.transform.position.z);
            }
        }
        if (other.gameObject.tag == "boundary")
        {

            isGround = true;
            anim.SetBool("jump", false);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="key")
        {
            Destroy(other.gameObject);
            key = true;
            gameController.Score("key");
        }
        if(other.gameObject.tag == "coin")
        {
            ad.PlayOneShot(coin);
            Destroy(other.gameObject);
            gameController.Score("coin");
        }
        if (other.gameObject.tag == "death")
        {
            cm.transform.position = cm_position;
            gameController.health_reduce();
            level_controller.changePosition("death",this.gameObject);
        }
    }
}
