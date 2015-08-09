using UnityEngine;
using System.Collections;

public class EnemyDestroy : MonoBehaviour {

	public int enemyHealth;
	public int playerHealth;
	public float attackTime;
	public float lastAttack;
	public int enemyDamage;
	public int playerDamage;
	public bool loadEnemyAttack = false;

	public int speed;

	Rigidbody2D rbEnemy;

	GameObject player;

	void Start  ()
	{
		rbEnemy = GetComponent<Rigidbody2D>();
		player = GameObject.FindWithTag ("Player");
	}

	void Update ()
	{
		if (enemyHealth <= 0)
		{
			Destroy (gameObject);
		}
		if (playerHealth <= 0)
		{
			Debug.Log ("You are dead!");
		}
		//float angle = Mathf.Atan2(player.gameObject.transform.position.y - transform.position.y, player.gameObject.transform.position.x - transform.position.x) * 180 / Mathf.PI;

		Vector2 velocity = new Vector2((transform.position.x - player.gameObject.transform.position.x) * speed, (transform.position.y - player.gameObject.transform.position.y) * speed);

		rbEnemy.velocity = -velocity;
	}

	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.tag == "Bullet")
		{
			enemyHealth = enemyHealth - playerDamage;
			Destroy (other.gameObject);
		}

	}
	void OnTriggerStay2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			if (Time.time - lastAttack > attackTime)
			{
				Debug.Log ("Hit!");
				loadEnemyAttack = true;
			}
			if (loadEnemyAttack == true)
			{
				playerHealth = playerHealth - enemyDamage;
				loadEnemyAttack = false;
				lastAttack = Time.time;
			}
		}
	}
}
