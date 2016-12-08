using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

    public int player1Life;
    public int player2Life;
    bool LifesCount = false;
    public Image Healthbar1;
    public Image Healthbar2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float lifeBorder1 = player1Life * 0.2f;
        float lifeBorder2 = player2Life * 0.2f;
        //Pause und Battlemodus
        if (BlockPhys.brickZähler == 0)
        {
            if (LifesCount == false)
            {
                countLifes();

            }
        if (LifesCount == true)
                {

                    if (Player1Control.player1Score > 0)
                    {
                    Player1Control.player1Score -= 50;
                    }

                    if (Healthbar1.fillAmount < lifeBorder1)
                    {
                        Healthbar1.fillAmount += 0.005f;
                    }



                if (Player2Control.player2Score > 0)
                {
                    Player2Control.player2Score -= 50;
                }
                    if (Healthbar2.fillAmount < lifeBorder2)
                    {
                        Healthbar2.fillAmount += 0.005f;
                    }

                    
                

               
                }
            
        }
        
	
	}

    void countLifes()
    {
        player1Life = (Player1Control.player1Score / 1000);
        player2Life = (Player2Control.player2Score / 1000);
        Debug.Log("Leben Spieler 2:" + player2Life);
        Debug.Log("Leben Spieler 1:" + player1Life);
        LifesCount = true;
    }
}
