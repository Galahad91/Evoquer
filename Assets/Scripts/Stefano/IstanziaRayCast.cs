using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class IstanziaRayCast : MonoBehaviour {

	[Header("Layer per la casella P2 Torri")]
	public string Layer_Casella_P2_Torri = "Torre P2";
	[Header("Layer per la casella P2 Personaggi")]
	public string Layer_Casella_P2_Personaggi = "Torre P2";


	[Header("Layer per la casella P1 Torri")]
	public string Layer_Casella_P1_Torri = "Torre P1";
	[Header("Layer per la casella P1 Personaggi")]
	public string Layer_Casella_P1_Personaggi = "Torre P1";

	[Header("Oggetti per il buon funzionamento dello script")]
	public GameObject Pedina; //oggetto da istanziare 
	public GameObject Ogg_Gestore; //oggetto che contiene il riferimento del gestore
	private GestoreGioco gestore;

	[Header("Includere i layers che vuoi che collida con il raycast")]
	public LayerMask layers;

    [Header("Attiva e disattiva il raycast")]
    public bool isInGame = true;

	[Header("Icone Energia")]
	public Image p1Energy;
	public Image p2Energy;

	float timer = 1.2f;

    void Awake()
	{

		gestore = Ogg_Gestore.GetComponent<GestoreGioco> ();

	}

	// Update is called once per frame
	void Update ()
	{
        if (isInGame)
        {
			timer -= Time.deltaTime; 
            Ray puntatore = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(puntatore.origin, (puntatore.direction - Camera.main.transform.position));

			if (Input.GetMouseButtonDown(0) && timer <= 0)
            {
				timer = 1.2f;
                RaycastHit hit;

                //Ray puntatore = Camera.main.ScreenPointToRay (Input.mousePosition);
                //Ray puntatore = new Ray (Input.mousePosition, Vector3.down);

                //Debug.DrawRay (Input.mousePosition, Vector3.down);

                if (Physics.Raycast(puntatore, out hit) && Pedina != null && gameObject.GetComponent<GestoreGioco>().IsFaseCombattimento() == false)
                {

                    if (gestore.GetTurno() % 2 == 0)
                    {
                        //Player 2

                        if (hit.transform.gameObject.tag == "Libera" && hit.transform.gameObject.layer == LayerMask.NameToLayer(Layer_Casella_P2_Torri) && Pedina.tag == "Torre")
                        {

                            Debug.Log("Premuto");

                            if (gestore.GetEnergiaPlayer2() >= Pedina.GetComponent<IA_Torre>().Costo)
                            {

                                hit.transform.gameObject.tag = "Occupata";

                                GameObject torre = Instantiate(Pedina, new Vector3(hit.transform.position.x, 1, hit.transform.position.z), Quaternion.identity);

                                torre.GetComponent<IA_Torre>().SetCasella(hit.transform.gameObject);

                                Debug.Log("Istanzio Torre");

                                gestore.SottraiEnergia(Pedina.GetComponent<IA_Torre>().Costo, true);
                                //Suono Spawn Torre
                                gestore.GetComponent<Musica>().RiproduciSuono(10);
                            }
                            else
                            {
								//Feedback Niente Energia
								StartCoroutine(FeedbackNoEnergy());
                                Debug.Log("Costa troppo");

                            }

                        }
                        else if (hit.transform.gameObject.tag == "Libera" && hit.transform.gameObject.layer == LayerMask.NameToLayer(Layer_Casella_P2_Personaggi) && Pedina.tag == "Personaggio")
                        {

                            Debug.Log("Premuto");

                            if (gestore.GetEnergiaPlayer2() >= Pedina.GetComponent<Assassin>().Costo)
                            {
                                hit.transform.gameObject.tag = "Occupata";

                                Instantiate(Pedina, new Vector3(hit.transform.position.x, 1, hit.transform.position.z), Quaternion.identity);
                                Debug.Log("Istanzio Personaggio");

                                gestore.SottraiEnergia(Pedina.GetComponent<Assassin>().Costo, true);
                                //Suono Spawn pg
                                gestore.GetComponent<Musica>().RiproduciSuono(14);
                            }
                            else
                            {
								StartCoroutine (FeedbackNoEnergy ());
                                Debug.Log("Costa troppo");

                            }

                        }
                    }
                    else
                    {
                        //Player 1

                        if (hit.transform.gameObject.tag == "Libera" && hit.transform.gameObject.layer == LayerMask.NameToLayer(Layer_Casella_P1_Torri) && Pedina.tag == "Torre")
                        {

                            Debug.Log("Premuto");

                            if (gestore.GetEnergiaPlayer1() >= Pedina.GetComponent<IA_Torre>().Costo)
                            {
                                hit.transform.gameObject.tag = "Occupata";

                                GameObject torre = Instantiate(Pedina, new Vector3(hit.transform.position.x, 1, hit.transform.position.z), Quaternion.identity);

                                torre.GetComponent<IA_Torre>().SetCasella(hit.transform.gameObject);

                                Debug.Log("Istanzio Torre");

                                gestore.SottraiEnergia(Pedina.GetComponent<IA_Torre>().Costo, false);
                                //Suono Spawn Torre
                                gestore.GetComponent<Musica>().RiproduciSuono(11);
                            }
                            else
                            {
								StartCoroutine (FeedbackNoEnergy ());
                                Debug.Log("Costa troppo");

                            }
                        }
                        else if (hit.transform.gameObject.tag == "Libera" && hit.transform.gameObject.layer == LayerMask.NameToLayer(Layer_Casella_P1_Personaggi) && Pedina.tag == "Personaggio")
                        {

                            Debug.Log("Premuto");

                            if (gestore.GetEnergiaPlayer1() >= Pedina.GetComponent<Assassin>().Costo)
                            {

                                hit.transform.gameObject.tag = "Occupata";

                                Instantiate(Pedina, new Vector3(hit.transform.position.x, 1, hit.transform.position.z), Quaternion.identity);
                                Debug.Log("Istanzio Personaggio");

                                gestore.SottraiEnergia(Pedina.GetComponent<Assassin>().Costo, false);
                                //Suono Spawn Pg
                                gestore.GetComponent<Musica>().RiproduciSuono(15);

                            }
                            else
                            {
								StartCoroutine (FeedbackNoEnergy ());
                                Debug.Log("Costa troppo");

                            }

                        }

                    }

                }

            }
        }
	}

	/// <summary>
	/// Stesso metodo di quello sopra solo che viene richiamato da bottone
	/// </summary>
	/// <param name="oggetto">Oggetto.</param>
	public void ScegliClasse(GameObject oggetto)
	{

		Pedina = oggetto;
		Debug.Log ("Personaggio assegnato");

		//Debug.Log ("Premuto");

	}

    public void ActivateRaycast ()
    {
        isInGame = true;
    }

    public void DeactivateRaycast()
    {
        isInGame = false;
    }

	IEnumerator FeedbackNoEnergy()
	{
		if (gestore.GetTurno () % 2 == 0) 
		{
			p2Energy.transform.DOShakeRotation(1f,50);
			yield return null;
		}

		if (gestore.GetTurno () % 2 != 0) 
		{
			p1Energy.transform.DOShakeRotation(1f,50);
			yield return null;
		}
	}
}
