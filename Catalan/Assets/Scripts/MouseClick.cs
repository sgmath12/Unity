using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour {


	public GameObject grid;

	private Draggable draggable;
	private Check check;
	private float timer_start,timer_end;
	private Vector3 originalPosition, originalScale;
	private string originaltag;
	public bool signal;

	// Use this for initialization
	void Start(){
		signal = false;
		timer_start = 0f;
		timer_end = 0f;
		originalPosition = transform.position;
		originalScale = transform.localScale;
		originaltag = gameObject.tag;
		draggable = gameObject.GetComponent<Draggable> ();
		check = grid.GetComponent<Check> ();
	}

	//recognize right mouse click.

	void Update(){
		if (Input.GetMouseButtonDown (1)) {
			timer_start = Time.time; // store the time at the beginning of 'click down' 
		}
		if (Input.GetMouseButtonUp (1)||signal) {
			timer_end = Time.time; //store the time at the beginning of 'click up'


			if ((timer_end - timer_start > 0 && // 
				timer_end - timer_start < 0.3)||signal) { 

				if (signal)
					signal = false;
				//back to original ...
				gameObject.transform.position = originalPosition;
				gameObject.transform.localScale = originalScale;
				gameObject.tag = originaltag;
				timer_start = 0;
				timer_end = 0; // must 
				check.Init_tile_Info ();
			}
		}
	}//Update



	void OnMouseOver() {
		Vector3 new_scale = new Vector3(0,0,0);
		string Sub = gameObject.tag.Substring (5);
		int T = Int32.Parse (Sub);
	
		if (Input.GetMouseButtonDown (0)) {
			timer_start = Time.time; // store the time at the beginning of 'click down' 
		}
		if (Input.GetMouseButtonUp (0)) {
			timer_end = Time.time; //store the time at the beginning of 'click up'



			if (T == 2 || T == 3 || T == 5 || T == 6 || T == 7 || T == 8 || T == 9 || T == 10) {
				if (timer_end - timer_start > 0 && // if it is a 'left click', NOT drag
				   timer_end - timer_start < 0.1) { 


					check.pop_tile_Info (T);


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
					else if (gameObject.tag == "Tile_9")
						gameObject.tag = "Tile_10";
					else if (gameObject.tag == "Tile_10")
						gameObject.tag = "Tile_9";

					if (transform.position.x < 0)
						draggable.Snap (transform.position);


					timer_start = 0;
					timer_end = 0; // must initialize timer_start and timer_end. else, block rotate quickly and continuously.
				}
			}
		}

	}//onMouseOver

}