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

    public static int player2Score = 1000;
    private int controlChange;
    private float controlChangeTime = 5f;

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

        // ControllChange 
        if (controlChange == 1)
        {

            //Timer
            controlChangeTime -= Time.deltaTime;
            if (controlChangeTime < 0)
            {
                controlChange -= 1;
                controlChangeTime = 5f;
            }

            if (Input.GetKey(KeyCode.D)  && transform.position.x > leftLimit + 0.1)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
          

            }
            if (Input.GetKey(KeyCode.A)  && transform.position.x < rightLimit - 0.1)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }

        else
        {
            if (Input.GetKey(KeyCode.D) && transform.position.x < rightLimit)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A) && transform.position.x > leftLimit)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
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

        //////////////////Small PADDLE ITEM- Bug verhindert, dass die X Größe ins Negative gerät und somit wieder größer wird\\\\\\\\\\\\\\\\\\

        if (collision.transform.tag == "smallPaddle")
        {
            if (this.gameObject.transform.localScale.x >= 1)
            {
                this.gameObject.transform.localScale -= new Vector3(1, 0, 0);
            }
        }


        //////////////////mehr bälle ITEM\\\\\\\\\\\\\\\\\\

        if (collision.transform.tag == "mehrbaelle")
        {

            Rigidbody ItemInstance;
            Debug.Log("ball++");
            ItemInstance = Instantiate(rbball, new Vector3(transform.position.x, transform.position.y-1f, transform.position.z), Quaternion.identity) as Rigidbody;
            ItemInstance.AddForce(0, -150, 0);

        }

        ///////////////// Steuerung umkehren \\\\\\\\\\\\\\\\
        if (collision.transform.tag == "ControlChange")
        {
            Debug.Log("Rechts is jetzt Links");

            controlChange += 1;
        }
        }
    }