﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyBallsScript2 : MonoBehaviour {


    public Rigidbody rb;
   static public bool startposition = true;
    public GameObject playerPaddle;
    public GameObject playerPaddle2;
    public GameObject fireball2;
    public GameObject Firepaddle2;
    public Text scoreText2;
    public float gameTimer;
    public int ballSpeed = 4;

    public Image circleShield;
    public Image circleGlue;
    public Image circleControlChange;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        gameTimer += Time.deltaTime;
        if (gameTimer > 30)
        {
            if (ballSpeed < 6)
            {
                ballSpeed += 1;
            }
            gameTimer = 0;
            Debug.Log("faster");
        }

        scoreText2.text = ((int)Player2Control.player2Score).ToString();

        if (Player2Control.powerballCollected == true)
        {
            Firepaddle2.SetActive(true);

        }
            if (Player2Control.powerballstatus == true)    
        {
            Firepaddle2.SetActive(false);
            fireball2.SetActive(true);

                if (transform.position.x > 5.9 || transform.position.x < -5.9)
                transform.GetComponent<Collider>().isTrigger = false;
            else
            {
             transform.GetComponent<Collider>().isTrigger = true;
            }

            if(transform.position.y < -4)
            {
                transform.GetComponent<Collider>().isTrigger = false;
                fireball2.SetActive(false);
                Player2Control.powerballstatus = false;
            }
        }

        if ((startposition == true)  && !(gameObject.name.Contains("(Clone)")))
        {

            transform.position = new Vector3(playerPaddle.transform.position.x, 4.44f, -0.7f);
        }

 


        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) && (startposition || Player2Control.glued && Player2Control.isClone == false))
        {
            rb.velocity = new Vector3(0, 0, 0);
            Debug.Log("rechts");
            GetComponent<Rigidbody>().AddForce(600, -300, 0);
            startposition = false;
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) && (startposition || Player2Control.glued && Player2Control.isClone == false))
        {
            rb.velocity = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().AddForce(-600, -300, 0);
            Debug.Log("Links");
            startposition = false;
        }

        if (Input.GetKey(KeyCode.W) && (startposition || Player2Control.glued && Player2Control.isClone == false))
        {
            rb.velocity = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().AddForce(0, -300, 0);

            startposition = false;
            Player2Control.glued = false;
        }

        else if (Input.GetKey(KeyCode.W) && (Player2Control.glued && Player2Control.isClone))
        {
            Player2Control.ItemInstance.velocity = new Vector3(0, 0, 0);
            Player2Control.ItemInstance.AddForce(0, -300, 0);
            Debug.Log("Oben");
            startposition = false;
            Player2Control.glued = false;
        }
        #region Kuti Steuerung
        /*
                if (Input.GetKey(KeyCode.I) && Input.GetKey(KeyCode.K) && (startposition || Player2Control.glued && Player2Control.isClone == false))
                {
                    rb.velocity = new Vector3(0, 0, 0);
                    Debug.Log("rechts");
                    GetComponent<Rigidbody>().AddForce(600, -300, 0);
                    startposition = false;
                }

                if (Input.GetKey(KeyCode.Hash) && Input.GetKey(KeyCode.K) && (startposition || Player2Control.glued && Player2Control.isClone == false))
                {
                    rb.velocity = new Vector3(0, 0, 0);
                    GetComponent<Rigidbody>().AddForce(-600, -300, 0);
                    Debug.Log("Links");
                    startposition = false;
                }

                if (Input.GetKey(KeyCode.K) && (startposition || Player2Control.glued && Player2Control.isClone == false))
                {
                    rb.velocity = new Vector3(0, 0, 0);
                    GetComponent<Rigidbody>().AddForce(0, -300, 0);

                    startposition = false;
                    Player2Control.glued = false;
                }

                else if (Input.GetKey(KeyCode.K) && (Player2Control.glued && Player2Control.isClone))
                {
                    Player2Control.ItemInstance.velocity = new Vector3(0, 0, 0);
                    Player2Control.ItemInstance.AddForce(0, -300, 0);
                    Debug.Log("Oben");
                    startposition = false;
                    Player2Control.glued = false;
                }*/
        #endregion

        if (startposition == false)
        {

            rb.velocity = ballSpeed * (rb.velocity.normalized);
        }

        // das it für den clone Ball damit der auch ein geschwindichkeit hat
        if ((gameObject.name.Contains("(Clone)")))
        {
            rb.velocity = ballSpeed * (rb.velocity.normalized);

        }

    }

    public void Serve()
    {
        startposition = true;
    }

    public void Standby()
    {
        transform.position = new Vector3(playerPaddle.transform.position.x, 4.44f, 5f);
    }

    public void ResetPowerups2()
    {
        if (playerPaddle.transform.localScale.x >= 1.5f)
        {
            playerPaddle.transform.localScale = new Vector3(1.5f, 0.2f, 0.6f);
            Debug.Log("transform");
        }
        Player2Control.powerballstatus = false;
        Player2Control.powerballCollected = false;
        Player2Control.gluestatus = false;
        Player2Control.glued = false;
        fireball2.SetActive(false);
       circleControlChange.fillAmount = 0;
       circleGlue.fillAmount = 0;
       circleShield.fillAmount = 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        /*if (Player2Control.powerballstatus == true && collision.transform.tag == "Player2Paddle")
        {
            transform.GetComponent<Collider>().isTrigger = true;
            Player2Control.powerballstatus = false;
        }*/


        foreach (ContactPoint contact in collision.contacts)
        {
            //Punkt auf dem Paddle
            

            //Wert zur Winkelberechnung an Hand der Paddle länge
            
            Debug.Log("paddlescale" + (playerPaddle.transform.localScale.x / 2));

            // "Winkel" errechnung 
            if (collision.transform.tag == "Player2Paddle" && playerPaddle.transform.position.x < Player1Control.rightLimit - 0.1 && playerPaddle.transform.position.x > Player1Control.leftLimit + 0.1) // damit den ball nicht das paddle folgt wenn das hackt und geht mehr als die grennzung
            {
                float winkel = contact.point.x - playerPaddle.transform.position.x;
                float winkelX = winkel / (playerPaddle.transform.localScale.x / 2);
                rb.velocity = new Vector3(winkelX * 5, rb.velocity.y, 0);


            }
            if (collision.transform.tag == "Player1Paddle" && playerPaddle2.transform.position.x < Player1Control.rightLimit - 0.1 && playerPaddle2.transform.position.x > Player1Control.leftLimit + 0.1) // wir haben Player1Control Sciprt benutzt weil player1 und player 2 haben die gleichen grenzen
            {
                float winkel = contact.point.x - playerPaddle2.transform.position.x;
                float winkelX2 = winkel / (playerPaddle2.transform.localScale.x / 2);
                rb.velocity = new Vector3(winkelX2 * 5, rb.velocity.y, 0);

            }


            //Debug.Log(contact.point.x);
        }
    }
}
