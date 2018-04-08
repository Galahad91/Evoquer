using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GestioneVideo : MonoBehaviour {

	[Header("Video player dell'intro gioco")]
	public VideoPlayer VideoPlayer;

	[Header("SCENE MANAGER")]
	//[Header("True = stringa False = intero")]
	//public bool Stringa = false;
	//[Header("Stringa per caricare la scena")]
	//public string Nome_Scena;
	[Header("Index della scena")]
	public int Index_Scena;

	private bool isPausa = false;
	private FadeCamera fade;

	void Awake()
	{

		fade = gameObject.GetComponent<FadeCamera> ();

	}

	void Update () 
	{
		
		ControlloVideoPlayer ();

		/*if (Input.GetKeyDown (KeyCode.A)) 
		{

			Debug.Log ("Skip Video");
			VideoPlayer.Pause ();
			fade.CambioScena (Index_Scena);


		}

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			ControlloAndamento ();
		}*/

	}

	/// <summary>
	/// Metodo che permette di skippare solo il video di Gioia
	/// </summary>
	public void SkipVideo()
	{

		Debug.Log ("Skip Video");
		VideoPlayer.Pause ();
		fade.CambioScena (Index_Scena);

	}

	/// <summary>
	/// Metodo che permette di mettere in pausa e riprendere il video
	/// </summary>
	public void ControlloAndamento()
	{

		if (VideoPlayer.isPlaying == true) 
		{

			Debug.Log ("Pausa");
			VideoPlayer.Pause ();
			isPausa = true;

		} 
		else 
		{

			Debug.Log ("Play");
			VideoPlayer.Play ();
			isPausa = false;

		}


	}

	/// <summary>
	/// Metodo che controlla l'andamento del video
	/// </summary>
	public void ControlloVideoPlayer()
	{

		if (VideoPlayer.isPlaying == false && isPausa == false) 
		{ 

			Debug.Log ("Video terminato");
			fade.CambioScena (Index_Scena);

		}
			
	}


	/// <summary>
	/// Metodo che cambia la scena di gioco 
	/// </summary>
	/*private void CambioScena()
	{

		if (Stringa == true) 
		{

			fade.CambioScena(Nome_Scena);

		} 
		else 
		{

			fade.CambioScena(Index_Scena);

		}

	}*/

}
