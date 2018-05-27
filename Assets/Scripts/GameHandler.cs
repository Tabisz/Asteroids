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
        foreach(Transform spwPoint in transform)
		{
			if (spwPoint.name == "SpawnPointR") {
				Debug.Log ("hej");
				Instantiate (PlayerA, spwPoint.position, spwPoint.rotation, transform);
				Destroy (spwPoint.gameObject);                                          //nie niszczyc spawnpointow jak bede chcial respawny
			} else if (spwPoint.name == "SpawnPointB") {
				Debug.Log ("ho");
				Instantiate (PlayerB, spwPoint.position, spwPoint.rotation, transform);
				Destroy (spwPoint.gameObject);
			} else {
				Debug.Log ("NULL");
			}
				
		}
	}
		
}

