using UnityEngine;
using System.Collections;

public class MyBallsScript : MonoBehaviour {
    public Rigidbody rb;
    
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().AddForce(0, 300, 0);
        //GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {

        rb.velocity = 5 * (rb.velocity.normalized);
    }
}

