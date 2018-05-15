using UnityEngine;
using System.Collections;


public class BulletScript : MonoBehaviour {

	public float speed = 30000f;

	private float boundX;
	private float boundY;
	public GameObject Hit;


	void Start()
	{
		boundX = CameraSize.SizeX () / 2;
		boundY = CameraSize.SizeY () / 2;


	
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		
		//Debug.Log (collision.gameObject.name);
		if (collision.collider.gameObject.tag == "Asteroids")
		{
			Debug.Log ("hop");
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<Generator> ().Split (collision.collider.gameObject);

		}
		Debug.Log ("emit");
		Instantiate (Hit,transform.position,transform.rotation);

				Destroy (gameObject);
			

	


			
	}
	void Update()
	{
		transform.Translate (Vector3.up * speed * Time.deltaTime);
		if (Mathf.Abs (transform.position.x) > boundX || Mathf.Abs (transform.position.y) > boundY)
			Destroy (gameObject);




	}


}
