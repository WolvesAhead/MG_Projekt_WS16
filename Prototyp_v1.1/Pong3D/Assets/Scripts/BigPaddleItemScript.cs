using UnityEngine;
using System.Collections;

public class BigPaddleItemScript : MonoBehaviour {

    // Use this for initialization
   GameObject paddle;
	void Start () {
	paddle = GameObject.Find("Player1Paddle");
    }
	
	// Update is called once per frame
	void Update () {

        
	
	}
    void OncollisonEnter (Collision col)
    {
        if (col.gameObject.transform.tag == "Player1paddle")
        paddle.gameObject.transform.localScale += new Vector3(3f, 0, 0);
    }
}
