using UnityEngine;
using System.Collections;

public class MyBallsScript2 : MonoBehaviour {


    public Rigidbody rb;
    bool startposition = true;
    public GameObject playerPaddle;


    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        // FÜr die Score Berechnung.Tore für Spieler 2.
        if (transform.position.y < -5)
        {
            Player2Control.player2Score += 500;
            Player1Control.player1Score -= 500;
            if(Player1Control.player1Score <= 0)
            {
                Player1Control.player1Score = 0;
            }
            Debug.Log("TOOOOR für Player 2 !! Player1: " + Player1Control.player1Score + " Player2: " + Player2Control.player2Score);
        }

        if ((startposition == true || transform.position.y < -5f || transform.position.y > 5f) && !(gameObject.name.Contains("(Clone)")))
        {
            transform.position = new Vector3(playerPaddle.transform.position.x, 4.4f, -0.7f);
            startposition = true;
        }

        if (Input.GetKey(KeyCode.W) && startposition && !(gameObject.name.Contains("(Clone)")))
        {
            GetComponent<Rigidbody>().AddForce(0, -300, 0);
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
