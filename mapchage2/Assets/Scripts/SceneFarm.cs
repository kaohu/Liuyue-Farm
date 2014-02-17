using UnityEngine;
using System.Collections;

public class SceneFarm : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (GUI.Button (new Rect (220, 200, 150, 100), "Main Map")) {
			Application.LoadLevel("SceneMain");		
		}
	}
}
