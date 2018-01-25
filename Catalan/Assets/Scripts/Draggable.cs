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
	private Vector3 originalPosition;

	private GridScript gridScript;

	void Awake(){
		originalPosition = transform.position;

	}

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
		gridScript = grid.GetComponent<GridScript> ();
		int N = gridScript.N;


	
		if (mouseCurPosition.x>=0) {
			transform.position = originalPosition;
		}
		else {

	
			// 1*1 [ ]
			if (gameObject.tag == "Tile_0") {
				for (int i = 0; i < N; i++)
					for (int j = 0; j < N - i; j++) {
						if (Vector3.Distance (transform.position, gridScript.GetPosition (i, j, "Tile_0")) <= radius) {
							transform.position = gridScript.GetPosition (i, j, "Tile_0");
							snap = true;
							break;
						}

					}

			} 

		// 1*2 [  ]
		else if (gameObject.tag == "Tile_1") {
				for (int i = 0; i < N - 1; i++)
					for (int j = 0; j < N - 1 - i; j++) {
						if (Vector3.Distance (transform.position, gridScript.GetPosition (i, j, "Tile_1")) <= radius) {
							transform.position = gridScript.GetPosition (i, j, "Tile_1");
							snap = true;
							break;
						}

					}
			}

		// 2*1 [ ]
		//     [ ]
		else if (gameObject.tag == "Tile_2") {
				for (int i = 0; i < N - 1; i++)
					for (int j = 0; j < N - 1 - i; j++) {
						if (Vector3.Distance (transform.position, gridScript.GetPosition (i, j, "Tile_2")) <= radius) {
							transform.position = gridScript.GetPosition (i, j, "Tile_2");
							snap = true;
							break;
						}

					}
			}

		// 2*2 [  ]
		//     [  ]
		else if (gameObject.tag == "Tile_3") {
				for (int i = 0; i < N - 2; i++)
					for (int j = 0; j < N - 2 - i; j++) {
						if (Vector3.Distance (transform.position, gridScript.GetPosition (i, j, "Tile_3")) <= 2 * radius) {
							transform.position = gridScript.GetPosition (i, j, "Tile_3");
							snap = true;
							break;
						}

					}
			}


		// 1*3 [   ]
		else if (gameObject.tag == "Tile_4") {
				for (int i = 0; i < N - 2; i++)
					for (int j = 0; j < N - 2 - i; j++) {
						if (Vector3.Distance (transform.position, gridScript.GetPosition (i, j, "Tile_4")) <= radius) {
							transform.position = gridScript.GetPosition (i, j, "Tile_4");
							snap = true;
							break;
						}

					}
			} else if (gameObject.tag == "Tile_5") {
				for (int i = 0; i < N - 2; i++)
					for (int j = 0; j < N - 2 - i; j++) {
						if (Vector3.Distance (transform.position, gridScript.GetPosition (i, j, "Tile_5")) <= radius) {
							transform.position = gridScript.GetPosition (i, j, "Tile_5");
							snap = true;
							break;
						}

					}
			}



	


			if (!snap)
				transform.position = objectBeginPosition;

		}


	}//else

}


