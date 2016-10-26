using UnityEngine;
using System.Collections;

public class Player2Control : MonoBehaviour 
{
	public GameObject playerPaddle;
    public GameObject ball;
    public Rigidbody rbball;
    private float speed = 6f;

	void Start() 
	{
	
	}

    void Update()
    {
        if (transform.position.x < -5.2f)
        {
            transform.position = new Vector3(-5.2f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 5.2f)
        {
            transform.position = new Vector3(5.2f, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

    }
        void OnCollisionEnter(Collision collision) {
            foreach (ContactPoint contact in collision.contacts)
            {
            	//Punkt auf dem Paddle
            	float winkel = contact.point.x - transform.position.x;

            	//Wert zur Winkelberechnung an Hand der Paddle länge
            	float winkelX = winkel / 0.75f;

            	// "Winkel" errechnung 
            	rbball.velocity = new Vector3(winkelX*7,rbball.velocity.y ,0);

  				Debug.Log(contact.point.x);
            }
        }
    }