using UnityEngine;
using System;

public class AsteroidHandler : MonoBehaviour { 	//na prefabie
	private Vector2 way;
	private int speed = 100;
	private System.Random rand;

	private float offset;



	// Use this for initialization
	void Start () {
		rand = new System.Random ();



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
        transform.position = CameraSize.CheckIfOnScreenWithTransfer(offset, transform.position);

        /*

                if (transform.position.x > HBoundX + offset)
                    Destroy (gameObject);
                if (transform.position.x < LBoundX - offset)
                    Destroy (gameObject);

                if (transform.position.y > HBoundY + offset)
                    Destroy (gameObject);
                if (transform.position.y < LBoundY - offset)
                    Destroy (gameObject);
            */
    }












}
