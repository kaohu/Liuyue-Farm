using UnityEngine;
using System.Collections;


public class mainscene : MonoBehaviour {
	
	// Use this for initialization
	public float xSpeed;
	public float ySpeed;
	float xTrans;
	float yTrans;
	public Vector2 minCamera ;
	public Vector2 maxCamera ;
	//	public float yMinLimit = -20.0F;
	//	public float yMaxLimit = 80.0F;
	void Start () {
		xSpeed = 1.0f;
		ySpeed = 0.8f;
		minCamera = new Vector2 (-10, -8);
		maxCamera = new Vector2 (10, 8);	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 1) {
			if(Input.GetTouch(0).phase==TouchPhase.Moved){
				xTrans=xSpeed*Input.GetTouch(0).deltaPosition.x*0.01F;
				yTrans=ySpeed*Input.GetTouch(0).deltaPosition.y*0.01F;
				camera.transform.Translate (-xTrans,-yTrans,0.0F);
				transform.position = new Vector3(Mathf.Clamp (transform.position.x,minCamera.x,maxCamera.x),Mathf.Clamp (transform.position.y,minCamera.y,maxCamera.y),-1.0F);
				//	camera.transform.Translate (xTrans,0.0F,zTrans);
				
			}
		}
	}
	
	
	void OnGUI() {
		if (GUI.Button (new Rect (800, 70, 50, 50), "+")) {
			transform.camera.orthographicSize *= 0.5f;
		}
		if (GUI.Button (new Rect (800, 10, 50, 50), "-")) {
			transform.camera.orthographicSize *= 2.0f;
		}
	}
	//	void LateUpdate(){
	//		transform.position = new Vector3(Mathf.Clamp (transform.position.x+xTrans,minCamera.x,maxCamera.x),transform.position.y,Mathf.Clamp (transform.position.z+zTrans,minCamera.z,maxCamera.z));
	//		}
	
	//void OnGUI() {
	//	if (GUI.Button (new Rect (220, 200, 150, 100), "Right")) {
	//		camera.transform.Translate(-200,0,0);
	//	}
	//}
	
}
