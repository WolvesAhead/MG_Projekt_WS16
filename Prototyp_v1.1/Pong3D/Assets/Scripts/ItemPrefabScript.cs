﻿using UnityEngine;
using System.Collections;

public class ItemPrefabScript : MonoBehaviour {
    private Collider ColliderItem;
	// Use this for initialization
	void Start () {
        
        
    }

    // Update is called once per frame
    void Update() {
    }
 
    void OnCollisionEnter(Collision col)
    {
   
                 Destroy(gameObject);
               
     }

   
}
