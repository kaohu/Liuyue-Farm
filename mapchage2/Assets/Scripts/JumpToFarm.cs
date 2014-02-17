using UnityEngine;
using System.Collections;

public class JumpToFarm : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		TapSelect ();
	}

	void TapSelect() {
		foreach (Touch touch in Input.touches) {
			if (touch.phase ==TouchPhase.Began) {
				Ray ray = Camera.main.ScreenPointToRay(touch.position);
				RaycastHit hit;
				if (Physics.Raycast (ray,out hit)) {
					Application.LoadLevel("SceneFarm");
				}
			}
		}
	}
	
}
