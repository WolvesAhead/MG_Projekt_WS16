using UnityEngine;
using System.Collections;

public class Player2Control : MonoBehaviour 
{
	public GameObject playerPaddle;
    public Rigidbody rbball;
    public Rigidbody rbball2;
    public GameObject nebel;
    public GameObject shield;
    public GameObject upperBorder;

    private float speed = 6f;
    private float rightLimit;
    private float leftLimit;
    public bool nebelstatus = false;
    public bool shieldstatus = false;
    public static bool powerballstatus = false;
    public static bool powerballCollected = false;
    public static bool gluestatus = false;
    public static bool curveballstatus = false;
    public static bool glued = false;


    public static int player2Score = 0;
    public static int controlChange;
    private float controlChangeTime = 5f;
    float NebelTime = 15f;
    float shieldTime = 8f;
    float glueTime = 15f;
    float curveballTime = 5f;
    float contactPointGlue;

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



        #region curveBall

        if (curveballstatus)
        {
            curveballTime -= Time.deltaTime;

            if (Input.GetKey(KeyCode.D) && rbball2.transform.position.x < rightLimit - 0.1)
            {
                rbball2.transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A) && rbball2.transform.position.x > leftLimit + 0.1)
            {
                rbball2.transform.position += Vector3.left * speed * Time.deltaTime;
            }


            if (curveballTime < 0)
            {
                curveballstatus = false;
                curveballTime = 5f;

            }
        }

        #endregion

        #region Nebel
        // nebel activation      
        if (nebelstatus)
        {
            Debug.Log("nebel activ!");
            NebelTime -= Time.deltaTime;
            //nebel.GetComponent<ParticleSystem>().Play();
            nebel.SetActive(true);


            if (NebelTime < 0)
            {
                nebelstatus = false;
                NebelTime = 15f;

            }
        }
        else
        {
            //nebel.GetComponent<ParticleSystem>().Stop();
            nebel.SetActive(false);
        }

        #endregion

        #region Shield
        // nebel activation      
        if (shieldstatus)
        {
            shieldTime -= Time.deltaTime;
            //nebel.GetComponent<ParticleSystem>().Play();
            shield.SetActive(true);


            if (shieldTime < 0)
            {
                shieldstatus = false;
                shieldTime = 8f;

            }
        }
        else
        {
            //nebel.GetComponent<ParticleSystem>().Stop();
            shield.SetActive(false);
        }

        #endregion

        #region Controlchange
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

        #endregion
        
        
            if (Input.GetKey(KeyCode.D) && transform.position.x < rightLimit)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A) && transform.position.x > leftLimit)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        

        #region Glue
        // glue activation      
        if (gluestatus)
        {
            glueTime -= Time.deltaTime;
            if (glued == true)
            {
                /*Debug.Log("cp "+contactPointGlue);
                Debug.Log("pp "+paddlepoint);
                Debug.Log("bp "+ (transform.position.x-contactPointGlue));*/

                //float ballaufpaddle = transform.position.x-contactPointGlue;
                //rbball.transform.position = new Vector3(rbball.transform.position.x, -4.4f, -0.7f);
                //Debug.Log("ballauufpaddle"+(paddlepoint+((ballaufpaddle)*-1)));*/

                /*if (Input.GetKey(KeyCode.RightArrow) && rbball.transform.position.x < rightLimit - 0.1)
           {
               rbball.transform.position += Vector3.right * speed * Time.deltaTime;
           }
           if (Input.GetKey(KeyCode.LeftArrow) && rbball.transform.position.x > leftLimit + 0.1)
           {
               rbball.transform.position += Vector3.left * speed * Time.deltaTime;
           }*/
                rbball.transform.position = new Vector3((transform.position.x + contactPointGlue), -4.4f, -0.7f);






                if (Input.GetKey(KeyCode.UpArrow))
                {
                    rbball.AddForce(0, 300, 0);
                    glued = false;
                }
            }

            if (glueTime < 0)
            {
                gluestatus = false;
                glueTime = 15f;

            }
        }
     

        #endregion

    }
    void OnCollisionEnter(Collision collision) {
      /*  foreach (ContactPoint contact in collision.contacts)
        {
            //Punkt auf dem Paddle
            float winkel = contact.point.x - transform.position.x;

            //Wert zur Winkelberechnung an Hand der Paddle länge
            float winkelX = winkel / (transform.localScale.x / 2); //(transform.localScale.x / 2)

            // "Winkel" errechnung 
            if (!(rbball.name.Contains("(Clone)")) && collision.transform.tag == "ball" && transform.position.x < rightLimit - 0.1 && transform.position.x > leftLimit + 0.1) // damit den ball nicht das paddle folgt wenn das hackt und geht mehr als die grennzung
            {

                rbball.velocity = new Vector3(winkelX * 5, rbball.velocity.y, 0);
            }
            if (!(rbball2.name.Contains("(Clone)")) && collision.transform.tag == "ball2" && transform.position.x < rightLimit - 0.1 && transform.position.x > leftLimit + 0.1)
            {
                rbball2.velocity = new Vector3(winkelX * 5, rbball2.velocity.y, 0);
            }
        }
        */
        #region Items
        //////////////////BIGP PADDLE ITEM\\\\\\\\\\\\\\\\\\

        if (collision.transform.tag == "bigPaddle")
        {
            if (this.gameObject.transform.localScale.x <= 3)
            {
                this.gameObject.transform.localScale += new Vector3(1f, 0, 0);
            }
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
            DestroyObjectsBottomBorder.ballCount2++;
            Debug.Log("ball++");
            ItemInstance = Instantiate(rbball2, new Vector3(transform.position.x, transform.position.y-1f, transform.position.z), Quaternion.identity) as Rigidbody;
            ItemInstance.AddForce(0, -150, 0);

        }

        ///////////////// Steuerung umkehren \\\\\\\\\\\\\\\\
        if (collision.transform.tag == "ControlChange")
        {
            Debug.Log("Rechts is jetzt Links");

            Player1Control.controlChange += 1;
        }


        ///////////////// Nebel Item \\\\\\\\\\\\\\\\

        if (collision.transform.tag == "nebelItem")
        {
            nebelstatus = true;

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
        if(powerballCollected == true && collision.transform.tag == "ball2")    
        {
            powerballstatus = true;
            powerballCollected = false;
        }

        ///////////////// Glue Item \\\\\\\\\\\\\\\\
        if (collision.transform.tag == "glueItem")
        {
            gluestatus = true;
            Debug.Log("Bam");
        }

        if (collision.transform.tag == "ball" && gluestatus == true)
        {
            Debug.Log("Bam2");
            foreach (ContactPoint contact in collision.contacts)
            {
                contactPointGlue = contact.point.x - transform.position.x;

            }
            glued = true;
        }

        ///////////////// Curveball Item \\\\\\\\\\\\\\\\
        if (collision.transform.tag == "curveballItem")
        {
            curveballstatus = true;
        }
        #endregion
    }
}
