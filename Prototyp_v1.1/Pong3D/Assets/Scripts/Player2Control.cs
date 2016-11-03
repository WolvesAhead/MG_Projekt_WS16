using UnityEngine;
using System.Collections;

public class Player2Control : MonoBehaviour 
{
	public GameObject playerPaddle;
    public Rigidbody rbball;
    public GameObject upperBorder;

    private float speed = 6f;
    private float rightLimit;
    private float leftLimit;

    void Start() 
	{
       
    }

    void Update()
    {
        leftLimit = upperBorder.GetComponent<Renderer>().bounds.min.x + (transform.localScale.x / 2);  // 0,75 ist die hälfte unsere paddle (-6,25 + 0,75 = -5,5) ==> genau unesere limit
        rightLimit = upperBorder.GetComponent<Renderer>().bounds.max.x - (transform.localScale.x / 2);
        /* if (transform.position.x < -5.2f)
         {
             transform.position = new Vector3(-5.2f, transform.position.y, transform.position.z);
         }
         if (transform.position.x > 5.2f)
         {
             transform.position = new Vector3(5.2f, transform.position.y, transform.position.z);
         }*/
        if (Input.GetKey(KeyCode.D) && transform.position.x < rightLimit)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > leftLimit)
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
            	float winkelX = winkel / 0.75f; //(transform.localScale.x / 2)

            // "Winkel" errechnung 
            if (transform.position.x < rightLimit && transform.position.x > leftLimit) // damit den ball nicht das paddle folgt wenn das hackt und geht mehr als die grennzung
            {
                rbball.velocity = new Vector3(winkelX * 7, rbball.velocity.y, 0);
            }
               
  				Debug.Log(contact.point.x);
            }

        //////////////////BIGP PADDLE ITEM\\\\\\\\\\\\\\\\\\

        if (collision.transform.tag == "bigPaddle")
        {

            this.gameObject.transform.localScale += new Vector3(1f, 0, 0);

        }

        //////////////////mehr bälle ITEM\\\\\\\\\\\\\\\\\\

        if (collision.transform.tag == "mehrbaelle")
        {

            Rigidbody ItemInstance;
            Debug.Log("ball++");
            ItemInstance = Instantiate(rbball, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody;
            ItemInstance.AddForce(0, -150, 0);

        }
    }
    }