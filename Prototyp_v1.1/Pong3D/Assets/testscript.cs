using UnityEngine;
using System.Collections;

public class testscript : MonoBehaviour {

	public GameObject ball;
	
	// Use this for initialization
	void Start() 
	{
		transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, 5f);
	}
	
	// Update is called once per frame
	void Update() 
	{
		if(Player1Control.powerballstatus == true)
		{
			transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, -0.7f);
		}	
	}
}
