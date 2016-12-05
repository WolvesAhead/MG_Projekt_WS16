using UnityEngine;
using System.Collections;

public class BlockPhys : MonoBehaviour {

 
    public Rigidbody[] RbitemPrefab;
    private int chanceItem;
    private int i;

    // Use this for initialization
    void Start () {
    

    }

    // Update is called once per frame
    void Update() { }

    #region itemChance
    void itemChance()
    {
        chanceItem = Random.Range(0, 100);

      
            //Paddle Big 25%
            if (chanceItem >= 0 && chanceItem <= 25)
            {
                i = 0;
            }

            //Paddle small 20%
            else if (chanceItem > 25 && chanceItem <= 45)
            {
                i = 1;
            }
            //Shield 15%
            else if (chanceItem > 45 && chanceItem <= 60)
            {
                i = 5;
            }
            // Add Ball 15%
            else if (chanceItem > 60 && chanceItem <= 75)
            {
                i = 2;
            }
            //Control Change 10%
            else if (chanceItem > 75 && chanceItem <= 85)
            {
                i = 3;
            }
            //Glue 10%
            else if (chanceItem > 85 && chanceItem <= 95)
            {
                i = 4;
            }
            //PowerBall 5%
            else if(chanceItem > 95 && chanceItem <= 100 )
            {
                i = 6;
            }
        
    }
    #endregion

    void OnTriggerEnter(Collider other)
    {
        Player1Control.player1Score += 50;
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision col)
    {




        int random = Random.Range(0, 4);
        //Debug.Log("Random range (0,2)" + random);
        if (col.transform.tag == "ball" && random == 1)
        {
            Rigidbody ItemInstance;
            itemChance();
            Debug.Log(i);
            if (DestroyObjectsBottomBorder.ballCount1 > 1 &&  (i == 4 || i == 6))
            {
                itemChance();
            }


                ItemInstance = Instantiate(RbitemPrefab[i], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody;
                ItemInstance.AddForce(0, -150, 0);

        }

        if (col.transform.tag == "ball2" && random == 1)
        {
            Rigidbody ItemInstance;
            itemChance();
            if (DestroyObjectsBottomBorder.ballCount2 > 1 && (i == 4 || i == 6))
            {
                itemChance();
            }

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


  
