using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	private ScoreScript score;

	void Start()
	{
		score = GameObject.Find("ScoreKeeper").GetComponent<ScoreScript>();
	}

	void Update()
	{
	
	}

	void OnGUI()
	{
		GUI.Box(new Rect(0, 0, Screen.width, Screen.height/35), "Score: " + score.score.ToString());
	}
}
