using UnityEngine;
using System.Collections;

public class DestroyObjectsBottomBorder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.transform.tag == "ball" || col.gameObject.transform.tag == "ball2")
        {
            Destroy(col.gameObject);
        }
       
    }
}
