using UnityEngine;
using System.Collections;

public class MyBallsScript : MonoBehaviour {
    public Rigidbody rb;
    bool startposition = true;
    public GameObject playerPaddle;


    // Use this for initialization
    void Start () {
       
       

    }

    // Update is called once per frame
    void Update() {
            if (startposition == true || transform.position.y < -5f || transform.position.y > 5f)
        {
            transform.position = new Vector3(playerPaddle.transform.position.x, -4.3f, -0.7f);
            startposition = true;
        }

        if (Input.GetKey(KeyCode.UpArrow) && startposition)
        {
            GetComponent<Rigidbody>().AddForce(0, 300, 0);
            startposition = false;
            //GetComponent<Rigidbody>();
        }
        if (startposition == false)
        {
            rb.velocity = 5 * (rb.velocity.normalized);
        }
        
    }
}

