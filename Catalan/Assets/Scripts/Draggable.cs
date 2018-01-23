using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // IBegDragHandler


//prae
public class Draggable : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler {

	private Vector3 mouseBiginPosition;
	private Vector3 objectBiginPosition;
	public GameObject grid;


	private GridScript gridScript;

	public void OnBeginDrag(PointerEventData eventData)
	{
		mouseBiginPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		objectBiginPosition = transform.position;

	}

	public void OnDrag(PointerEventData eventData)
	{
		Vector3 mouseCurPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = mouseCurPosition+(objectBiginPosition - mouseBiginPosition);
	}

	public void OnEndDrag(PointerEventData eventData){
		float radius= 1;
		bool snap=false;
		gridScript = grid.GetComponent<GridScript> ();
		int N = gridScript.N;

	
	
		if (gameObject.tag == "Tile_0") {
			for (int i = 0; i < N; i++)
				for (int j = 0; j < N - i; j++) {
					if (Vector3.Distance (transform.position, gridScript.GetPosition (i, j,"Tile_0")) <= radius) {
						transform.position = gridScript.GetPosition (i, j,"Tile_0");
						snap = true;
						break;
					}

				}

		} 

		else if (gameObject.tag == "Tile_1") {
			for (int i = 0; i < N-1; i++)
				for (int j = 0; j < N-1-i; j++) {
					if (Vector3.Distance (transform.position, gridScript.GetPosition (i, j,"Tile_1")) <= radius) {
						transform.position = gridScript.GetPosition (i, j,"Tile_1");
						snap = true;
						break;
					}

				}
		}

		else if (gameObject.tag == "Tile_3") {
			for (int i = 0; i < N-2; i++)
				for (int j = 0; j < N-2-i; j++) {
					if (Vector3.Distance (transform.position, gridScript.GetPosition (i, j,"Tile_3")) <= radius) {
						transform.position = gridScript.GetPosition (i, j,"Tile_3");
						snap = true;
						break;
					}

				}
		}

		else if (gameObject.tag == "Tile_4") {
			for (int i = 0; i < N-2; i++)
				for (int j = 0; j < N-2-i; j++) {
					if (Vector3.Distance (transform.position, gridScript.GetPosition (i, j,"Tile_4")) <= 2*radius) {
						transform.position = gridScript.GetPosition (i, j,"Tile_4");
						snap = true;
						break;
					}

				}
		}






		if (!snap) 
			transform.position = objectBiginPosition;

	}

}


