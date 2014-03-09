using UnityEngine;
using System.Collections;


public class mainscene : MonoBehaviour {
	
	// Use this for initialization
	public float xSpeed;
	public float ySpeed;
	float xTrans;
	float yTrans;
	public float mapsize = 4;
	public Vector2 minCamera ;
	public Vector2 maxCamera ;
	private Vector2 oldPosition1;
	private Vector2 oldPosition2;
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
				transform.position = new Vector3(Mathf.Clamp (transform.position.x,minCamera.x,maxCamera.x),Mathf.Clamp (transform.position.y,minCamera.y,maxCamera.y),-10.0F);
				//	camera.transform.Translate (xTrans,0.0F,zTrans);
				
			}
		}
		if (Input.touchCount > 1) {
			if(Input.GetTouch (0).phase == TouchPhase.Moved && Input.GetTouch (1).phase == TouchPhase.Moved){
				Vector2 temposition1=Input.GetTouch(0).position;
				Vector2 temposition2=Input.GetTouch(1).position;
				if(isEnlarge(oldPosition1,oldPosition2,temposition1,temposition2)){
					if(mapsize>2){
						mapsize -=0.5f;
					}
				}
				else{
					if(mapsize<6){
						mapsize +=0.5f;
					}
				}
				camera.orthographicSize = mapsize;
				oldPosition1 = temposition1;
				oldPosition2 = temposition2;
			}
				}
	}

	bool isEnlarge(Vector2 old1,Vector2 old2,Vector2 new1,Vector2 new2){
		float leng1 = Mathf.Sqrt ((old1.x-old2.x)*(old1.x-old2.x)+(old1.y-old2.y)*(old1.y-old2.y));
		float leng2 = Mathf.Sqrt ((new1.x-new2.x)*(new1.x-new2.x)+(new1.y-new2.y)*(new1.y-new2.y));

		if (leng1 < leng2) {
						return true;
				} else {
			return false;
				}


	}
	
//	void OnGUI() {
//		if (GUI.Button (new Rect (800, 130, 100, 100), "+")) {
//			transform.camera.orthographicSize *= 0.5f;
//		}
//		if (GUI.Button (new Rect (800, 10, 100, 100), "-")) {
//			transform.camera.orthographicSize *= 2.0f;
//		}
//	}
	//	void LateUpdate(){
	//		transform.position = new Vector3(Mathf.Clamp (transform.position.x+xTrans,minCamera.x,maxCamera.x),transform.position.y,Mathf.Clamp (transform.position.z+zTrans,minCamera.z,maxCamera.z));
	//		}
	
	//void OnGUI() {
	//	if (GUI.Button (new Rect (220, 200, 150, 100), "Right")) {
	//		camera.transform.Translate(-200,0,0);
	//	}
	//}
	
}
