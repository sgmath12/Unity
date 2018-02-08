using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // IBegDragHandler
using UnityEngine.SceneManagement;


public class Draggable : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler {

	public GameObject grid;



	private Vector3 mouseBeginPosition;
	private Vector3 mouseCurPosition;
	private Vector3 objectBeginPosition;
	private Vector3 originalPosition;
	private int a,stage;

	private GridScript gridScript;
	private Check check;
	private MouseClick mouseclick;

	//setting
	void Awake(){
		originalPosition = transform.position;
		gridScript = grid.GetComponent<GridScript> ();
		mouseclick = gameObject.GetComponent<MouseClick> ();
		check = grid.GetComponent<Check> ();
		stage = SceneManager.GetActiveScene ().name[6]-'0';
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
		string Sub = gameObject.tag.Substring (5);
		int T = Int32.Parse (Sub); // ex) tag = "Tile_3" then T = 3


		if (transform.position.x >= 0) {
			gameObject.transform.position = originalPosition;
			check.pop_tile_Info (T);
		}
		else {
			Snap (objectBeginPosition);
		}//else
	}//OnEnd drag


	public void Snap(Vector3 Back){

		float radius = 1f;
		bool snap = false;
		int N = gridScript.N;
		string Sub = gameObject.tag.Substring (5);
		int T = Int32.Parse (Sub); // ex) tag = "Tile_3" then T = 3
		Vector3 pos = transform.position;
		pos.z = 0;
		transform.position = pos;

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



		for (int i = 0; i < N - k; i++) {
			for (int j = 0; j < N - i - k; j++) {
				if (Vector3.Distance (transform.position, gridScript.GetPosition (i, j, T)) <= radius) {
					transform.position = gridScript.GetPosition (i, j, T);
					a = i;
					snap = true;
					break;
				}
			}
			if (snap)
				break;
		}
		

		check.pop_tile_Info (T);
		if (snap) {
			check.push_tile_Info (T, a);

			if (stage == 1)
				check.Is_complete_1 ();
			else if (stage == 2)
				check.Is_complete_2 (); 

			else if (stage == 3) {
				check.Is_complete_3 ();
			}
			else if(stage ==4)
				check.Is_complete_4 ();
		}

		else //!snap
			transform.position = Back;


	}
}



