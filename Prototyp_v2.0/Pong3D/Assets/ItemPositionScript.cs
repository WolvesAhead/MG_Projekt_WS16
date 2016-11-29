using UnityEngine;
using System.Collections;

public class ItemPositionScript : MonoBehaviour {
    public Transform position1;
    public Transform position2;
    public Transform position3;
    public Transform position4;

    // Use this for initialization
    void Start () {
      
       


    }
	
	// Update is called once per frame
	void Update () {
        
        if (Player1Control.shieldstatus)
        {
            //Debug.Log("position X :" + initalpostion.position.x +"Y :" +initalpostion.position.y + "Z : "+ initalpostion.position.z);

            gameObject.transform.position = position1.position;
            //gameObject.SetActive(true);
            
        }
        else if(Player1Control.shieldstatus == false)
        {
            //gameObject.SetActive(false);
            gameObject.transform.position = new Vector3(-1.7f, -7f, -0.7f);
        }


	
	}
}
