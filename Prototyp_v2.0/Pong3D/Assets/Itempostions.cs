using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform position1;
    public Transform position2;
    public Transform position3;
    public Transform position4;
    private Transform initalpostion;
    // Use this for initialization
    void Start()
    {
        initalpostion = gameObject.transform;

    }

    // Update is called once per frame
    void Update()
    {

        if (Player1Control.shieldstatus)
        {
            gameObject.transform.position = position1.position;
            gameObject.SetActive(true);

        }
        else
        {
            gameObject.SetActive(false);
            gameObject.transform.position = initalpostion.position;
        }



    }
}
