using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyBallsScript : MonoBehaviour {
    public Rigidbody rb;
    bool startposition = true;
    public GameObject playerPaddle;
    public Text scoreText;
    public Text scoreText2;

	// Use this for initialization
    void Start() 
    {
      
    }

    // Update is called once per frame
    void Update() 
    {
            
    	scoreText.text = ((int)Player1Control.player1Score).ToString();
    	scoreText2.text = ((int)Player2Control.player2Score).ToString();
            // FÜr die Score Berechnung.Tore für SPieler 1
            if (transform.position.y > 5)
        {
            Player1Control.player1Score += 500;
            Player2Control.player2Score -= 500;
            
            if (Player2Control.player2Score <= 0)
            {
                Player2Control.player2Score = 0;
            }
            Debug.Log("TOOOOR für Player 1 !! Player1: " + Player1Control.player1Score + " Player2: " + Player2Control.player2Score);
            
        }
            if ((startposition == true || transform.position.y < -5f || transform.position.y > 5f) && !(gameObject.name.Contains("(Clone)")))
 
        {
            transform.position = new Vector3(playerPaddle.transform.position.x, -4.4f, -0.7f);
            startposition = true;
        }

        if (Input.GetKey(KeyCode.UpArrow) && startposition && !(gameObject.name.Contains("(Clone)")))
        {
            GetComponent<Rigidbody>().AddForce(0, 300, 0);
            startposition = false;
            //GetComponent<Rigidbody>();
        }
        if (startposition == false)
        {
            rb.velocity = 5 * (rb.velocity.normalized);
        }

   
        // das it für den clone Ball damit der auch ein geschwindichkeit hat
        if ((gameObject.name.Contains("(Clone)")))
        {
            rb.velocity = 5 * (rb.velocity.normalized);
          
        }
        

    }
}

