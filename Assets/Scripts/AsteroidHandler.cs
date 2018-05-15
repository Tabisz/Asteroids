using UnityEngine;
using System;

public class AsteroidHandler : MonoBehaviour { 	//na prefabie
	private Vector2 way;
	private int speed = 100;
	private System.Random rand;
	private float HBoundX;
	private float LBoundX;

	private float HBoundY;
	private float LBoundY;

	private float offset;



	// Use this for initialization
	void Start () {
		rand = new System.Random ();


		HBoundX = CameraSize.HBoundX();
		LBoundX = CameraSize.LBoundX();

		HBoundY = CameraSize.HBoundY();
		LBoundY = CameraSize.LBoundY();

		Rigidbody2D RD = GetComponent<Rigidbody2D>();
		way = GetNewWay ();
		RD.AddForce(way);
		offset = GetComponentInChildren<AsteroidParam> ().radius*2f;

	}

	Vector2 GetNewWay()
	{
		Vector2 way = new Vector2 (rand.Next(-6,6)*speed*5,rand.Next(-10,0)*speed*5);
		return way;

	}
	
	// Update is called once per frame
	void Update () {
		

		/* ----------przechodzenie z ekranu na ekran---------------------(loopowanie)
		 if (transform.position.x > HBoundX + offset)
			transform.position = new Vector3(LBoundX - offset,transform.position.y,transform.position.z);
		if (transform.position.x < LBoundX - offset)
			transform.position = new Vector3(HBoundX + offset,transform.position.y,transform.position.z);
		
		if (transform.position.y > HBoundY + offset)
			transform.position = new Vector3(transform.position.x,LBoundY - offset,transform.position.z);
		if (transform.position.y < LBoundY - offset)
			transform.position = new Vector3(transform.position.x,HBoundY + offset,transform.position.z);
			*/

		if (transform.position.x > HBoundX + offset)
			Destroy (gameObject);
		if (transform.position.x < LBoundX - offset)
			Destroy (gameObject);

		if (transform.position.y > HBoundY + offset)
			Destroy (gameObject);
		if (transform.position.y < LBoundY - offset)
			Destroy (gameObject);
	}










		

}
