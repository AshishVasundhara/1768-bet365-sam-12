using UnityEngine;
using System.Collections;

public class GenerateBgs : MonoBehaviour {


	Transform bg1Trans;
	Transform bg2Trans;
	Transform bg3Trans;
	float temp1,temp2,temp3;
	public float speed;
	void Start () 
	{

		bg1Trans = gameObject.transform.Find ("bg1").transform;
		bg2Trans = gameObject.transform.Find ("bg2").transform;
		bg3Trans = gameObject.transform.Find ("bg3").transform;
	//	bg1Trans = gameObject.transform.FindChild ("t1").transform;
	//	bg2Trans = gameObject.transform.FindChild ("t2").transform;
		temp1 = bg1Trans.position.z;
		temp2 = bg2Trans.position.z;
		temp3 = bg3Trans.position.z;
	}
	
	void Update () 
	{
		temp1 = bg1Trans.position.z - Time.deltaTime * speed;
		bg1Trans.position = new Vector3 (bg1Trans.position.x, bg1Trans.position.y, temp1);
		temp2 = bg2Trans.position.z - Time.deltaTime * speed;
		bg2Trans.position = new Vector3 (bg2Trans.position.x, bg2Trans.position.y, temp2);
		temp3 = bg3Trans.position.z - Time.deltaTime * speed;
		bg3Trans.position = new Vector3 (bg3Trans.position.x, bg3Trans.position.y, temp3);
//		print (new Vector3 (bg1Trans.position.x * Time.deltaTime * 10,bg1Trans.position.y,bg1Trans.position.z)+" : :" + bg1Trans.position);
	}
}
