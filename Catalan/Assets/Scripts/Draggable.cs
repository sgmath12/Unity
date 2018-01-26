using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // IBegDragHandler


public class Draggable : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler {

	public GameObject grid;
	public GameObject final;


	private Vector3 mouseBeginPosition;
	private Vector3 mouseCurPosition;
	private Vector3 objectBeginPosition;
	private Vector3 originalScale;
	private Vector3 originalPosition;
	private string originaltag;
	private float timer_start,timer_end;
	private bool[,] tile_Info;
	private int k,a,b;

	private GridScript gridScript;

	void Awake(){
		k = 0;
		originalPosition = transform.position;
		originalScale = transform.localScale;
		originaltag = gameObject.tag;
		gridScript = grid.GetComponent<GridScript> ();
		tile_Info = new bool[7, 3];
		timer_start = 0f;
		timer_end = 0f;

	}

	void Update(){

		if (Input.GetMouseButtonDown (1)) {
			timer_start = Time.time; // store the time at the beginning of 'click down' 
		}
		if (Input.GetMouseButtonUp (1))
			timer_end = Time.time; //store the time at the beginning of 'click up'


		if (timer_end - timer_start > 0 && // if it is a 'left click', NOT drag
			timer_end - timer_start < 0.1) { 




			gameObject.transform.position = originalPosition;
			gameObject.transform.localScale = originalScale;
			gameObject.tag = originaltag;
			timer_start = 0;
			timer_end = 0; // must 
			gridScript.Check (tile_Info, 10);

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
		float radius = 1;
		bool snap = false;
		int N = gridScript.N;


	
		if (mouseCurPosition.x>=0) {
			transform.position = originalPosition;
			int tag = gameObject.tag [5] - '0';
			for (int i = 0; i < 3; i++)
				tile_Info [tag, i] = false;
			gridScript.Check (tile_Info, tag);

		}
		else {
			int tag = gameObject.tag [5]-'0';
	
			// 1*1 [ ]
			if (gameObject.tag == "Tile_0") {
				for (int i = 0; i < N; i++)
					for (int j = 0; j < N - i; j++) {
						if (Vector3.Distance (transform.position, gridScript.GetPosition (i, j, "Tile_0")) <= radius) {
							transform.position = gridScript.GetPosition (i, j, "Tile_0");
							a = i;
							b = j;
							snap = true;
							}
						if(snap){
							if (i != a || j != b)
								tile_Info [tag, i] = false;
							else
								tile_Info [tag, i] = true;
						}

						}

				}

			// 1*1 []
			else if (gameObject.tag == "Tile_1") {
				for (int i = 0; i < N; i++)
					for (int j = 0; j < N - i; j++) {
						if (Vector3.Distance (transform.position, gridScript.GetPosition (i, j, "Tile_1")) <= radius) {
							transform.position = gridScript.GetPosition (i, j, "Tile_1");
							a = i;
							b = j;
							snap = true;
						}
						if(snap){
							if (i != a || j != b)
								tile_Info [tag, i] = false;
							else
								tile_Info [tag, i] = true;
						}

					}

			}

			 

		// 1*2 [  ]
		else if (gameObject.tag == "Tile_2") {
				for (int i = 0; i < N - 1; i++)
					for (int j = 0; j < N - 1 - i; j++) {
						if (Vector3.Distance (transform.position, gridScript.GetPosition (i, j, "Tile_2")) <= radius) {
							transform.position = gridScript.GetPosition (i, j, "Tile_2");
							a = i;
							b = j;
							snap = true;
						}

						if(snap){
							if (i != a || j != b)
								tile_Info [tag, 2 * i+ j] = false;
							else
								tile_Info [tag, 2 * i+ j] = true;
						}

					}
			}

		// 2*1 [ ]
		//     [ ]
		else if (gameObject.tag == "Tile_3") {
				for (int i = 0; i < N - 1; i++)
					for (int j = 0; j < N - 1 - i; j++) {
						if (Vector3.Distance (transform.position, gridScript.GetPosition (i, j, "Tile_3")) <= radius) {
							transform.position = gridScript.GetPosition (i, j, "Tile_3");
							snap = true;
							a = i;
							b = j;
						}
						if (snap) {
							if (i != a || j != b)
								tile_Info [tag, 2 * i+ j] = false;
							else
								tile_Info [tag, 2 * i+ j] = true;
						}

					}
			}

		// 2*2 [  ]
		//     [  ]
		else if (gameObject.tag == "Tile_4") {
				for (int i = 0; i < N - 2; i++)
					for (int j = 0; j < N - 2 - i; j++) {
						if (Vector3.Distance (transform.position, gridScript.GetPosition (i, j, "Tile_4")) <= 2 * radius) {
							transform.position = gridScript.GetPosition (i, j, "Tile_4");
							snap = true;
							a = i;
							b = j;
						}

						if (snap) {
							if (i != a || j != b)
								tile_Info [tag, 2 * i+ j] = false;
							else
								tile_Info [tag, 2 * i+ j] = true;
						}

					}
			}


		// 1*3 [   ]
		else if (gameObject.tag == "Tile_5") {
				for (int i = 0; i < N - 2; i++)
					for (int j = 0; j < N - 2 - i; j++) {
						if (Vector3.Distance (transform.position, gridScript.GetPosition (i, j, "Tile_5")) <= radius) {
							transform.position = gridScript.GetPosition (i, j, "Tile_5");
							snap = true;
							a = i;
							b = j;
						}

						if (snap) {
							if (i != a || j != b)
								tile_Info [tag, 2 * i+ j] = false;
							else
								tile_Info [tag, 2 * i+ j] = true;
						}

					}
			} else if (gameObject.tag == "Tile_6") {
				for (int i = 0; i < N - 2; i++)
					for (int j = 0; j < N - 2 - i; j++) {
						if (Vector3.Distance (transform.position, gridScript.GetPosition (i, j, "Tile_6")) <= radius) {
							transform.position = gridScript.GetPosition (i, j, "Tile_6");
							snap = true;
							a = i;
							b = j;
						}

						if (snap) {
							if (i != a || j != b)
								tile_Info [tag, 2 * i+ j] = false;
							else
								tile_Info [tag, 2 * i+ j] = true;
						}

					}
			}
				

			gridScript.Check (tile_Info, tag);

			if (!snap)
				transform.position = objectBeginPosition;

		}//else


	}//OnEnd drag

}



