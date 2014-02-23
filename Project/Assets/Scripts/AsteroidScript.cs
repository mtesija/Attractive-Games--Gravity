using UnityEngine;
using System.Collections;

public class AsteroidScript : MonoBehaviour 
{
	private float gravity = 10;

	private GameObject cam;
	private GameObject player;
	public GameObject AsteroidCollision;
	private ScoreScript score;

	void Start()
	{
		cam = GameObject.Find("Main Camera");
		player = GameObject.Find("Player");
		score = GameObject.Find ("ScoreKeeper").GetComponent<ScoreScript>();
	}

	void Update()
	{
		GravityToPlayer();
		GravityToAsteroids();

		Vector3 position = cam.transform.position;
		position.y = 0;

		if(Vector3.Distance(position, this.transform.position) > 600)
		{
			Destroy(this.gameObject);
		}
	}

	void GravityToPlayer()
	{
		Vector3 direction = player.transform.position - this.transform.position;
		direction.Normalize();

		float distance = Vector3.Distance(player.transform.position, this.transform.position);

		direction *= gravity * player.rigidbody.mass / (distance * distance);

		this.rigidbody.AddForce(direction);
	}

	void GravityToAsteroids()
	{
		GameObject[] Objects = GameObject.FindGameObjectsWithTag("Asteroid") as GameObject[];
		foreach(GameObject obj in Objects)
		{
			float distance = Vector3.Distance(obj.transform.position, this.transform.position);

			if(distance == 0)
			{
				continue;
			}

			Vector3 direction = obj.transform.position - this.transform.position;
			direction.Normalize();

			direction *= gravity * 50 * obj.rigidbody.mass / (distance * distance);
			
			this.rigidbody.AddForce(direction);
		}
	}

	void OnCollisionEnter(Collision coll)
	{
		if(coll.gameObject.name == "Player")
		{
			Destroy(this.gameObject);
		}
		else if(coll.gameObject.name == "Asteroid(Clone)")
		{
			if(this.transform.localScale.x >= coll.gameObject.transform.localScale.x)
			{
				Vector3 thisVelocity = this.rigidbody.velocity * this.rigidbody.mass;
				Vector3 collVelocity = coll.rigidbody.velocity * coll.rigidbody.mass;
				float newMass = this.rigidbody.mass + coll.rigidbody.mass;
				Vector3 newVelocity = (thisVelocity + collVelocity) / (newMass);

				Destroy(coll.gameObject);

				this.rigidbody.mass = newMass;
				this.rigidbody.velocity = newVelocity;
				this.transform.localScale = Vector3.one * Mathf.Pow(newMass, 1f / 3f);

				GameObject particle = Instantiate(AsteroidCollision, coll.transform.position, Quaternion.identity) as GameObject;
				particle.rigidbody.velocity = this.rigidbody.velocity;
				Destroy(particle, 5);
			}
		}
		else if(coll.gameObject.name == "Missile(Clone)")
		{
			GameObject particle = Instantiate(AsteroidCollision, coll.transform.position, Quaternion.identity) as GameObject;
			particle.rigidbody.velocity = this.rigidbody.velocity;
			Destroy(particle, 5);

			if(this.transform.localScale.x <= 6)
			{
				score.score += 100;
				Destroy(this.gameObject);
			}
			else
			{
				score.score += 20;
				float newSize = this.transform.localScale.x - 2;
				this.rigidbody.mass = Mathf.Pow(newSize, 3f);
				this.transform.localScale = Vector3.one * newSize;
			}
		}
	}
}
