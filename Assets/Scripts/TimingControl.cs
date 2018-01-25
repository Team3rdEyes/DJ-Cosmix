using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingControl : MonoBehaviour {

	float time_temp = 0;
	float time_diff_temp = 0;
	int beat = 0;
	int temp = 0;
	GameObject obj;

	[Header("BPM")]
	[SerializeField]
	private float bpm = 1f;

	[Header("Offset")]
	[SerializeField]
	private float offset = 1f;

	public static float getSecondsPerBeat (float bpm){
		return 60f / bpm;
	}

	public static int getBeatCount (float offset, float bpm){
		float result = (Time.time - offset) / getSecondsPerBeat (bpm);
		return (int)Mathf.Floor (result);
	}
	// Use this for initialization
	void Awake(){
		Application.targetFrameRate = 60;
	}

	void Start () {
		obj = GameObject.Find ("block");
	}
	
	// Update is called once per frame
	void Update () {
		beat = getBeatCount (offset, bpm);

		// print (beat + " : " + temp);
		if ((beat > temp) && ((beat > 0) && (temp > 0))) {
			/*
			print ((Mathf.Abs(time_diff_temp - (Time.time - time_temp))) * 1000);
			time_diff_temp = (Time.time - time_temp);
			time_temp = Time.time;
			*/
			obj.transform.localScale = new Vector3 (1, 1, 1);
		} else {
			obj.transform.localScale = new Vector3 (3, 3, 3);
			//print ("NoHi!");
		}

		temp = beat;
	}
}
