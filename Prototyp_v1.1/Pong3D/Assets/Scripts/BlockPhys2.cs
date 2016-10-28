using UnityEngine;
using System.Collections;

public class BlockPhys2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "ball2")
        {
            Destroy(gameObject);
        }

    }
}
