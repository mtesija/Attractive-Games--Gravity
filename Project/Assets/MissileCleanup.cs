using UnityEngine;
using System.Collections;

public class MissileCleanup : MonoBehaviour {
	private GameObject cam;
	// Use this for initialization
	void Start () {
		cam = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = cam.transform.position;
		position.y = 0;

		if(Vector3.Distance(position, this.transform.position) > 200)
		{
			Destroy(this.gameObject);
		}
	}
}
