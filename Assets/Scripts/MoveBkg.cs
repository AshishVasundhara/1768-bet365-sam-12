using UnityEngine;
using System.Collections;

public class MoveBkg : MonoBehaviour 
{
	float cloudMoveSpeed = 0.01f; // 0.02f;
	void Start () 
	{
	
	}
	// Update is called once per frame
	void Update () 
	{
		gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - cloudMoveSpeed);	
		if (gameObject.transform.position.z <= -35) 
		{
			gameObject.transform.position=new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y,85);	
			int rno = Random.Range(1,3); 
			if(rno>=2)
			{
				//gameObject.transform.eulerAngles = new Vector3(0,180,0);
				print("===");
			}
		}
	}

}
