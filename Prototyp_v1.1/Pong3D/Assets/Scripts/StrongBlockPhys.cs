using UnityEngine;
using System.Collections;

public class StrongBlockPhys : MonoBehaviour {

    public Rigidbody[] RbitemPrefab;
    public int blockHealth = 3;


    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update() { }


    void OnCollisionEnter(Collision col)
    {
        blockHealth -= 1;
        if (blockHealth == 0)
        {

            int random = Random.Range(0, 2);
            Debug.Log("Random range (0,2)" + random);
            if (col.transform.tag == "ball" && random == 1)
            {
                Rigidbody ItemInstance;
                int i = Random.Range(0, 4);
                ItemInstance = Instantiate(RbitemPrefab[i], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody;
                ItemInstance.AddForce(0, -150, 0);
                Debug.Log("RandomItemwert:" + i);
            }

            if (col.transform.tag == "ball2" && random == 1)
            {
                Rigidbody ItemInstance;
                int i = Random.Range(0, 4);
                ItemInstance = Instantiate(RbitemPrefab[i], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody;
                ItemInstance.AddForce(0, 150, 0);
                Debug.Log("RandomItemwert:" + i);
            }

            Destroy(gameObject);

        }
    }


}