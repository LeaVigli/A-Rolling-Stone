using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour {

    private string nomMonde= "Monde ";
    private string nomScene="Niveau ";
    

    void Start (){
        Screen.orientation = ScreenOrientation.Portrait;
    }

	public void Monde1()
    {
        SceneManager.LoadScene("Monde 1");
        PlayerPrefs.SetInt("NumMonde", 1);
    }

	public void Monde2()
    {
        SceneManager.LoadScene("Monde 2");
        PlayerPrefs.SetInt("NumMonde", 2);
    }
	public void Monde3()
    {
        SceneManager.LoadScene("Monde 3");
        PlayerPrefs.SetInt("NumMonde", 3);
    }
	public void Monde4()
    {
        SceneManager.LoadScene("Monde 4");
        PlayerPrefs.SetInt("NumMonde", 4);
    }

	public void Niveau1()
    {
        if(PlayerPrefs.GetInt("NumMonde")==1)
        {
            SceneManager.LoadScene("1-1");
        }else{
             if(PlayerPrefs.GetInt("NumMonde")==2){
                SceneManager.LoadScene("2-1");
             }else{
                if(PlayerPrefs.GetInt("NumMonde")==3){
                    SceneManager.LoadScene("3-1");
                }else{
                    if(PlayerPrefs.GetInt("NumMonde")==4){
                        SceneManager.LoadScene("4-1");
                    }
                }
             }
        }
    }

	public void Niveau2()
    {
        if(PlayerPrefs.GetInt("NumMonde")==1)
        {
            SceneManager.LoadScene("1-2");
        }else{
             if(PlayerPrefs.GetInt("NumMonde")==2){
                SceneManager.LoadScene("2-2");
             }else{
                if(PlayerPrefs.GetInt("NumMonde")==3){
                    SceneManager.LoadScene("3-2");
                }else{
                    if(PlayerPrefs.GetInt("NumMonde")==4){
                        SceneManager.LoadScene("4-2");
                    }
                }
             }
        }
    }

    public void Restart()
    {   
        string RestartScene = nomScene + PlayerPrefs.GetInt("NumMonde")+"-"+ PlayerPrefs.GetInt("NumNiveau");
        SceneManager.LoadScene(RestartScene);  
    }
        

    public void Next()
    {
           if (PlayerPrefs.GetInt("NumNiveau")<=2){
            int numProchainNiveau = 1+PlayerPrefs.GetInt("NumNiveau");
            string NextScene = nomScene + PlayerPrefs.GetInt("NumMonde")+"-"+ numProchainNiveau;
            SceneManager.LoadScene(NextScene);
        }else{
            if(PlayerPrefs.GetInt("NumMonde")<=2){
                int numProchainMonde = PlayerPrefs.GetInt("NumMonde")+1;
                string nextMonde = nomMonde+ numProchainMonde;
                SceneManager.LoadScene(nextMonde);    
            }       
        }         
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main");
    }
}
