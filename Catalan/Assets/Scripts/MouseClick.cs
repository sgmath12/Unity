using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour {

	private float timer_start,timer_end;
	// Use this for initialization
	void Start(){
		timer_start = 0f;
		timer_end = 0f;
	}

	// Update is called once per frame
	void Update () {
		Vector3 new_scale = new Vector3(0,0,0);

		if (Input.GetMouseButtonDown (0)) 
			timer_start = Time.time; // store the time at the beginning of 'click down' 
		if (Input.GetMouseButtonUp (0))
			timer_end = Time.time; //store the time at the beginning of 'click up'

		if (timer_end - timer_start > 0 && // if it is a 'click', NOT drag
		   timer_end - timer_start < 0.1){ 
			Debug.Log ("click");

			//rotation
			new_scale.x = transform.localScale.y;
			new_scale.y = transform.localScale.x;
			transform.localScale = new_scale;
		
			timer_start = 0;
			timer_end = 0;
		}


	}
}
