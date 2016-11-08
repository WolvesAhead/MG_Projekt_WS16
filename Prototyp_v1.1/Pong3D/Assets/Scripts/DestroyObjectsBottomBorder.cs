using UnityEngine;
using System.Collections;

public class DestroyObjectsBottomBorder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.transform.tag == "ball" || col.gameObject.transform.position.y > 4)
        {
            Player1Control.player1Score += 500;
            Player2Control.player2Score -= 500;
            MyBallsScript.anzahlBälle1--;
            Destroy(col.gameObject);

            if(MyBallsScript.anzahlBälle1 == 0)
            {
                
                Invoke("MyBallsScript.Serve", 2);
            }
        }

        if (col.gameObject.transform.tag == "ball2" || col.gameObject.transform.position.y < -4)
        {
            Player2Control.player2Score += 500;
            Player1Control.player1Score -= 500;
            //MyBallsScript.anzahlBälle1--;
            Destroy(col.gameObject);
        }

    }
}
