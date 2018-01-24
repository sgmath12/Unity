using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour {


	public GameObject grid;
	private GridScript gridscript;
	private float timer_start,timer_end;
	// Use this for initialization
	void Start(){
		timer_start = 0f;
		timer_end = 0f;
		gridscript = grid.GetComponent<GridScript> ();
	}


	void OnMouseOver() {
		Vector3 new_scale = new Vector3(0,0,0);
		string temp;
		if (Input.GetMouseButtonDown (0)) {
			timer_start = Time.time; // store the time at the beginning of 'click down' 
		}
		if (Input.GetMouseButtonUp (0))
			timer_end = Time.time; //store the time at the beginning of 'click up'

		if (timer_end - timer_start > 0 && // if it is a 'click', NOT drag
		   timer_end - timer_start < 0.1){ 
			Debug.Log ("click");

			//rotation
			new_scale.x = transform.localScale.y;
			new_scale.y = transform.localScale.x;
			transform.localScale = new_scale;

			if (gameObject.tag == "Tile_1")
				gameObject.tag = "Tile_2";
			else if (gameObject.tag == "Tile_2")
				gameObject.tag = "Tile_1";


			timer_start = 0;
			timer_end = 0; // must initialize timer_start and timer_end. else, block rotate quickly and continuously.
		}

	}

}