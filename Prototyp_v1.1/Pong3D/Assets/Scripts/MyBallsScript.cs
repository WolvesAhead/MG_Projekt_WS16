using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyBallsScript : MonoBehaviour {
    public Rigidbody rb;
    bool startposition = true;
    public GameObject playerPaddle;
    public Text scoreText;
    public static int anzahlBälle1 = 1; 

	// Use this for initialization
    void Start() 
    {
      
    }

    // Update is called once per frame
    void Update() 
    {
            
    	scoreText.text = ((int)Player1Control.player1Score).ToString();
    	

        if ((startposition == true) && !(gameObject.name.Contains("(Clone)")))
        {
            transform.position = new Vector3(playerPaddle.transform.position.x, -4.4f, -0.7f);
        }

        if (Input.GetKey(KeyCode.UpArrow) && startposition && !(gameObject.name.Contains("(Clone)")))
        {
            GetComponent<Rigidbody>().AddForce(0, 300, 0);
            startposition = false;
            //GetComponent<Rigidbody>();
        }


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

        if(anzahlBälle1 == 0)
        {
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
}

