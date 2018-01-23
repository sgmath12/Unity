using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour {


	public int N;
	public Vector3[,] grid_0;
	public Vector3 EndPosition;
	public float gridsize;


	public Vector3 GetPosition(int i , int j, string tag){
		if (tag == "Tile_0") {
			return 	transform.position +
			(j * (EndPosition - transform.position).x / (N - 1)) * Vector3.right +
			(i * (EndPosition - transform.position).y / (N - 1)) * Vector3.up;
		} 
		else if (tag == "Tile_1") {
			return 	transform.position +
			(j * (EndPosition - transform.position).x / (N - 1)) * Vector3.right +
			(i * (EndPosition - transform.position).y / (N - 1)) * Vector3.up +
			(0.5f * (EndPosition - transform.position).x / (N - 1)) * Vector3.right;
		}
		else if (tag == "Tile_3") {
			return 	transform.position +
			(j * (EndPosition - transform.position).x / (N - 1)) * Vector3.right +
			(i * (EndPosition - transform.position).y / (N - 1)) * Vector3.up +
			(1f * (EndPosition - transform.position).x / (N - 1)) * Vector3.right;
		} 
		else if (tag == "Tile_4") {
			return 	transform.position +
				(j * (EndPosition - transform.position).x / (N - 1)) * Vector3.right +
				(i * (EndPosition - transform.position).y / (N - 1)) * Vector3.up +
				(0.5f * (EndPosition - transform.position).x / (N - 1)) * Vector3.right+
				(0.5f * (EndPosition - transform.position).y / (N - 1)) * Vector3.up;
		
		}


		return new Vector3 (0, 0, 0);

	}



	public void OnDrawGizmos(){
		Gizmos.color = Color.white;
		grid_0 = new Vector3[N, N];
		for (int i = 0; i < N; i++)
			for (int j = 0; j < N - i; j++) {
				grid_0 [i, j] = transform.position +
					(j * (EndPosition - transform.position).x / (N-1)) * Vector3.right +
					(i * (EndPosition - transform.position).y / (N-1)) * Vector3.up;
				
				Gizmos.DrawWireCube(grid_0[i,j],new Vector3(gridsize,gridsize,0));
			}
	
	} // OnDrawGizmos() 


}
