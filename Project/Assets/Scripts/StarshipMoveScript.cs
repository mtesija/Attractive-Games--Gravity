using UnityEngine;
using System.Collections;

public class StarshipMoveScript : MonoBehaviour {
	Vector3 velocity;
	Vector3 acceleration;
	float forward;
	float right;
	
	
	// Use this for initialization
	void Start () {
		velocity = Vector3.zero;
		acceleration = Vector3.zero;
		forward = 0;
		right = 0;
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();
		forward = Input.GetAxis("Horizontal");
		right = Input.GetAxis("Vertical");
		controller.Move(new Vector3(forward, 0, right));

		float x = this.transform.position.x;
		float z = this.transform.position.z;

		if(x <= -125)
			x = -125;
		else if(x >= 125)
			x = 125;

		if(z <= -125)
			z = -125;
		else if(z >= 125)
			z = 125;

		this.transform.position = new Vector3 (x, 1, z);
	}
}
