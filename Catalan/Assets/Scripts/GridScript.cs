using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridScript : MonoBehaviour {

	public Text instruction;
	public GameObject final;

	public int N;
	public Vector3[,] grid_0;
	public Vector3 EndPosition;
	private Vector3 unit_Right, unit_Down,coordinate;
	public float gridsize;

	void Awake(){
		if (N >= 2) {
			unit_Right = ((EndPosition - transform.position).x / (N - 1)) * Vector3.right; // (x,0,0) where x is a unit length of block width 
			unit_Down = ((EndPosition - transform.position).y / (N - 1)) * Vector3.up; //(0,y,0) where y is a unit length of block height
		} 
		else {
			unit_Right = new Vector3 (0, 0, 0);
			unit_Down = new Vector3 (0, 0, 0);
		}

	}

	public Vector3 GetPosition(int i , int j, int T){

		switch(T){
		// 1*1 block
		case 0:
		case 1:
			coordinate = i * unit_Down + j * unit_Right;
			break;
	
		// 1*2 block		
		case 2: 
			coordinate = i * unit_Down + (j + 0.5f) * unit_Right;
			break;

		// 2*1 block
		case 3:
			coordinate = (i+0.5f) * unit_Down + j * unit_Right;
			break; 

		// 2*2 block
		case 4:
			coordinate = (i + 0.5f) * unit_Down + (j + 0.5f) * unit_Right;
			break;
	
		// 1*3 block
		case 5:
			coordinate = i * unit_Down + (j + 1f) * unit_Right;
			break;

		// 3*1 block
		case 6:
			coordinate = (i + 1f) * unit_Down + j * unit_Right;												
			break;
		
		// 2*3 block
		case 7:
			coordinate = (i + 0.5f) * unit_Down + (j + 1f) * unit_Right;
			break;
		
		// 3*2 block
		case 8:
			coordinate = (i + 1f) * unit_Down + (j + 0.5f) * unit_Right;
			break;
		
		// 1*4 block
		case 9:
			coordinate = i * unit_Down + (j + 1.5f) * unit_Right;
			break;
		
		// 4*1 block
		case 10:
			coordinate = i * unit_Down+ 1.5f*unit_Down + j * unit_Right;
			break;
		} //switch
	

		return transform.position + coordinate;

	}


	public void OnDrawGizmos(){
		Gizmos.color = Color.white;

		if (N == 1)
			Gizmos.DrawWireCube (transform.position, new Vector3 (gridsize, gridsize, 0));
		else {
			grid_0 = new Vector3[N, N];
			for (int i = 0; i < N; i++)
				for (int j = 0; j < N - i; j++) {
					grid_0 [i, j] = transform.position +
					(j * (EndPosition - transform.position).x / (N - 1)) * Vector3.right +
					(i * (EndPosition - transform.position).y / (N - 1)) * Vector3.up;

					Gizmos.DrawWireCube (grid_0 [i, j], new Vector3 (gridsize, gridsize, 0));
				}
		}
	} // OnDrawGizmos() 





}



