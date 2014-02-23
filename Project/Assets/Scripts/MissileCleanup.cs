using UnityEngine;
using System.Collections;

public class MissileCleanup : MonoBehaviour {
	private GameObject cam;
	private GameObject player;
	private int gravity = 10;
	// Use this for initialization
	void Start () {
		cam = GameObject.Find("Main Camera");
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = cam.transform.position;
		position.y = 0;

		if(Vector3.Distance(position, this.transform.position) > 600)
		{
			Destroy(this.gameObject);
		}
		GravityToPlayer();
		GravityToAsteroids();
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
			
			direction *= gravity * 200 * obj.rigidbody.mass / (distance * distance);
			
			this.rigidbody.AddForce(direction);
		}
	}
	void OnCollisionEnter(Collision coll)
	{
		if(coll.gameObject.name == "Asteroid(Clone)")
		{
			Destroy(this.gameObject);
		}
	}
}
