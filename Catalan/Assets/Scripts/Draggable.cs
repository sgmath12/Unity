using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // IBegDragHandler


public class Draggable : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler {

	public GameObject grid;



	private Vector3 mouseBeginPosition;
	private Vector3 mouseCurPosition;
	private Vector3 objectBeginPosition;
	private Vector3 originalScale;
	private Vector3 originalPosition;
	private string originaltag;
	private float timer_start,timer_end;
	private bool[,] tile_Info;
	private int a,b;

	private GridScript gridScript;

	//setting
	void Awake(){
		originalPosition = transform.position;
		originalScale = transform.localScale;
		originaltag = gameObject.tag;
		gridScript = grid.GetComponent<GridScript> ();
		tile_Info = new bool[20, 20];
		timer_start = 0f;
		timer_end = 0f;

	}

	//reconize 'right' mouse click
	void Update(){

		if (Input.GetMouseButtonDown (1)) {
			timer_start = Time.time; // store the time at the beginning of 'click down' 
		}
		if (Input.GetMouseButtonUp (1))
			timer_end = Time.time; //store the time at the beginning of 'click up'


		if (timer_end - timer_start > 0 && // if it is a 'left click', NOT drag
			timer_end - timer_start < 0.3) { 

			//back to original ...
			gameObject.transform.position = originalPosition;
			gameObject.transform.localScale = originalScale;
			gameObject.tag = originaltag;
			timer_start = 0;
			timer_end = 0; // must 
//			gridScript.Check (tile_Info, 10);

		}
	}//Update
		
	public void OnBeginDrag(PointerEventData eventData)
	{
		mouseBeginPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		objectBeginPosition = transform.position;
	}

	public void OnDrag(PointerEventData eventData)
	{
		mouseCurPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = mouseCurPosition+(objectBeginPosition - mouseBeginPosition);
	}

	public void OnEndDrag(PointerEventData eventData){
		float radius = 1f;
		bool snap = false;
		int N = gridScript.N;


	
		if (transform.position.x >= 0) {
			
			gameObject.transform.position = originalPosition;
		
		} else {
			string Sub = gameObject.tag.Substring (5);
			int T = Int32.Parse (Sub); // ex) tag = "Tile_3" then T = 3

			int k = 0;

			switch (T) {
			case 0:
			case 1:
				k = 0;
				break;
			case 2:
			case 3:
				k = 1;
				break;
			case 4:
			case 5:
			case 6:
				k = 2;
				break;
			case 7:
			case 8:
			case 9:
			case 10:
				k = 3;
				break;
			}//switch


			for (int i = 0; i < N - k; i++)
				for (int j = 0; j < N - i - k; j++) {
					if (Vector3.Distance (transform.position, gridScript.GetPosition (i, j, T)) <= radius) {
							
						transform.position = gridScript.GetPosition (i, j, T);
						a = i;
						b = j;
						snap = true;
					}
					if (snap) {
						if (i != a || j != b)
							tile_Info [T, i] = false;
						else
							tile_Info [T, i] = true;
					}

				}


			
			//		gridScript.Check (tile_Info, tag);

			if (!snap)
				transform.position = objectBeginPosition;
		}//else

	
	}//OnEnd drag

}



