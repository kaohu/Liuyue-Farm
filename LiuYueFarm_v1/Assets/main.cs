using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using SimpleJSON;
using Summarize;

public class main : MonoBehaviour {
	SaveExample save = new SaveExample();
	ruins Treasure = new ruins();
	public struct FarmStatus
	{
			public bool reclaim;
			public bool harvest;
			public bool plant;
	}
	FarmStatus farm1;

	void Start () {
		string filepath = Application.dataPath  + @"/save.txt";		//set path to save the file, another path will be set for iOS
		if (File.Exists (filepath)) {								//To see whether the path exists or not
			save.load_file (filepath);	//If existing, load file

			camera.transform.position = new Vector3(-256.1298f,218.9613f,34.28522f);     //need the camera postion in the save file to replace these numbers

			System.DateTime currentTime = new System.DateTime();
			currentTime = System.DateTime.Now;
			int year = currentTime.Year;
			int month = currentTime.Month;
			int day = currentTime.Day;
			if((year != save.N["SaveTime"]["Year"].AsInt || month!=save.N["SaveTime"]["Month"].AsInt)||day!=save.N["SaveTime"]["Day"].AsInt)
			{
				Treasure.getTreasure();
			}

			farm1.reclaim = false;   // in fact, should get the value from the save file
			farm1.plant = false;
			farm1.harvest = false;

			
		} else {													//If not existing, initialize the JSONNode and save the initial data to the save file 
			
			string initialize_string = "{\"number\":0}";			//initialize JSONNode N----need update
			
			save.N = JSON.Parse (initialize_string);						//Parse, i.e. let the string to be JSON format
			
			save.save_file (filepath);											//save the file
			camera.transform.position = new Vector3(-256.1298f,218.9613f,34.28522f);

			/*starting movies*/
			/*teaching*/



		}
	}

	void Update(){
				
		if (Input.GetMouseButtonDown (0)) {  
			//摄像机到点击位置的的射线  
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);  
			RaycastHit hit;  
			if (Physics.Raycast (ray, out hit)) {  
			    
				Vector3 hitpoint = hit.point;
			switch (hit.transform.gameObject.tag)
				{
				case "farm":
					if (farm1.reclaim == false)
					{
						Debug.Log("reclaim");  
						farm1.reclaim = true;
						break;
					}
						if(farm1.plant == false)
					{
						Debug.Log ("plant");
						farm1.plant = true;
						break;
					}
					else
						if(farm1.harvest ==false)
					{
						farm1.harvest = true;     //this should after sometime
						break;
					}
					else
					{
						Debug.Log ("harvest");
						farm1.plant = false;
						farm1.harvest = false;
						break;
					}
					break;
				case "forest":
					Debug.Log("felling");
					break;
				case "ruins":
					//Debug.Log ("ruins");
					Treasure.dig(hitpoint);
					break;
					//more activities to add
				}

			}  
		}
		//		if (Input.touchCount == 1) {
		//			Touch touch = Input.GetTouch (0);
						//			if (touch.phase == TouchPhase.Began) {
						//					Ray ray = Camera.main.ScreenPointToRay (touch.position);
						//					RaycastHit hit;
						//					if (Physics.Raycast (ray, out hit)) {
						//						GameObject obj = hit.transform.gameObject; 
						//						if (obj.name == "Terrain") {
						//							man.SetDestination (hit.point);
						//						}
						//					}		
						//				}
						//			}	
				}
	
}
	
