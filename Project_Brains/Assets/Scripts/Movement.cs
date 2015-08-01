using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
	Rigidbody2D rigidBody;

	public float speed = 5f;
	public float maxSpeed = 5f;
	public float bulletSpeed = 10f;

	public GameObject bullet;

	public Camera camera;


	void Start () 
	{
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	void Update()
	{
		if (Input.GetButtonDown ("Fire1")) 
		{

			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


			float angle = Mathf.Atan2(mousePosition.y-transform.position.y, mousePosition.x - transform.position.x)*180/Mathf.PI;

			Rigidbody2D hue;
			hue = (Instantiate (bullet, transform.position, Quaternion.Euler (0, 0, angle)) as GameObject).GetComponent<Rigidbody2D>();

			Vector2 vel = mousePosition - new Vector2(transform.position.x, transform.position.y);

			//Debug.Log ("Angle: "+angle);

			vel = vel.normalized*bulletSpeed;

			hue.velocity = vel;
		
		}

	}

	void FixedUpdate () 
	{
		rigidBody.velocity += new Vector2 (Input.GetAxis ("Horizontal") * speed, Input.GetAxis ("Vertical") * speed);

		if (rigidBody.velocity.magnitude > maxSpeed)
			rigidBody.velocity = (rigidBody.velocity / rigidBody.velocity.magnitude) * maxSpeed;
	}
}
