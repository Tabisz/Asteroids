using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {



	public static int playerCount;
	private string sceneName;
	private int Maxplayers;


	public GameObject PlayerA;
	public GameObject PlayerB;
	public GameObject PlayerG;

	private GameObject Canvas;


	void Awake()
	{
		sceneName = SceneManager.GetActiveScene ().name;
		if (sceneName == "1") {
			Screen.orientation = ScreenOrientation.LandscapeLeft;
		} else if (sceneName == "2") 
		{
			Screen.orientation = ScreenOrientation.Portrait;
		}

		playerCount = transform.childCount;
		Maxplayers = playerCount;
	}
	void Start () {
		SpawnPlayers();

	}
	
	// Update is called once per frame
	void Update () {

		if (playerCount < Maxplayers) {
			SceneManager.LoadScene (sceneName);
		}
		
	}







	private void SpawnPlayers()
	{
		
		GameObject[] spwPoints = new GameObject[transform.childCount];
		for (int i = 0; i < spwPoints.Length; i++)
		{
			spwPoints [i] = transform.GetChild (i).gameObject;
		}

		for (int i = 0; i < spwPoints.Length; i++)
		{
			if (spwPoints[i].name == "SpawnPointR") {
				Debug.Log ("hej");
				Instantiate (PlayerA, spwPoints[i].transform.position, spwPoints[i].transform.rotation, this.transform);
				Destroy (spwPoints[i]);
			} else if (spwPoints[i].name == "SpawnPointB") {
				Debug.Log ("ho");
				Instantiate (PlayerB, spwPoints[i].transform.position, spwPoints[i].transform.rotation, transform);
				Destroy (spwPoints[i]);
			} else {
				Debug.Log ("NULL");
			}
				
		}
	}
		
}
