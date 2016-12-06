using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player2Control : MonoBehaviour 
{
	public GameObject playerPaddle;
    public Rigidbody rbball;
    public Rigidbody rbball2;
    public GameObject shield;
    public GameObject upperBorder;

    private float speed = 6f;
    private float rightLimit;
    private float leftLimit;
    public static bool shieldstatus = false;
    public static bool firstballisHere = false;
    public static bool controlChange = false;
    public static bool gluestatus = false;

    public static Rigidbody ItemInstance;
    public static bool isClone = false;
    public static bool powerballstatus = false;
    public static bool powerballCollected = false;
    public static bool glued = false;



    public static int player2Score = 0;
    //public static GameObject controlchangelight;
    private float controlChangeTime = 5f;
    public float shieldTime = 8f;
    public float glueTime = 15f;

    float contactPointGlue;

    public Image circleShield;
    public Image circleGlue;
    public Image circleControlChange;

    float speedItemTimerShield = 8f;
    float speedItemTimerGlue = 15f;
    float speedItemTimerControlChange = 5f;


    void Start() 
	{
       // controlchangelight = GameObject.Find("lightControlChange");
    }

    void Update()
    {
        leftLimit = upperBorder.GetComponent<Renderer>().bounds.min.x + (transform.localScale.x / 2);  // 0,75 ist die hälfte unsere paddle (-6,25 + 0,75 = -5,5) ==> genau unesere limit
        rightLimit = upperBorder.GetComponent<Renderer>().bounds.max.x - (transform.localScale.x / 2);
      
        #region Shield
        // shield activation      
        if (shieldstatus)
        {
            shieldTime -= Time.deltaTime;
            circleShield.fillAmount = speedItemTimerShield / 8;
            speedItemTimerShield -= Time.deltaTime;          
            shield.SetActive(true);


            if (shieldTime < 0)
            {
                speedItemTimerShield = 8;
                circleShield.fillAmount = 0;
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
        if (controlChange)
        {

            //Timer
            controlChangeTime -= Time.deltaTime;
            circleControlChange.fillAmount = speedItemTimerControlChange / 5;
            speedItemTimerControlChange -= Time.deltaTime;

            if (controlChangeTime < 0)
            {
                //controlchangelight.SetActive(false);
                speedItemTimerControlChange = 5;
                circleControlChange.fillAmount = 0;
                controlChange = false;
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

        #endregion

        #region Glue
        // glue activation      
        if (gluestatus)
        {
            glueTime -= Time.deltaTime;
            circleGlue.fillAmount = speedItemTimerGlue / 15;
            speedItemTimerGlue -= Time.deltaTime;
            if (glued == true)
            {
                if (isClone == false)
                    rbball2.transform.position = new Vector3((transform.position.x + contactPointGlue), 4.44f, -0.7f);

                if (isClone)
                    ItemInstance.transform.position = new Vector3((transform.position.x + contactPointGlue), 4.44f, -0.7f);

               
            }

            if (glueTime < 0)
            {
                speedItemTimerGlue = 15f;
                gluestatus = false;
                circleGlue.fillAmount = 0;

                gluestatus = false;
                glueTime = 15f;
                firstballisHere = false;

            }
        }
     

        #endregion

    }
    void OnCollisionEnter(Collision collision) {
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

         
            DestroyObjectsBottomBorder.ballCount2++;
            Debug.Log("ball++");
            ItemInstance = Instantiate(rbball2, new Vector3(transform.position.x, transform.position.y-1f, transform.position.z), Quaternion.identity) as Rigidbody;
            ItemInstance.AddForce(0, -150, 0);

        }

        ///////////////// Steuerung umkehren \\\\\\\\\\\\\\\\
        if (collision.transform.tag == "ControlChange")
        {
            Debug.Log("Rechts is jetzt Links");

            Player1Control.controlChange  = true;
            
          
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

        if (collision.transform.tag == "ball2" && gluestatus == true)
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
