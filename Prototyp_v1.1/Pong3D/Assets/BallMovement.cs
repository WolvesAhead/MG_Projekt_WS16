using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour 
{
	public float yspeed = 5f;
	public float xspeed = 0f;
	public Rigidbody rb;
    public GameObject paddle;
    HingeJoint kleben;
    

	void Start() 
	{
		rb = GetComponent<Rigidbody>();
		//Anfangsbewegung
		rb.velocity = new Vector3(xspeed, yspeed, 0);
		Debug.Log("start");
        kleben = GetComponent<HingeJoint>();

    }
	
	void Update() 
	{
		//Punkte in der Konsole und neue Angabe
		if(rb.position.y > 5.5)
		{
			Debug.Log("player 1 point");
			Serve();
		}
		if(rb.position.y < -5.5)
		{
			Debug.Log("player 2 point");
			Serve();
		}
	}

	void Serve()
	{

       // 

        rb.position = new Vector3(paddle.transform.position.x, paddle.transform.position.y + 2f, 0);
    }

    void OnCollisionEnter(Collision col)
	{
		//Collisiondetection
		foreach(ContactPoint contact in col.contacts)
		{
			/*Vorerst Unterscheidung durch Koordinaten, weiß noch nicht wie ich hier erkenne welches
			Objekt getroffen wurde. Wenn wir das haben können wir alles ersetzen und unten mit Destroy('rigidbody')
			gezielt den getroffenen Block zerstören. Erstmal also nur damit was läuft*/
			if(rb.position.x > 6.33 || rb.position.x < -6.33)
			{
				Debug.Log("wallhit");
				xspeed *= -1;
				rb.velocity = new Vector3(xspeed, yspeed, 0);
			}
			else if(rb.position.y > 4 || rb.position.y < -4)
			{
				Debug.Log("playerhit");
				yspeed *= -1;
				rb.velocity = new Vector3(xspeed, yspeed, 0);
			}
			else
			{
				Debug.Log("brickhit");
				yspeed *= -1;
				rb.velocity = new Vector3(xspeed, yspeed, 0);
				//Destroy();
			}
		}
	}
}