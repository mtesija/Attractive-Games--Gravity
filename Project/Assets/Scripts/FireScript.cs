using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {
	public GameObject Missile;
	float reloadTime = .4f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (reloadTime > 0) reloadTime -= Time.deltaTime;
		if (Input.GetMouseButtonDown(0) && reloadTime <=0) {
				GameObject missile = Instantiate(Missile, this.transform.position+ new Vector3(0f, -.5f, 0f), this.transform.rotation) as GameObject;
				missile.rigidbody.velocity = 25*(this.transform.position-this.transform.parent.transform.position);
			reloadTime = .4f;
		}
	}
}
