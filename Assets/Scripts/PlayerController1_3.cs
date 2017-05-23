using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController1_3 : MonoBehaviour {

    public float speed,temps,timerDebut=0.0f,timerFin;
    public Text countText;
    public Text timeText;	
    public Text quitText;
	public int endGame;

	private GameObject water;
	private float minuterie;

    private Rigidbody rb;
    private int count,changeSpeed;

	float touchDuration;
	Touch touch;

	void Start ()
	{
		PlayerPrefs.SetInt("NumNiveau", 3);
    	Screen.orientation = ScreenOrientation.Portrait;

		timerDebut=Time.deltaTime;

		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		minuterie =0.0f;
		quitText.text = "Double-touch the screen to quit";
		water = GameObject.FindGameObjectWithTag("DangerWater");

    }

	void Main ()
	{
		// Evite que l'appareil se mette en veille pendant le jeu
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	void Update()
	{
		//Double Touch
		if (Input.touchCount > 0) //Dès qu'on touche l'écran...
		{
			touchDuration += Time.deltaTime;
			touch = Input.GetTouch (0);

			if (touch.phase == TouchPhase.Ended && touchDuration < 0.2f) { // Vérifie si c'est un simple short touch (pas appui long on double)
				StartCoroutine ("simpleOrDouble");
			}
            else {
				touchDuration = 0.0f;
			}
		}

	}
	void FixedUpdate () //Chercher les différences avec Update
	{
		if (SystemInfo.deviceType == DeviceType.Desktop) //Mouvement du joueur sur ordinateur
		{
			//Définition des composantes X et Y du vecteur force
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");
			//Création du vecteur force
			Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);
			//Ajout de la force au rigidbody
			rb.AddForce(movement * speed);
		}
		else //Mouvement du joueur sur smartphone
		{
			//Création du vecteur force
			Vector3 movement = new Vector3 (Input.acceleration.x, 0.0f, Input.acceleration.y);
			//Ajout de la force au rigidbody
			rb.AddForce(movement* 2 * speed/* * Time.deltaTime*/);
		}
	}

	IEnumerator simpleOrDouble() //Faire des recherches sur la classe + coroutine + WaitFoSeconds + Debug.Log
	{
		yield return new WaitForSeconds (0.3f);
		if (touch.tapCount == 2) {
			StopCoroutine("singleOrDouble");//Arrêt de coroutine pour ne pas l'appeler plus de fois et obtenir 2 double touch
			Application.Quit ();
		}
	}


	void OnTriggerEnter(Collider other)
	{
       // water2 = GameObject.FindGameObjectWithTag("");
		if (other.gameObject.CompareTag ("Pick Up")) //Si l'objet a pour tag "pick up"...
		{
			other.gameObject.SetActive (false); //On désactive l'objet de la scène
			count+=1000; //Et on rajoute 1 au compteur
			//speed++;
			SetCountText();
		}
		if (other.gameObject.CompareTag("Finishing"))
        {
       		PlayerPrefs.SetInt("endGame", 1);
			timerFin=Time.deltaTime;
			tempsDeJeu ();
			SceneManager.LoadScene("Score");
        }


        if (other.gameObject.CompareTag("DangerWater"))
        {
        	PlayerPrefs.SetInt("endGame", -1);
			timerFin=Time.deltaTime;
			tempsDeJeu ();
			SceneManager.LoadScene("Score");
        }

    }

	void SetCountText()
	{
		countText.text = "Score : " + count.ToString (); //On affichera "Count : " et le contenu de la variable count convertit en chaîne de caractères
	}
	public void tempsDeJeu (){
		float timer;
		timer = timerFin-timerDebut;
		PlayerPrefs.SetFloat("Temps", timer);

	}
}
