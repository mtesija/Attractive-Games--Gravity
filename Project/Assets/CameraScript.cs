using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	private ScoreScript score;
	private LauncherScript player;

	void Start()
	{
		score = GameObject.Find("ScoreKeeper").GetComponent<ScoreScript>();
		player = GameObject.Find("Player").GetComponent<LauncherScript>();
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape)) {
			if (Application.loadedLevel != 0){
				Application.LoadLevel("TitleScreen");
			}
		}
	}

	void OnGUI()
	{
		if(player.alive)
		{
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height/35), "Score: " + score.score.ToString());
		}
		else
		{
			GUI.Box(new Rect(0, Screen.height/2, Screen.width, 50), "You Died!");
		}
	}
}
