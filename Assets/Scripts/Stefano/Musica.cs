using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class Musica : MonoBehaviour {

	public List<Brano> PlayList;
	public AudioSource AudioSource;
	private int ID_suono;

	[System.Serializable]
	public class Brano
	{
		[Header("Suono da istanziare")]
		public AudioClip audio;
		[Header("ID univoco della canzone numerico crescente")]
		public int ID;
		[Header("Descrizione del suono")]
		public string Descrizione;
		[Header("Volume del suono")]
		[Range(0f,1f)]
		public float Volume;

	}

	void Awake()
	{

		AudioSource = gameObject.GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKeyDown (KeyCode.A)) 
		{

			ID_suono =  Random.Range (0, 3);

			RiproduciSuono (ID_suono);

		}

	}

	/// <summary>
	/// Metodo che riproduce l'audio passando l'ID della canzone della lista
	/// </summary>
	/// <param name="ID">ID della canzone da riprodurre</param>
	public void RiproduciSuono(int ID)
	{

		for (int i = 0; i < PlayList.Count; i++) {

			if (PlayList [i].ID == ID) {

				Debug.Log ("Riproduco suono "+ PlayList[i].ID);
				AudioSource.PlayOneShot (PlayList [i].audio, PlayList[i].Volume);
				return;

			}

		}

		Debug.LogError ("Muisca non trovata CONTROLLARE LISTA");


	}
}
