using UnityEngine;
using System.Collections;


public class SceneMain : MonoBehaviour {
	
	// Use this for initialization
	public float xSpeed=0.1F;
	public float zSpeed=0.1F;
	float xTrans;
	float zTrans;
	public Vector3 minCamera = new Vector3 (600, 0, 200);
	public Vector3 maxCamera = new Vector3 (1000,0,1000);
//	public float yMinLimit = -20.0F;
//	public float yMaxLimit = 80.0F;
	private float distance = 0.0f;   //the distance between camera and center point of view
	void Start () {
		//Transform angles=transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 1) {
		    if(Input.GetTouch(0).phase==TouchPhase.Moved){
				xTrans=xSpeed*Input.GetTouch(0).deltaPosition.x*0.1F;
				zTrans=zSpeed*Input.GetTouch(0).deltaPosition.y*0.1F;
				camera.transform.Translate (xTrans,0.0F,zTrans);
				transform.position = new Vector3(Mathf.Clamp (transform.position.x,minCamera.x,maxCamera.x),transform.position.y,Mathf.Clamp (transform.position.z,minCamera.z,maxCamera.z));
			//	camera.transform.Translate (xTrans,0.0F,zTrans);
				
			}
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
