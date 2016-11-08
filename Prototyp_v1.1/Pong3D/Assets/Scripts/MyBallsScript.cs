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
    	
            // FÜr die Score Berechnung.Tore für SPieler 1
           /* if (transform.position.y > 4.85)
            {
            Player1Control.player1Score += 500;
            Player2Control.player2Score -= 500;
            anzahlBälle1--;
            
            if (Player2Control.player2Score <= 0)
            {
                Player2Control.player2Score = 0;
            }
            Debug.Log("TOOOOR für Player 1 !! Player1: " + Player1Control.player1Score + " Player2: " + Player2Control.player2Score);
            }
        */

        if ((startposition == true || transform.position.y < -4.85f || transform.position.y > 4.85f) && !(gameObject.name.Contains("(Clone)"))) //&& anzahlBälle1 == 1)
        {
            transform.position = new Vector3(playerPaddle.transform.position.x, -4.4f, -0.7f);
            anzahlBälle1++;
            startposition = true;
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

        //Debug.DrawLine(Vector3.zero, transform.position, Color.blue,5 ,false);

    }

    void Serve()
    {
        transform.position = new Vector3(playerPaddle.transform.position.x, -4.4f, -0.7f);
        anzahlBälle1++;
        startposition = true;
    }
}

