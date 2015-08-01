using UnityEngine;
using System.Collections;

public class EnemyDestroy : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) 
	{
		Debug.Log ("Hit!");
	}
}
