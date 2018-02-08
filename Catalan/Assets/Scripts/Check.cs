using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Check : MonoBehaviour {

	public Text instruction;
	public GameObject final;
	public GameObject scene;

	public static bool[,] tile_Info=new bool[20, 20];
	private bool[] Answer=new bool[14];
	private int k;



	 void Awake(){
		k = 0;
	}
		
	public void Init_tile_Info(){
		for (int tag = 0; tag < 11; tag++)
			for (int j = 0; j < 5; j++)
				tile_Info [tag, j] = false;
	}

	public void push_tile_Info(int tag,int i){
		tile_Info [tag, i] = true;
	}

	public void pop_tile_Info(int tag){
		for(int i = 0; i <4;i++)
			tile_Info [tag, i] = false;
		
	}

	public void Is_complete_1(){

		if(tile_Info[0,0]){
			instruction.text = "1 / 1   stage 1";
			Instantiate (final);
			Instantiate (scene);
		}

	}

	public void Is_complete_2(){

		if(tile_Info[0,0]&&tile_Info[3,0]&&!Answer[0]){
			Answer [0] = true;
			k++;
			instruction.text = k + " / 2   stage 2";

		}

		if(tile_Info[0,1]&&tile_Info[2,0]&&!Answer[1]){
			Answer [1] = true;
			k++;
			instruction.text = k + " / 2   stage 2";

		}
			
		if (k == 2) {
			Instantiate (final);
			Instantiate (scene);
	
		}



	}




	public void Is_complete_3(){
		if (tile_Info [5, 0]) {



			if (tile_Info [2, 1] && tile_Info [0, 2] && !Answer [0] ||
			    tile_Info [2, 1] && tile_Info [1, 2] && !Answer [0]) {
				Answer [0] = true;
				k++;
				instruction.text = k + " / 5   stage 3";

			}
			if (tile_Info [3, 1] && tile_Info [0, 1] && !Answer [1] ||
			    tile_Info [3, 1] && tile_Info [1, 1] && !Answer [1]) {
				Answer [1] = true;
				k++;
				instruction.text = k + " / 5   stage 3";
			}

		
		}

		if (tile_Info [4, 0]) {
			if (tile_Info [0, 0] && tile_Info [1, 2] & !Answer [2] ||
			   tile_Info [1, 0] && tile_Info [0, 2] & !Answer [2]) {
				Answer [2] = true;
				k++;
				instruction.text = k + " / 5   stage 3";
			}
		}


		if (tile_Info [6, 0]) {
			if (tile_Info [3, 0] && tile_Info [0, 0] && !Answer [3] ||
				tile_Info [3, 0] && tile_Info [1, 0] && !Answer [3]) {
				Answer [3] = true;
				k++;
				instruction.text = k + " / 5   stage 3";

			}
			if (tile_Info [2, 0] && tile_Info [0, 1] && !Answer [4] ||
				tile_Info [2, 0] && tile_Info [1, 1] && !Answer [4]) {
				Answer [4] = true;
				k++;
				instruction.text = k + " / 5   stage 3";

			}

		}

		if (k == 5) {
			Instantiate (final);
			Instantiate (scene);
		}

	} // is_complete_3




	public void Is_complete_4(){

		if (tile_Info [9, 0]) {
			if (tile_Info [5, 1] && tile_Info [2, 2] && tile_Info [0, 3] && !Answer [0] ||
				tile_Info [5, 1] && tile_Info [2, 2] && tile_Info [1, 3] && !Answer [0]) {
				Answer [0] = true;
				k++;
				instruction.text = k + " / 14   stage 4";
			}

			if (tile_Info [5, 1] && tile_Info [3, 2] && tile_Info [0, 2] && !Answer [1] ||
				tile_Info [5, 1] && tile_Info [3, 2] && tile_Info [1, 2] && !Answer [1]) {
				Answer [1] = true;
				k++;
				instruction.text = k + " / 14   stage 4";

			}

			if (tile_Info [6, 1] && tile_Info [2, 1] && tile_Info [0, 2] && !Answer [2] ||
				tile_Info [6, 1] && tile_Info [2, 1] && tile_Info [1, 2] && !Answer [2]) {
				Answer [2] = true;
				k++;
				instruction.text = k + " / 14   stage 4";


			}

			if (tile_Info [6, 1] && tile_Info [3, 1] && tile_Info [0, 1] && !Answer [3] ||
			   tile_Info [6, 1] && tile_Info [3, 1] && tile_Info [1, 1] && !Answer [3]) {
				Answer [3] = true;
				k++;
				instruction.text = k + " / 14   stage 4";
			}


			if (tile_Info [4, 1] && tile_Info [0, 1] && tile_Info [1, 3] && !Answer [4] ||
			   tile_Info [4, 1] && tile_Info [1, 1] && tile_Info [0, 3] && !Answer [4]) {
	
				Answer [4] = true;
				k++;
				instruction.text = k + " / 14   stage 4";

			}


		}//if (tile_Info [9, 0])

		if (tile_Info [7, 0]) {

			if (tile_Info [2, 2] && tile_Info [0, 3] && tile_Info [1, 0] && !Answer [5] ||
			   tile_Info [2, 2] && tile_Info [1, 3] && tile_Info [0, 0] && !Answer [5]) {

				Answer [5] = true;
				k++;
				instruction.text = k + " / 14   stage 4";
			}

			if (tile_Info [3, 2] && tile_Info [0, 2] && tile_Info [1, 0] && !Answer [6] ||
				tile_Info [3, 2] && tile_Info [1, 2] && tile_Info [0, 0] && !Answer [6]) {

				Answer [6] = true;
				k++;
				instruction.text = k + " / 14   stage 4";

			}

		}//if (tile_Info[7,0])

		if (tile_Info [8, 0]) {

			if (tile_Info [3, 0] && tile_Info [0, 0] && tile_Info [1, 3] && !Answer [7] ||
			   tile_Info [3, 0] && tile_Info [1, 0] && tile_Info [0, 3] && !Answer [7]) {

				Answer [7] = true;
				k++;
				instruction.text = k + " / 14   stage 4";
			
			}

			if (tile_Info [2, 0] && tile_Info [0, 1] && tile_Info [1, 3] && !Answer [8] ||
				tile_Info [2, 0] && tile_Info [1, 1] && tile_Info [0, 3] && !Answer [8]) {
				Answer [8] = true;
				k++;
				instruction.text = k + " / 14   stage 4";

			}
		}//if (tile_Info[8,0])


		if (tile_Info [10, 0]) {
			if (tile_Info [5, 0] && tile_Info [2, 1] && tile_Info [0, 2] && !Answer [9] ||
			   tile_Info [5, 0] && tile_Info [2, 1] && tile_Info [1, 2] && !Answer [9]) {

				Answer [9] = true;
				k++;
				instruction.text = k + " / 14   stage 4";

			}

			if (tile_Info [5, 0] && tile_Info [3, 1] && tile_Info [0, 1] && !Answer [10] ||
				tile_Info [5, 0] && tile_Info [3, 1] && tile_Info [1, 1] && !Answer [10]) {

				Answer [10] = true;
				k++;
				instruction.text = k + " / 14   stage 4";

			}

			if (tile_Info [6, 0] && tile_Info [2, 0] && tile_Info [0, 1] && !Answer [11] ||
				tile_Info [6, 0] && tile_Info [2, 0] && tile_Info [1, 1] && !Answer [11]) {

				Answer [11] = true;
				k++;
				instruction.text = k + " / 14   stage 4";

			}


			if (tile_Info [6, 0] && tile_Info [3, 0] && tile_Info [0, 0] && !Answer [12] ||
				tile_Info [6, 0] && tile_Info [3, 0] && tile_Info [1, 0] && !Answer [12]) {

				Answer [12] = true;
				k++;
				instruction.text = k + " / 14   stage 4";

			}




			if (tile_Info [4, 0] && tile_Info [0, 0] && tile_Info [1, 2] && !Answer [13] ||
				tile_Info [4, 0] && tile_Info [1, 0] && tile_Info [0, 2] && !Answer [13]) {

				Answer [13] = true;
				k++;
				instruction.text = k + " / 14   stage 4";

			}
		} // if (tile_Info [10, 0])
			
		if (k == 14) {
			Instantiate (final);
			Instantiate (scene);
		}
	}//Is_complete();
}
