using UnityEngine;
using System.Collections;

public class EnemyLRPos : MonoBehaviour {


	float minusTime;
	float plusTime;
	bool isPlus;
	public int minRand,maxRand;
	void Start()
	{
		isPlus = true;
		StartCoroutine (Dominus());
	}
	IEnumerator Dominus()
	{
		isPlus = false;
		minusTime = Random.Range (minRand,maxRand );
		yield return new WaitForSeconds(minusTime);
		StartCoroutine (Doplus ());
	}
	IEnumerator Doplus()
	{
		isPlus = true;
		plusTime = Random.Range (minRand,maxRand);
		yield return new WaitForSeconds(plusTime);
		StartCoroutine (Dominus());
	}
	void LateUpdate () 
	{
		Vector3 GoPos = gameObject.transform.position;

//		print (GoPos.x * Time.deltaTime * -100 + ":::");

		if(!isPlus)
			GoPos = new Vector3 (gameObject.transform.position.x + Time.deltaTime * -0.6F, gameObject.transform.position.y, gameObject.transform.position.z);
		else
			GoPos = new Vector3 (gameObject.transform.position.x + Time.deltaTime * 0.6F, gameObject.transform.position.y, gameObject.transform.position.z);

		gameObject.transform.position = GoPos;
	}
}
