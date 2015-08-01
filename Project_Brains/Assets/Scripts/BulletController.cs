using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour 
{
	public float despawnTime = 2f;


	private float thyme;
	void Start () 
	{
		thyme = Time.time;
	}

	void Update () 
	{
		if (Time.time - thyme > despawnTime)
			Destroy (gameObject);
	}
}
