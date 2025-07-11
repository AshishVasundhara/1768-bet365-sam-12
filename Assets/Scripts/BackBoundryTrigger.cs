using UnityEngine;
using System.Collections;

public class BackBoundryTrigger : MonoBehaviour
{

	void OnTriggerEnter(Collider other) 
	{
		print ("Other : " + other.gameObject.name);
	}

	void OnTriggerExit(Collider other) 
	{
		if (other.gameObject.name == "bg1") 
		{
			Vector3 othPos = other.gameObject.transform.parent.Find("bg2").transform.position;
			other.transform.position = new Vector3 (other.transform.position.x, other.transform.position.y, othPos.z+80);
		}
		if (other.gameObject.name == "bg2") 
		{
			Vector3 othPos = other.gameObject.transform.parent.Find("bg3").transform.position;
			other.transform.position = new Vector3 (other.transform.position.x, other.transform.position.y, othPos.z+80);
		}
		if (other.gameObject.name == "bg3") 
		{
			Vector3 othPos = other.gameObject.transform.parent.Find("bg1").transform.position;
			other.transform.position = new Vector3 (other.transform.position.x, other.transform.position.y, othPos.z+80);
		}
	}
}
