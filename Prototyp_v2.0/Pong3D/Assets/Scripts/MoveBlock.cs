﻿using UnityEngine;
using System.Collections;

public class MoveBlock : MonoBehaviour {

    public GameObject MoveBlock1;
    public GameObject MoveBlock2;
    public GameObject MoveBlock3;
    public GameObject MoveBlock4;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        translateMB1();
        translateMB2();
       /* translateMB3();
        translateMB4();*/
    }

    void translateMB1()
    {
        if (MoveBlock1.transform.position.x <= 1.2 && MoveBlock1.transform.position.y >= 1.2)
        {
            MoveBlock1.transform.Translate(Time.deltaTime, 0, 0);
            
          
        }

        if (MoveBlock1.transform.position.y >= -1.2 && MoveBlock1.transform.position.x >= 1.2)
        {
            MoveBlock1.transform.Translate(0, -Time.deltaTime, 0);
      
        }

        if (MoveBlock1.transform.position.x >= -1.2 && MoveBlock1.transform.position.y <= -1.2)
        {
            MoveBlock1.transform.Translate(-Time.deltaTime, 0, 0);
        
        }

        if (MoveBlock1.transform.position.y <= 1.2 && MoveBlock1.transform.position.x <= -1.2)
        {
            MoveBlock1.transform.Translate(0, Time.deltaTime, 0);
         
        }
    }
        void translateMB2()
    {
        if (MoveBlock2.transform.position.x <= 1.2 && MoveBlock2.transform.position.y >= 1.2)
        {
            MoveBlock2.transform.Translate(Time.deltaTime, 0, 0);
   
        }

        if (MoveBlock2.transform.position.y >= -1.2 && MoveBlock2.transform.position.x >= 1.2)
        {
            MoveBlock2.transform.Translate(0, -Time.deltaTime, 0);
        
        }

        if (MoveBlock2.transform.position.x >= -1.2 && MoveBlock2.transform.position.y <= -1.2)
        {
            MoveBlock2.transform.Translate(-Time.deltaTime, 0, 0);
          
        }

        if (MoveBlock2.transform.position.y <= 1.2 && MoveBlock2.transform.position.x <= -1.2)
        {
            MoveBlock2.transform.Translate(0, Time.deltaTime, 0);
     
        }
    }

     /*   void translateMB3()
    {
        if (MoveBlock3.transform.position.x <= 1.2 && MoveBlock3.transform.position.y >= 1.2)
        {
            MoveBlock3.transform.Translate(Time.deltaTime, 0, 0);
       
        }

        if (MoveBlock3.transform.position.y >= -1.2 && MoveBlock3.transform.position.x >= 1.2)
        {
            MoveBlock3.transform.Translate(0, -Time.deltaTime, 0);
    
        }
        if (MoveBlock3.transform.position.x >= -1.2 && MoveBlock3.transform.position.y <= -1.2)
        {
            MoveBlock3.transform.Translate(-Time.deltaTime, 0, 0);
        
        }

        if (MoveBlock3.transform.position.y <= 1.2 && MoveBlock3.transform.position.x <= -1.2)
        {
            MoveBlock3.transform.Translate(0, Time.deltaTime, 0);
       
        }

    }

        void translateMB4()
    {
        if (MoveBlock4.transform.position.x <= 1.2 && MoveBlock4.transform.position.y >= 1.2)
        {
            MoveBlock4.transform.Translate(Time.deltaTime, 0, 0);
            
        }

        if (MoveBlock4.transform.position.y >= -1.2 && MoveBlock4.transform.position.x >= 1.2)
        {
            MoveBlock4.transform.Translate(0, -Time.deltaTime, 0);
            
        }

        if (MoveBlock4.transform.position.x >= -1.2 && MoveBlock4.transform.position.y <= -1.2)
        {
            MoveBlock4.transform.Translate(-Time.deltaTime, 0, 0);
            
        }

        if (MoveBlock4.transform.position.y <= 1.2 && MoveBlock4.transform.position.x <= -1.2)
        {
            MoveBlock4.transform.Translate(0, Time.deltaTime, 0);
            
        }
    }*/
}
