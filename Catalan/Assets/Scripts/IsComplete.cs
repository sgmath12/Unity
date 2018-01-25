using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsComplete : MonoBehaviour {

	public GameObject tile0;
	public GameObject tile0_2;
	public GameObject tile1;
	public GameObject tile3;
	public GameObject tile4;
	public GameObject final;


	private GridScript gridscript;
	private Vector3 BeginPosition;
	private Vector3 Right;
	private Vector3 Up;
	public Text instruction;
	private int k;
	private bool[] Answer = new bool[5];

	void Start(){
		k = 0;
		for (int i = 0; i < 5; i++)
			Answer [i] = false;
		gridscript = gameObject.GetComponent<GridScript> ();
		BeginPosition = gridscript.transform.position;
		Right = (gridscript.EndPosition.x - BeginPosition.x) / (gridscript.N - 1)*Vector3.right;
		Up = (gridscript.EndPosition.y - BeginPosition.y) / (gridscript.N - 1)*Vector3.up;
	}


	// Update is called once per frame
	void Update () {
		if (tile3.transform.position
		   == gridscript.transform.position + 0.5f*Right
		   + 0.5f*Up ) {

			if (tile0.transform.position
			    == gridscript.transform.position + 2 * Right
			    &&
			    tile0_2.transform.position
			    == gridscript.transform.position + 2 * Up) 
			{
				if (Answer [0] == false) {
					k++;
					instruction.text = k + " / 5";
					Answer [0] = true;
				}
			} 

			else if (tile0.transform.position
			        == gridscript.transform.position + 2 * Up
			        &&
			        tile0_2.transform.position
			        == gridscript.transform.position + 2 * Right)
			{
				if (Answer [0] == false) {
					k++;
					instruction.text = k + " / 5";
					Answer [0] = true;
				}
			}
		}


		if (tile4.transform.position
			== gridscript.transform.position + 1f * Right) {

			if (tile1.transform.position
			   == gridscript.transform.position + 0.5f * Right + 1f * Up) {
				if (tile0.transform.position
				   == gridscript.transform.position + 2f * Up ||
				   tile0_2.transform.position
				   == gridscript.transform.position + 2f * Up) {
					if (Answer [1] == false) {
						k++;
						instruction.text = k + " / 5";
						Answer [1] = true;
					}
				}
			}


			if (tile1.transform.position
				== gridscript.transform.position + 1.5f * Up) {
				if (tile0.transform.position
					== gridscript.transform.position + 1f * Right +1f*Up ||
					tile0_2.transform.position
					== gridscript.transform.position + 1f * Right +1f*Up) {

					if (Answer [2] == false) {
						k++;
						instruction.text = k + " / 5";
						Answer [2] = true;
					}
				}
			}
		}


		if (tile4.transform.position
		    == gridscript.transform.position + 1f * Up) {

			if (tile1.transform.position
				== gridscript.transform.position + 1f * Right + 0.5f * Up) {
				if (tile0.transform.position
					== gridscript.transform.position + 2f * Right ||
					tile0_2.transform.position
					== gridscript.transform.position + 2f * Right) {
					if (Answer [3] == false) {
						k++;
						instruction.text = k + " / 5";
						Answer [3] = true;
					}
				}
			}


			if (tile1.transform.position
				== gridscript.transform.position + 1.5f * Right) {
				if (tile0.transform.position
					== gridscript.transform.position + 1f * Right +1f*Up ||
					tile0_2.transform.position
					== gridscript.transform.position + 1f * Right +1f*Up) {

					if (Answer [4] == false) {
						k++;
						instruction.text = k + " / 5";
						Answer [4] = true;
					}
				}
			}
		}


		if (k == 5) {
			Debug.Log ("HELLO");
			Instantiate (final);
			this.enabled = false;
		}

	}//Update



}

