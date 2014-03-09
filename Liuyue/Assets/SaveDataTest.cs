using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;
using System.IO;
using System;

public class SaveDataTest : MonoBehaviour {

	long number;

	// Use this for initialization
	void Start () {
		number = loadNumber ();
	
	}
	
	// Update is called once per frame
	void Update () {
		number = loadNumber ();
	}

	void OnGUI(){
		String text = "Number: ";
		GUI.Label (new Rect (100, 100, 50, 50), text);

		if ( GUI.Button (new Rect( 100, 150, 25, 25 ), "0") ){
			saveNumber(0);
		}

		if (GUI.Button (new Rect (130, 150, 25, 25), "1")) {
			saveNumber (1);
		}

		if (GUI.Button (new Rect (160, 150, 25, 25), "2")) {
			saveNumber (2);
		}

		if (GUI.Button (new Rect (190, 150, 25, 25), "3")) {
			saveNumber (3);
		}

		if (GUI.Button (new Rect (220, 150, 25, 25), "4")) {
			saveNumber (4);
		}

		if (GUI.Button (new Rect (100, 180, 25, 25), "5")) {
			saveNumber (5);
		}

		if (GUI.Button (new Rect (130, 180, 25, 25), "6")) {
			saveNumber (6);
		}

		if (GUI.Button (new Rect (160, 180, 25, 25), "7")) {
			saveNumber (7);
		}

		if (GUI.Button (new Rect (190, 180, 25, 25), "8")) {
			saveNumber (8);
		}

		if (GUI.Button (new Rect (220, 180, 25, 25), "9")) {
			saveNumber (9);
		}

		GUI.Label (new Rect (150, 100, 25, 25), number.ToString ());


	}

	public void saveNumber(int number_save){

		var json_number = " { \"number\": " + number_save.ToString () + " }";

		string filepath = Application.persistentDataPath + @"/Text.txt";

		//Debug.Log (filepath);

		FileInfo t = new FileInfo (filepath);

		StreamWriter sw = t.CreateText ();

		sw.WriteLine (json_number);

		sw.Close ();

		sw.Dispose ();

	}

	public long loadNumber(){

		string filepath = Application.persistentDataPath + @"/Text.txt";

		FileInfo t = new FileInfo (filepath);

		StreamReader sr = t.OpenText ();
		
		string load_string = sr.ReadToEnd ();

		var json_number = Json.Deserialize (load_string) as Dictionary<string, object>;

		sr.Close ();

		long n = ((long)json_number ["number"]);

		return n;

	}
}
