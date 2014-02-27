using UnityEngine;
using System.Collections;

public class JumpToFarm : MonoBehaviour {
	
	private Vector3 BeginPosition;
	private Vector3 EndPosition;
	private float touchdistance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		TapSelect ();
	}
	
	void TapSelect() {
				if (Input.touchCount == 1) {
						Touch touch = Input.GetTouch (0);
						if (touch.phase == TouchPhase.Began) {
								BeginPosition = touch.position;
						}
						if (touch.phase == TouchPhase.Ended) {
								EndPosition = touch.position;
								touchdistance = (EndPosition - BeginPosition).x * (EndPosition - BeginPosition).x + (EndPosition - BeginPosition).y * (EndPosition - BeginPosition).y;
								if (touchdistance < 100) {
										Ray ray = Camera.main.ScreenPointToRay (touch.position);
										RaycastHit hit;
										if (Physics.Raycast (ray, out hit)) {
												GameObject obj = hit.transform.gameObject; 
												if (obj.name == "Farm") {
														Application.LoadLevel ("scene2");
												}
										}		
								}
						}	
				}
		}
}