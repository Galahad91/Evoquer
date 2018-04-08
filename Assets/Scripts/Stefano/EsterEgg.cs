using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EsterEgg : MonoBehaviour {

	public VideoPlayer Principale;
	public VideoPlayer Cazzata;

	private bool toggle;

	// Use this for initialization
	void Start () 
	{

		toggle = true;

	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKeyDown (KeyCode.Space)) {


			if (toggle == true) {

				toggle = false;

				Principale.gameObject.SetActive (false);
				Cazzata.gameObject.SetActive (true);

			} else {

				toggle = true;

				Principale.gameObject.SetActive (true);
				Cazzata.gameObject.SetActive (false);

				Debug.Log ("Normale");

			}

		}
		
	}
}
