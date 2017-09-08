using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {
	private float temps;
	public Text endGame,tempsPartie;
	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetInt("endGame")==1){
		    endGame.text = "Victoire";
		}else{
			if(PlayerPrefs.GetInt("endGame")==-1){
		        endGame.text = "Défaite";
			}else{
		        endGame.text = "Erreur";				
			}
		}
		temps=PlayerPrefs.GetFloat("Temps");
		tempsPartie.text = "Temps : "+temps;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
