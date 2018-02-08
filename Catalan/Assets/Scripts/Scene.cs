using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour {

	private int stage;

	void Awake(){
		stage = SceneManager.GetActiveScene ().name[6]-'0';
	}

	public void Play(){
		SceneManager.LoadScene ("Stage_1");
	}

	public void Quit(){
		Application.Quit ();
	}

	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			if (stage == 1)
				SceneManager.LoadScene ("Stage_2");
			else if (stage == 2)
				SceneManager.LoadScene ("Stage_3");

			else if (stage == 3)
				SceneManager.LoadScene ("Stage_4");
			else if (stage == 4)
				SceneManager.LoadScene ("Stage_3");

		}
 }

}
