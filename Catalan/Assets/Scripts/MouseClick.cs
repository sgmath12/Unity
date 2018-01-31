using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour {


	public GameObject grid;
//	private GridScript gridscript;
	private float timer_start,timer_end;

	// Use this for initialization
	void Start(){
		timer_start = 0f;
		timer_end = 0f;
	//	gridscript = grid.GetComponent<GridScript> ();
	}


	void OnMouseOver() {
		Vector3 new_scale = new Vector3(0,0,0);
	
		if (Input.GetMouseButtonDown (0)) {
			timer_start = Time.time; // store the time at the beginning of 'click down' 
		}
		if (Input.GetMouseButtonUp (0))
			timer_end = Time.time; //store the time at the beginning of 'click up'

		if (timer_end - timer_start > 0 && // if it is a 'left click', NOT drag
		   timer_end - timer_start < 0.1){ 


			//rotation
			new_scale.x = transform.localScale.y;
			new_scale.y = transform.localScale.x;
			transform.localScale = new_scale;

			if (gameObject.tag == "Tile_2")
				gameObject.tag = "Tile_3";
			else if (gameObject.tag == "Tile_3")
				gameObject.tag = "Tile_2";
			else if (gameObject.tag == "Tile_5") {
				gameObject.tag = "Tile_6";
			} else if (gameObject.tag == "Tile_6")
				gameObject.tag = "Tile_5";
			else if (gameObject.tag == "Tile_7")
				gameObject.tag = "Tile_8";
			else if (gameObject.tag == "Tile_8")
				gameObject.tag = "Tile_7";
			else if (gameObject.tag =="Tile_9")
				gameObject.tag ="Tile_10";
			else if (gameObject.tag =="Tile_10")
				gameObject.tag ="Tile_9";


			timer_start = 0;
			timer_end = 0; // must initialize timer_start and timer_end. else, block rotate quickly and continuously.
		}



	}//onMouseOver

}