using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyBallsScript2 : MonoBehaviour {


    public Rigidbody rb;
    bool startposition = true;
    public GameObject playerPaddle;
    public Text scoreText2;


    // Use this for initialization
    void Start()
    {


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
}
