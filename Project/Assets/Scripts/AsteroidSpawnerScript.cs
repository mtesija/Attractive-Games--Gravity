using UnityEngine;
using System.Collections;

public class AsteroidSpawnerScript : MonoBehaviour {

	public GameObject Asteroid;

	public float lowAngle = 0;
	public float highAngle = Mathf.PI;

	public float minVelocity = 0;
	public float maxVelocity = 8;

	public float minSize = 1f;
	public float maxSize = 3f;

	public float minTime = 1.7f;
	public float maxTime = 5.2f;

	private float spawnTimer = 0;

	void Start()
	{
		spawnTimer = Random.Range(minTime, maxTime);
	}

	void Update() 
	{
		spawnTimer -= Time.deltaTime;

		if(spawnTimer <= 0)
		{
			spawnTimer = Random.Range(minTime, maxTime);
			spawnAsteroid();
		}
	}

	void spawnAsteroid()
	{
		GameObject asteroid = Instantiate(Asteroid, this.transform.position, Quaternion.identity) as GameObject;

		float angle = Random.Range(lowAngle, highAngle);
		float velocity = Random.Range(minVelocity, maxVelocity);
		float size = Random.Range(minSize, maxSize);

		asteroid.rigidbody.velocity = new Vector3(Mathf.Cos(angle), 0 , Mathf.Sin(angle)) * velocity;
		asteroid.transform.localScale = Vector3.one * size;
		asteroid.rigidbody.mass = size * 20;
	}
}
