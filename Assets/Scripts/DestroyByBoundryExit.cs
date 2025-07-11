using UnityEngine;
using System.Collections;

public class DestroyByBoundryExit : MonoBehaviour {

	//Script is attached to boundry object
	public void OnTriggerExit (Collider other)
	{
		Destroy (other.gameObject);
	}
}
