using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Asteroid : MonoBehaviour {	// NA ASTEROIDS
	public int radius;		//
	public int vertCount;	//temporary
	public int randomness;	//

	public GameObject asteroidPrefab;
	private System.Random rand;
	public int rozprysk;

	public Text text;
	private Generator generator;

	private int AsteroidCount = 0;


	Vector3 touchPosWorld;
	//Change me to change the touch phase used.
	TouchPhase touchPhase = TouchPhase.Ended;

	void Start()
	{
		generator = GetComponent<Generator> ();
		rand = new System.Random ();
	}

	public void MakePrefab()//temporary
	{
		Vector3 pos = new Vector3 (rand.Next (-(int)CameraSize.SizeX / 2,(int)CameraSize.SizeX / 2),transform.position.y, 0);
		generator.Generate(radius,vertCount,randomness,pos);


	}

	public void MakePrefab(int _radius,int _vertCount,int _randomness, Vector3 _pos)
	{
		generator.Generate(_radius,_vertCount,_randomness,_pos);
	}


	void Update() {     
		AsteroidCount = transform.childCount;
		if (AsteroidCount < 2)
		{
			MakePrefab ();
		}
                                                                   //sprawdza czy zostala dotknieta jakas asteroida                                     
		//We check if we have more than one touch happening.
		//We also check if the first touches phase is Ended (that the finger was lifted)
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == touchPhase) {
			//We transform the touch position into word space from screen space and store it.
			touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

			Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

			//We now raycast with this information. If we have hit something we can process it.
			RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

			if (hitInformation.collider != null) {
				//We should have hit something with a 2D Physics collider!
				GameObject touchedObject = hitInformation.transform.gameObject;
				//touchedObject should be the object someone touched.


				generator.Split (touchedObject);            //rozdziealnie asteroidy na mniejsze


			}
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}





}
