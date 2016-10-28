using UnityEngine;
using System.Collections;

public class BlockPhys : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "ball")
        {
            Destroy(gameObject);
        }
        
    }
}
