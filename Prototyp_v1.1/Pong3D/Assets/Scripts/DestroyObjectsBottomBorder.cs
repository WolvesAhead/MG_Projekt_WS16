using UnityEngine;
using System.Collections;

public class DestroyObjectsBottomBorder : MonoBehaviour 
{

    public MyBallsScript mbs;       //Instanzierung um Funktionen anderer Scripte aufzurufen
    public MyBallsScript2 mbs2;
    public static int ballCount1 = 1;       //Anzahl Bälle
    public static int ballCount2 = 1;

	// Use this for initialization
	void Start() 
    {
	   
	}
	
	// Update is called once per frame
	void Update() 
    {

	}

    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.transform.tag == "ball")
        {
            if(col.gameObject.transform.position.y > 4)  //Ball 1 trifft Border oben
            {
                if(col.gameObject.name.Contains("(Clone)"))     //Wenn Klon -> zerstören, Punkte und Zähler runter
                {
                    Destroy(col.gameObject);
                    Player1Control.player1Score += 500;
                    Player2Control.player2Score -= 500;
                    ballCount1--;
                }
                else                 //Wenn nicht Klon = Hauptball -> Punkte, Standbyfunktion aufrufen und Zähler runter
                {
                    Player1Control.player1Score += 500;
                    Player2Control.player2Score -= 500;
                    mbs.Standby();
                    ballCount1--;
                }
                //Erstmal weggelassen. Später nur Punkte verlieren wenn der andere mehr als 500 hat
                /*if(Player2Control.player2Score >= 500)
                {*/
                if(ballCount1 == 0)     //Wenn durch eins davon Anzahl Bälle = 0 wird, Zähler wieder auf 1 und Serve Funktion aufrufen
                {
                    ballCount1++;
                    mbs.Serve();
                }
                //}
            }

            else if(col.gameObject.transform.position.y < -4)  //Ball 1 trifft Border unten alles genauso nur gibt keine Punkte
            {
                if(col.gameObject.name.Contains("(Clone)"))      
                {
                    Destroy(col.gameObject);
                    ballCount1--;
                }
                else
                {
                    mbs.Standby();
                    ballCount1--;
                }
                if(ballCount1 == 0)
                {
                    ballCount1++;
                    mbs.Serve();
                }
            }  
        }

        if(col.gameObject.transform.tag == "ball2")
        {
            if(col.gameObject.transform.position.y < -4)
            {
                if(col.gameObject.name.Contains("(Clone)"))
                {
                    Destroy(col.gameObject);
                    /*if(Player1Control.player1Score >= 500)
                    {*/
                        Player2Control.player2Score += 500;
                        Player1Control.player1Score -= 500;
                    //}
                    ballCount2--;
                }
                else
                {
                    /*if(Player1Control.player1Score >= 500)
                    {*/
                        Player2Control.player2Score += 500;
                        Player1Control.player1Score -= 500;
                    //}
                    mbs2.Standby();
                    ballCount2--;
                }
                if(ballCount2 == 0)
                {
                    ballCount2++;
                    mbs2.Serve();
                }
            }
            else if(col.gameObject.transform.position.y > 4)  
            {
                if(col.gameObject.name.Contains("(Clone)"))
                {
                    Destroy(col.gameObject);
                    ballCount2--;
                }
                else
                {
                    mbs2.Standby();
                    ballCount2--;
                }
                if(ballCount2 == 0)
                {
                    ballCount2++;
                    mbs2.Serve();
                }
            }  
        }

    }
}
