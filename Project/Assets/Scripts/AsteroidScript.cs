using UnityEngine;
using System.Collections;

public class AsteroidScript : MonoBehaviour 
{
	private float gravity = 10;

	private GameObject cam;
	private GameObject player;

	void Start()
	{
		cam = GameObject.Find("Main Camera");
		player = GameObject.Find("Player");
	}

	void Update()
	{
		Gravity();

		Vector3 position = cam.transform.position;
		position.y = 0;

		if(Vector3.Distance(position, this.transform.position) > 200)
		{
			Destroy(this.gameObject);
		}
	}

	void Gravity()
	{
		Vector3 direction = player.transform.position - this.transform.position;
		direction.Normalize();

		float distance = Vector3.Distance(player.transform.position, this.transform.position);

		direction *= gravity * player.rigidbody.mass / (distance * distance);

		this.rigidbody.AddForce(direction);
	}

	void OnCollisionEnter(Collision coll)
	{
		if(coll.gameObject.name == "Player")
		{
			Destroy(this.gameObject);
		}
		else if(coll.gameObject.name == "Asteroid(Clone)")
		{
			if(this.transform.localScale.x > coll.gameObject.transform.localScale.x)
			{
				Vector3 thisVelocity = this.rigidbody.velocity * this.rigidbody.mass;
				Vector3 collVelocity = coll.rigidbody.velocity * coll.rigidbody.mass;
				float newMass = this.rigidbody.mass + coll.rigidbody.mass;
				Vector3 newVelocity = (thisVelocity + collVelocity) / (newMass);

				Destroy(coll.gameObject);

				this.rigidbody.mass = newMass;
				this.rigidbody.velocity = newVelocity;
				this.transform.localScale = Vector3.one * Mathf.Pow(newMass, 1f / 3f);
			}
		}
		else if(coll.gameObject.name == "Missile(Clone)")
		{
			Destroy(coll.gameObject);
		}
	}
}
