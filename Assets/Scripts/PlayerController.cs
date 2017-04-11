using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text endText;
	public Text quitText;

	private Rigidbody rb;
	private int count;

	float touchDuration;
	Touch touch;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		endText.text = "";
		quitText.text = "Double-touch the screen to exit";
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
			rb.AddForce(movement * speed/* * Time.deltaTime*/);
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
		if (other.gameObject.CompareTag ("Pick Up")) //Si l'objet a pour tag "pick up"...
		{
			other.gameObject.SetActive (false); //On désactive l'objet de la scène
			count++; //Et on rajoute 1 au compteur
			//speed++;
			SetCountText();
		}

	}

	void OnCollisionEnter(Collision other) 
	{
		if (other.gameObject.CompareTag ("Arrival"))
		{
			SetEndText ();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString (); //On affichera "Count : " et le contenu de la variable count convertit en chaîne de caractères
	}

	void SetEndText()
	{
		if (count >= 10) {
			endText.text = "You win!";
		}
		else 
		{
			endText.text = "You loose!";
		}
	}
}
