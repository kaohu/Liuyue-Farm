using UnityEngine;
using System.Collections;

public class SceneFarm : MonoBehaviour {

	public float xSpeed;
	public float zSpeed;
	float xTrans;
	float zTrans;
	public Vector3 minCamera ;
	public Vector3 maxCamera ;
	// Use this for initialization
	void Start () {
		xSpeed = 25;
		zSpeed = 10;
		minCamera = new Vector3 (600, 0, -100);
		maxCamera = new Vector3 (1500, 0, 1000);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 1) {
			if(Input.GetTouch(0).phase==TouchPhase.Moved){
				xTrans=xSpeed*Input.GetTouch(0).deltaPosition.x*0.1F;
				zTrans=zSpeed*Input.GetTouch(0).deltaPosition.y*0.1F;
				camera.transform.Translate (-xTrans,0.0F,-zTrans);
				transform.position = new Vector3(Mathf.Clamp (transform.position.x,minCamera.x,maxCamera.x),transform.position.y,Mathf.Clamp (transform.position.z,minCamera.z,maxCamera.z));
				//	camera.transform.Translate (xTrans,0.0F,zTrans);
				
			}
		}
	}

	void OnGUI() {
		if (GUI.Button (new Rect (220, 200, 150, 100), "Main Map")) {
			Application.LoadLevel("SceneMain");		
		}

		if (GUI.Button (new Rect (800, 70, 50, 50), "+")) {
			transform.camera.fieldOfView = 10;
				}
		if (GUI.Button (new Rect (800, 10, 50, 50), "-")) {
			transform.camera.fieldOfView =20;
		}
	}
}
