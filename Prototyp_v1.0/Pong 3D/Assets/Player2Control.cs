using UnityEngine;
using System.Collections;

public class Player2Control : MonoBehaviour 
{
	public GameObject playerPaddle;
	private float speed = 6f;

	void Start()
	{
	
	}
	
	void Update() 
	{
        if (transform.position.x < -5f)
        {
            transform.position = new Vector3(-5f, transform.position.y, transform.position.z);
        }

        if (transform.position.x > 5f)
        {
            transform.position = new Vector3(5f, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.A))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
	}
}
