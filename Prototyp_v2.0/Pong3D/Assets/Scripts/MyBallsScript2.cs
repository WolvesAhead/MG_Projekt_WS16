using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyBallsScript2 : MonoBehaviour {


    public Rigidbody rb;
    bool startposition = true;
    public GameObject playerPaddle;
    public GameObject playerPaddle2;
    public Text scoreText2;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        scoreText2.text = ((int)Player2Control.player2Score).ToString();
        // FÜr die Score Berechnung.Tore für Spieler 2.
        /*if (transform.position.y < -4.85)
        {
            Player2Control.player2Score += 500;
            Player1Control.player1Score -= 500;
            if(Player1Control.player1Score <= 0)
            {
                Player1Control.player1Score = 0;
            }
            Debug.Log("TOOOOR für Player 2 !! Player1: " + Player1Control.player1Score + " Player2: " + Player2Control.player2Score);
        }*/

        /*if ((startposition == true || transform.position.y < -4.85f || transform.position.y > 4.85f) && !(gameObject.name.Contains("(Clone)")))
        {
            transform.position = new Vector3(playerPaddle.transform.position.x, 4.4f, -0.7f);
            startposition = true;
        }*/

        if ((startposition == true)  && !(gameObject.name.Contains("(Clone)")))
        {
            transform.position = new Vector3(playerPaddle.transform.position.x, 4.4f, -0.7f);
        }

        if (Input.GetKey(KeyCode.W) && startposition && !(gameObject.name.Contains("(Clone)")))
        {
            GetComponent<Rigidbody>().AddForce(0, -300, 0);
            startposition = false;
            //GetComponent<Rigidbody>();
        }
        if (startposition == false)
        {
            /*if (rb.velocity.x > 3.5)
            {
                //Debug.Log("X Speed"+ rb.velocity.x);
                rb.velocity = new Vector3(rb.velocity.x - 0.1f, rb.velocity.y, 0);
            }

            if (rb.velocity.x < -3.5)
            {
                rb.velocity = new Vector3(rb.velocity.x + 0.1f, rb.velocity.y, 0);
            }
            */
            rb.velocity = 4 * (rb.velocity.normalized);
        }

        // das it für den clone Ball damit der auch ein geschwindichkeit hat
        if ((gameObject.name.Contains("(Clone)")))
        {
            rb.velocity = 4 * (rb.velocity.normalized);

        }

    }

    public void Serve()
    {
        startposition = true;
    }

    public void Standby()
    {
        transform.position = new Vector3(playerPaddle.transform.position.x, 4.4f, 5f);
    }

    void OnCollisionEnter(Collision collision)
    {


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
