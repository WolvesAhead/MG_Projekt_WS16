using UnityEngine;
using System.Collections;

public class Player1Control : MonoBehaviour
{
    public static GameObject playerPaddle;
    public GameObject bottomBorder;

    public GameObject shield;
    public Rigidbody rbball;
    public Rigidbody rbball2;
    public GameObject ball;


    private float speed = 6f;
    public static float rightLimit;
    public static float leftLimit;
    public static Rigidbody ItemInstance;
    

    public bool shieldstatus = false;
    public static bool firstballisHere = false;
    public static bool isClone = false;
    public static bool powerballstatus = false;
    public static bool powerballCollected = false;
    public static bool gluestatus = false;
    public static bool glued = false;


    public static int player1Score;
    public static int controlChange;
    public float controlChangeTime = 5f;
    public float shieldTime = 8f;
    public float glueTime = 15f;
    float contactPointGlue;


    void Start()
    {
        Debug.Log(transform.localScale.x / 2);
    }

    void Update()
    {

        // left limit ist der wert von der punkt der am ende links auf dem bottomBorder liegt und zwar "-6,25 "
        // genau das gleiche geht für rightLimit 

        leftLimit = bottomBorder.GetComponent<Renderer>().bounds.min.x + (transform.localScale.x / 2); // 0,75 ist die hälfte unsere paddle (-6,25 + 0,75 = -5,5) ==> genau unesere limit
        rightLimit = bottomBorder.GetComponent<Renderer>().bounds.max.x - (transform.localScale.x / 2);

      //   float paddlepoint = transform.position.x;


        #region Controlchange
        // ControllChange 
        if (controlChange >= 1)
        {
            //Timer
            controlChangeTime -= Time.deltaTime;
            if (controlChangeTime < 0)
            {
                controlChange = 0;
                controlChangeTime = 5f;
            }

            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x > leftLimit + 0.1)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;


            }
            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x < rightLimit - 0.1)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
        else
        {
            // Steuerung

            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < rightLimit - 0.1)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > leftLimit + 0.1)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }

        }

        #endregion

        #region Shield
        // shield activation      
        if (shieldstatus)
        {
            shieldTime -= Time.deltaTime;
            shield.SetActive(true);


            if (shieldTime < 0)
            {
                shieldstatus = false;
                shieldTime = 8f;

            }
        }
        else
        {
            shield.SetActive(false);
        }

        #endregion

        #region Glue
        // glue activation      
        if (gluestatus)
        {

            glueTime -= Time.deltaTime;
            if (glued == true )
            {
                if (isClone == false)
                rbball.transform.position = new Vector3((transform.position.x + contactPointGlue), -4.4f, -0.7f);

                if (isClone)
                    ItemInstance.transform.position = new Vector3((transform.position.x + contactPointGlue), -4.4f, -0.7f);

            }

            if (glueTime < 0)
            {
                gluestatus = false;
                glueTime = 15f;
                glued = false;
                firstballisHere = false;

            }
        }
        else
        {
                 // für dich Martin 
        }

        #endregion

    }


    void OnCollisionEnter(Collision collision)
    {


        /*foreach (ContactPoint contact in collision.contacts)
            {
            	//Punkt auf dem Paddle
            	float winkel = contact.point.x - transform.position.x;

            //Wert zur Winkelberechnung an Hand der Paddle länge
            float winkelX = winkel / (transform.localScale.x / 2);
            Debug.Log("paddlescale"+ (transform.localScale.x / 2));

            // "Winkel" errechnung 
            if (!(rbball.name.Contains("(Clone)")) && collision.transform.tag == "ball" && transform.position.x < rightLimit - 0.1 && transform.position.x > leftLimit + 0.1) // damit den ball nicht das paddle folgt wenn das hackt und geht mehr als die grennzung
            {
                    
                    rbball.velocity = new Vector3(winkelX * 5, rbball.velocity.y, 0);
                              
            }
            if (!(rbball2.name.Contains("(Clone)")) && collision.transform.tag == "ball2" && transform.position.x < rightLimit - 0.1 && transform.position.x > leftLimit + 0.1)
            {
                
                    rbball2.velocity = new Vector3(winkelX * 5, rbball2.velocity.y, 0);
               
            }


            //Debug.Log(contact.point.x);
        }
        */
        #region ITEMS
        //////////////////BIGP PADDLE ITEM\\\\\\\\\\\\\\\\\\

        if (collision.transform.tag == "bigPaddle")
        {
            if (this.gameObject.transform.localScale.x <= 3)
                this.gameObject.transform.localScale += new Vector3(1, 0, 0);

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


            DestroyObjectsBottomBorder.ballCount1++;
            Debug.Log("ball++. Du hast jetzt " + DestroyObjectsBottomBorder.ballCount1 + " Bälle");
            ItemInstance = Instantiate(rbball, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity) as Rigidbody;
            ItemInstance.AddForce(0, 150, 0);
           


        }

        ///////////////// Steuerung umkehren \\\\\\\\\\\\\\\\
        if (collision.transform.tag == "ControlChange")
        {
            Debug.Log("Rechts is jetzt Links");

            Player2Control.controlChange += 1;

            /*if (Input.GetKey(KeyCode.RightArrow) && (transform.position.x > rightLimit - 0.1))
            {
                transform.position += Vector3.left * speed * Time.deltaTime;

            }
            if (Input.GetKey(KeyCode.LeftArrow)  && (transform.position.x < leftLimit + 0.1))
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            } 
            */
        }


        ///////////////// Shield Item \\\\\\\\\\\\\\\\

        if (collision.transform.tag == "shieldItem")
        {
            shieldstatus = true;
        }

        ///////////////// Powerball Item \\\\\\\\\\\\\\\\
        if (collision.transform.tag == "powerballItem")
        {
            powerballCollected = true;
        }
        if (powerballCollected == true && collision.transform.tag == "ball")
        {
            powerballstatus = true;
            powerballCollected = false;
        }

        ///////////////// Glue Item \\\\\\\\\\\\\\\\
        if (collision.transform.tag == "glueItem")
        {
            gluestatus = true;
            firstballisHere = true;

            Debug.Log("Bam");
        }

        if (collision.transform.tag == "ball"  && gluestatus == true)
        {
            Debug.Log("Bam2");

           
            if ((collision.gameObject.name.Contains("(Clone)")))
            {
                isClone = true;
                Debug.Log("isClone");

            }
            else
            {
                isClone = false;
                Debug.Log("isNotClone");

            }

            foreach (ContactPoint contact in collision.contacts)
            {
                contactPointGlue = contact.point.x - transform.position.x;

            }
            glued = true;
        }


       


        #endregion





    }
}
