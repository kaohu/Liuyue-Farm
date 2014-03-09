using UnityEngine;
using System.Collections;
using System;

public class task : MonoBehaviour {

	public static float taskTime = 4000;	//Time for the task, unit: second
	
	public DateTime targetTime = System.DateTime.Now.AddSeconds(taskTime);
	public TimeSpan timer = TimeSpan.Zero;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (taskTime > 0) {
			if (DateTime.Compare(targetTime, System.DateTime.Now) > 0) {
				timer = targetTime.Subtract(System.DateTime.Now);
			} else{
				timer = TimeSpan.Zero;
			}
		} else {
		}
	
	}

	void OnGUI(){
		string timeText = string.Format("{0:D2}:{1:D2}:{2:D2}", timer.Hours, timer.Minutes, timer.Seconds);
		GUI.Label(new Rect (10, 10, 150, 150), timeText);
	}
}
