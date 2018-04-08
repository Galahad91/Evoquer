using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeCamera : MonoBehaviour {

	Texture2D blk;
	public bool fade;
	public float alph;
	public float speed;
	private bool tornomenu;
	private bool cambiacanzone;
	private int next_scena;
	private bool finegioco;

	void Start(){

		tornomenu = false;
		cambiacanzone = false;
		next_scena = 0;
		finegioco = false;

		//make a tiny black texture
		blk = new Texture2D (1, 1);
		blk.SetPixel (0, 0, new Color(0,0,0,0));
		blk.Apply ();
	}
	// put it on your screen
	void OnGUI(){
		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height),blk);
	}

	void Update () {
		


		if (!fade) {
			if (alph > 0) {
				alph -= Time.deltaTime * speed;
				if (alph < 0) {alph = 0f;}
				blk.SetPixel (0, 0, new Color (0, 0, 0, alph));
				blk.Apply ();
			}
		} 
		if (fade) {
			if (alph < 1) {
				alph += Time.deltaTime / speed;
				if (alph > 1) {alph = 1f;}
				blk.SetPixel (0, 0, new Color (0, 0, 0, alph));
				blk.Apply ();
			}

			if (alph >= 1 && tornomenu == true && cambiacanzone == false) 
			{

				//cambio livello
				Debug.Log("cambio livello");
				SceneManager.LoadScene ("menu");

			}

			if (alph >= 1 && cambiacanzone == true && tornomenu == false) 
			{

				//cambio livello
				Debug.Log("cambio livello");
				SceneManager.LoadScene (next_scena);

			}

			if (alph >= 1 && finegioco == true) {

				Debug.Log("cambio livello");
				SceneManager.LoadScene ("menu");

			}


		}
	}
		

	public void AvvioFade()
	{

		fade = true;
		tornomenu = true;


	}

	public void fineLivello()
	{

		fade = true;
		finegioco = true;

	}

	public void CambioScena(int scena)
	{

		fade = true;
		cambiacanzone = true;
		next_scena = scena;


	}
		

}
