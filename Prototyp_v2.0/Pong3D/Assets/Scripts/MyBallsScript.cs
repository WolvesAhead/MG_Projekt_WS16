using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyBallsScript : MonoBehaviour
{
    public Rigidbody rb;

    bool startposition = true;
    public GameObject playerPaddle;
    public GameObject playerPaddle2;
    public Text scoreText;
    public static int anzahlBälle1 = 1;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = ((int)Player1Control.player1Score).ToString();

        if(Player1Control.powerballstatus == true)    
        {
            if(transform.position.x > 5.9 || transform.position.x < -5.9)
                transform.GetComponent<Collider>().isTrigger = false;
            else
            {
            transform.GetComponent<Collider>().isTrigger = true;}
            if(transform.position.y > 4)
            {
                transform.GetComponent<Collider>().isTrigger = false;
                Player1Control.powerballstatus = false;
            }
        }

        if ((startposition == true) && !(gameObject.name.Contains("(Clone)")))
        {
            
            transform.position = new Vector3(playerPaddle.transform.position.x, -4.4f, -0.7f);
        }

       // if (startposition && !(gameObject.name.Contains("(Clone)")))
        //{
           

            if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow)&& (startposition || Player1Control.glued )&& !(gameObject.name.Contains("(Clone)")))
            {
                rb.velocity = new Vector3(0,0,0);
                Debug.Log("rechts");
                GetComponent<Rigidbody>().AddForce(600, 300, 0);
                startposition = false;
            }

            if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) && (startposition || Player1Control.glued )&& !(gameObject.name.Contains("(Clone)")))
            {
                rb.velocity = new Vector3(0,0,0);
                GetComponent<Rigidbody>().AddForce(-600, 300, 0);
                Debug.Log("Links");
                startposition = false;
            }

            if(Input.GetKey(KeyCode.UpArrow)&& (startposition || Player1Control.glued )&& !(gameObject.name.Contains("(Clone)")))
            {
                rb.velocity = new Vector3(0,0,0);
                GetComponent<Rigidbody>().AddForce(0, 300, 0);
                Debug.Log("Oben");
                startposition = false;
            }

            
            //GetComponent<Rigidbody>();
        //}


        /*if(rb.velocity.x > 3.7)
        {
            //Debug.Log("X Speed"+ rb.velocity.x);
            rb.velocity = new Vector3(rb.velocity.x - 0.001f, rb.velocity.y, 0);
        }

        if (rb.velocity.x < -3.7)
        {
            rb.velocity = new Vector3(rb.velocity.x + 0.001f, rb.velocity.y, 0);
        }


        //Debug.Log(rb.velocity.y);
        */
        if (startposition == false)
        {
            rb.velocity = 4 * (rb.velocity.normalized);
        }


        // das it für den clone Ball damit der auch ein geschwindichkeit hat
        if ((gameObject.name.Contains("(Clone)")))
        {
            rb.velocity = 4 * (rb.velocity.normalized);

        }

        if (anzahlBälle1 == 0)
        {
            Player1Control.playerPaddle.transform.localScale = new Vector3(2, 0, 0);
            Debug.Log("player 1 no Balls");
        }

        //Debug.DrawLine(Vector3.zero, transform.position, Color.blue,5 ,false);
    }

    public void Serve()   //Bedeutet Ball wird jetzt wieder aufs Paddle gesetzt, bereit zum schießen
    {
        startposition = true;
    }

    public void Standby()   //Ball wird unter dem Spielfeld gehalten bis die Anzahl auf 0 ist und Serve aufgerufen wird
    {
        transform.position = new Vector3(playerPaddle.transform.position.x, -4.4f, 5f);
    }


    void OnCollisionEnter(Collision collision)
    {

        /*if(Player1Control.powerballstatus == true && collision.transform.tag == "Player1Paddle")    
        {
            transform.GetComponent<Collider>().isTrigger = true;
            Player1Control.powerballstatus = false;
        }*/
        

        foreach (ContactPoint contact in collision.contacts)
        {
            //Punkt auf dem Paddle
            

            //Wert zur Winkelberechnung an Hand der Paddle länge
            
            Debug.Log("paddlescale" + (playerPaddle.transform.localScale.x / 2));

            // "Winkel" errechnung 
            if (collision.transform.tag == "Player1Paddle" && playerPaddle.transform.position.x < Player1Control.rightLimit - 0.1 && playerPaddle.transform.position.x > Player1Control.leftLimit + 0.1) // damit den ball nicht das paddle folgt wenn das hackt und geht mehr als die grennzung
            {
                float winkel = contact.point.x - playerPaddle.transform.position.x;
                float winkelX = winkel / (playerPaddle.transform.localScale.x / 2);
                rb.velocity = new Vector3(winkelX * 5, rb.velocity.y, 0);


            }
            if (collision.transform.tag == "Player2Paddle" && playerPaddle2.transform.position.x < Player1Control.rightLimit - 0.1 && playerPaddle2.transform.position.x > Player1Control.leftLimit + 0.1)
            {
                float winkel = contact.point.x - playerPaddle2.transform.position.x;
                float winkelX2 = winkel / (playerPaddle2.transform.localScale.x / 2);
                rb.velocity = new Vector3(winkelX2 * 5, rb.velocity.y, 0);

            }


            //Debug.Log(contact.point.x);
        }
    }
}

