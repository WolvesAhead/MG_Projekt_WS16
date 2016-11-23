using UnityEngine;
using System.Collections;

public class BlockPhys : MonoBehaviour {

 
    public Rigidbody[] RbitemPrefab;


    // Use this for initialization
    void Start () {
    

    }

    // Update is called once per frame
    void Update() { }

    void OnTriggerEnter(Collider other)
    {
        Player1Control.player1Score += 50;
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        int random = Random.Range(0, 2);
        //Debug.Log("Random range (0,2)" + random);
        if (col.transform.tag == "ball" && random == 1)
        {
            Rigidbody ItemInstance;
            int i = Random.Range(0, 7);
          
                ItemInstance = Instantiate(RbitemPrefab[i], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody;
                ItemInstance.AddForce(0, -150, 0);
           
         

            //Debug.Log("RandomItemwert:" + i);
        }

        if (col.transform.tag == "ball2" && random == 1)
        {
            Rigidbody ItemInstance;
            int i = Random.Range(0, 7);
        
                ItemInstance = Instantiate(RbitemPrefab[i], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody;
                ItemInstance.AddForce(0, 150, 0);
            
            // Debug.Log("RandomItemwert:" + i);
        }

        if (col.transform.tag == "ball")
        {
            Player1Control.player1Score += 50;
            Destroy(gameObject);
        }

        if (col.transform.tag == "ball2")
        {
            Player2Control.player2Score += 50;
            Destroy(gameObject);
        }

        //Debug.Log("Player1: " + Player1Control.player1Score + " Player2: " + Player2Control.player2Score);

    }
    

   }


  
