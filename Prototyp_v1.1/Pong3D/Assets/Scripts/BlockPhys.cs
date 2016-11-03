using UnityEngine;
using System.Collections;

public class BlockPhys : MonoBehaviour {

    public GameObject itemPrefab;
    public Rigidbody RbitemPrefab;

	// Use this for initialization
	void Start () {
       
    }

    // Update is called once per frame
    void Update() { }


        void OnCollisionEnter(Collision col)
            {
        int random = Random.Range(0, 5);
        if (col.transform.tag == "ball" && random == 3)
        {
            Rigidbody ItemInstance;
            ItemInstance = Instantiate(RbitemPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody;
            ItemInstance.AddForce(0, -150, 0);
        }

        if (col.transform.tag == "ball2"  && random == 3)
        {
            Rigidbody ItemInstance;
            ItemInstance = Instantiate(RbitemPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody;
            ItemInstance.AddForce(0, 150, 0);
        }

        Destroy(gameObject);
              
                
            
                
            }

   }


  
