﻿using UnityEngine;
using System.Collections;

public class Player1Control : MonoBehaviour 
{
	public GameObject playerPaddle;
    public GameObject bottomBorder;
    public GameObject nebel;
    public GameObject shield;
    public Rigidbody rbball;
    public Rigidbody rbball2;

    private float speed = 6f;
    public static float rightLimit;
    public static float leftLimit;
    private Rigidbody ItemInstance;

    public  bool nebelsatus = false;          
    public bool shieldstatus = false;

    public static int player1Score;
    public static int controlChange;
    float controlChangeTime = 5f;
    float NebelTime = 20f;
    float shieldTime = 15f;


    void Start() 
	{
       
        Debug.Log(transform.localScale.x / 2);

	}

    void Update()
    {

        // left limit ist der wert von der punkt der am ende links auf dem bottomBorder liegt und zwar "-6,25 "
        // genau das gleiche geht für rightLimit 

        leftLimit = bottomBorder.GetComponent<Renderer>().bounds.min.x + (transform.localScale.x / 2); // 0,75 ist die hälfte unsere paddle (-6,25 + 0,75 = -5,5) ==> genau unesere limit
        rightLimit = bottomBorder.GetComponent<Renderer>().bounds.max.x - (transform.localScale.x / 2);

        #region Nebel
        // nebel activation      
        if (nebelsatus)
        {
            NebelTime -= Time.deltaTime;
            //nebel.GetComponent<ParticleSystem>().Play();
            Debug.Log("nebel activ!");
            nebel.SetActive(true);
          
          


            if (NebelTime < 0)
            {
                nebelsatus = false;
                NebelTime = 20f;

            }
        }
        else
        {
            //nebel.GetComponent<ParticleSystem>().Stop();
            nebel.SetActive(false);
        }

        #endregion

        #region Controlchange
        // ControllChange 
        if (controlChange >= 1)
        {
            //Timer
            controlChangeTime -= Time.deltaTime;
            if (controlChangeTime < 0)
            {
                controlChange = 0;
                controlChangeTime = 5f;
            }
             
            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x > leftLimit + 0.1)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
       

            }
            if (Input.GetKey(KeyCode.LeftArrow)  && transform.position.x < rightLimit - 0.1)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }


        else
        {
        // Steuerung

            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < rightLimit - 0.1)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > leftLimit + 0.1)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }

            
        }

        #endregion

        #region Shield
        // nebel activation      
        if (shieldstatus)
        {
            shieldTime -= Time.deltaTime;
            //nebel.GetComponent<ParticleSystem>().Play();
            shield.SetActive(true);


            if (shieldTime < 0)
            {
                shieldstatus = false;
                shieldTime = 15f;

            }
        }
        else
        {
            //nebel.GetComponent<ParticleSystem>().Stop();
            shield.SetActive(false);
        }

        #endregion

    }


    void OnCollisionEnter(Collision collision) {
        
       
        /*foreach (ContactPoint contact in collision.contacts)
            {
            	//Punkt auf dem Paddle
            	float winkel = contact.point.x - transform.position.x;

            //Wert zur Winkelberechnung an Hand der Paddle länge
            float winkelX = winkel / (transform.localScale.x / 2);
            Debug.Log("paddlescale"+ (transform.localScale.x / 2));

            // "Winkel" errechnung 
            if (!(rbball.name.Contains("(Clone)")) && collision.transform.tag == "ball" && transform.position.x < rightLimit - 0.1 && transform.position.x > leftLimit + 0.1) // damit den ball nicht das paddle folgt wenn das hackt und geht mehr als die grennzung
            {
                    
                    rbball.velocity = new Vector3(winkelX * 5, rbball.velocity.y, 0);
                              
            }
            if (!(rbball2.name.Contains("(Clone)")) && collision.transform.tag == "ball2" && transform.position.x < rightLimit - 0.1 && transform.position.x > leftLimit + 0.1)
            {
                
                    rbball2.velocity = new Vector3(winkelX * 5, rbball2.velocity.y, 0);
               
            }


            //Debug.Log(contact.point.x);
        }
        */
        #region ITEMS
        //////////////////BIGP PADDLE ITEM\\\\\\\\\\\\\\\\\\

        if (collision.transform.tag == "bigPaddle")
        {
          
            this.gameObject.transform.localScale += new Vector3(1, 0, 0);

        }

        //////////////////Small PADDLE ITEM- Bug verhindert, dass die X Größe ins Negative gerät und somit wieder größer wird\\\\\\\\\\\\\\\\\\

        if (collision.transform.tag == "smallPaddle")
        {
            if (this.gameObject.transform.localScale.x >= 1)
            {
                this.gameObject.transform.localScale -= new Vector3(1, 0, 0);
            }
        }

        //////////////////mehr bälle ITEM\\\\\\\\\\\\\\\\\\

        if (collision.transform.tag == "mehrbaelle")
        {

            
            DestroyObjectsBottomBorder.ballCount1++;
            Debug.Log("ball++. Du hast jetzt " + DestroyObjectsBottomBorder.ballCount1 + " Bälle");
            ItemInstance = Instantiate(rbball, new Vector3(transform.position.x, transform.position.y+1f, transform.position.z), Quaternion.identity) as Rigidbody;
            ItemInstance.AddForce(0, 150, 0);

        }

        ///////////////// Steuerung umkehren \\\\\\\\\\\\\\\\
        if  (collision.transform.tag == "ControlChange")
        {
                //Debug.Log("Rechts is jetzt Links");

            Player2Control.controlChange += 1; 
            
            /*if (Input.GetKey(KeyCode.RightArrow) && (transform.position.x > rightLimit - 0.1))
            {
                transform.position += Vector3.left * speed * Time.deltaTime;

            }
            if (Input.GetKey(KeyCode.LeftArrow)  && (transform.position.x < leftLimit + 0.1))
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            } 
            */
        }
        ///////////////// Nebel Item \\\\\\\\\\\\\\\\

        if (collision.transform.tag == "nebelItem")
        {
            nebelsatus = true;
            
        }

        ///////////////// Shield Item \\\\\\\\\\\\\\\\

        if (collision.transform.tag == "shieldItem")
        {
            shieldstatus = true;

        }

        #endregion

    }



}
