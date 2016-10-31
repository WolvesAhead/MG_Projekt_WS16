using UnityEngine;
using System.Collections;

public class Player1Control : MonoBehaviour 
{
	public GameObject playerPaddle;
    public GameObject bottomBorder;
    public Rigidbody rbball;

    private float speed = 6f;
    private float rightLimit;
    private float leftLimit;

	void Start() 
	{
        // left limit ist der wert von der punkt der am ende links auf dem bottomBorder liegt und zwar "-6,25 "
        // genau das gleiche geht für rightLimit 
        leftLimit = bottomBorder.GetComponent<Renderer>().bounds.min.x + 0.75f ; // 0,75 ist die hälfte unsere paddle (-6,25 + 0,75 = -5,5) ==> genau unesere limit
        rightLimit = bottomBorder.GetComponent<Renderer>().bounds.max.x - 0.75f ;
        Debug.Log("RightLimit" + rightLimit + "and Left Limit: " + leftLimit);
	
	}

    void Update()
    {
       /* if (transform.position.x < -5.1f)
        {
            transform.position = new Vector3(-5.1f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 5.1f)
        {
            transform.position = new Vector3(5.1f, transform.position.y, transform.position.z);
        }*/

        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < rightLimit - 0.1)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > leftLimit + 0.1)
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
                if ((collision.transform.tag == "ball" || collision.transform.tag == "ball2") && transform.position.x < rightLimit - 0.1 && transform.position.x > leftLimit + 0.1 ) // damit den ball nicht das paddle folgt wenn das hackt und geht mehr als die grennzung
                 {
                   rbball.velocity = new Vector3(winkelX * 7, rbball.velocity.y, 0);
            }else { Debug.Log("Bug"); }
            	

  				Debug.Log(contact.point.x);
            }



        }

        /* void OnCollisionEnter(Collision col)
         {
             if (col.gameObject.name == "LeftBorder")
             {
                 playerPaddle.transform.position = new Vector3(-5.37f, -4.7f,-0.81f);
             }
         }*/
    }
