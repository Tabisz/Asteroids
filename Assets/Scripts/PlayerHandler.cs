using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour {



	private int dir = 1;
	private Vector3 target;

	[Range(1f,100f)]
	public  float radius;
	[Range(0f,100f)]
	public float speed;
	private float timecounter = 0;
	private GameObject anchor;

	[HideInInspector]
	public GameObject bulletPrefab;
	public GameObject shootPoint;

	private bool reload = false;
	public float reloadTime;

	private GameObject ChangeB;
	private GameObject ShootB;

    public float gameSpeed = 5;// dodac poruszanie tla bo nie widac ze sie cofasz

	public ParticleSystem.EmissionModule exhaust;
	// Use this for initialization
	void Start () {
		//PlayerGen genBody = transform.GetComponentInChildren<PlayerGen> ();
		//genBody.Generate ();
		AssignButtons(gameObject.name);


		exhaust = GetComponentInChildren<ParticleSystem> ().emission;
	    anchor = new GameObject ("anchor "+ gameObject.name);
		anchor.transform.position = new Vector3 (transform.position.x + radius,transform.position.y,0f);
		anchor.transform.SetParent (Camera.main.transform);

	}
	
	// Update is called once per frame

	void Update()
	{
		

		timecounter += Time.deltaTime*speed*dir;
		Vector3 translation = new Vector3 ( Mathf.Cos (timecounter),Mathf.Sin (timecounter),transform.position.z);

		var newRotation = Quaternion.LookRotation(transform.position - anchor.transform.position, Vector3.forward*dir);
		newRotation.x = 0.0f;
		newRotation.y = 0.0f;
		transform.rotation = newRotation;

		transform.position = new Vector3 (anchor.transform.position.x + translation.x*radius*dir,anchor.transform.position.y + translation.y*radius*dir, transform.position.z);

        anchor.transform.position += Vector3.down * Time.deltaTime* gameSpeed;
        Debug.DrawLine (transform.position,anchor.transform.position,Color.green);
	}

	void GetNextAnchor ()
	{
        Vector3 newAnchorPos = anchor.transform.position+ (transform.position - anchor.transform.position) * 2;

        if (CameraSize.CheckIfOnScreen(0, newAnchorPos))
        {
            dir = -dir;
            anchor.transform.position = newAnchorPos;
        }
         
	}


	void OnShootPointerDown()
	{
		if (!reload)
		{
			Vector3 shootPos = shootPoint.transform.position;
			GameObject bullet = (GameObject)Instantiate (bulletPrefab, shootPos, shootPoint.transform.rotation, transform);
			bullet.transform.SetParent (GameObject.FindGameObjectWithTag ("MainCamera").transform);
			reload = true;
			StartCoroutine (Delay (reloadTime));

		}
	}
	public IEnumerator Delay(float s)
	{
		yield return new WaitForSeconds (s);
		reload = false;
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		GameHandler.playerCount--;
		Debug.Log (GameHandler.playerCount);
		Destroy (transform.gameObject);

	}

	void AssignButtons (string name)
	{
		Button butt;
		if (name == "PlayerA(Clone)") {
			ChangeB = GameObject.Find ("ChangeBR");
			butt = ChangeB.GetComponent<Button> ();
			butt.onClick.AddListener (() => {GetNextAnchor();});

			ShootB =  GameObject.Find ("ShootBR");
			butt = ShootB.GetComponent<Button> ();
			butt.onClick.AddListener (() => {OnShootPointerDown();});


		} else if (name == "PlayerB(Clone)") {

			ChangeB = GameObject.Find ("ChangeBB");
			butt = ChangeB.GetComponent<Button> ();
			butt.onClick.AddListener (() => {GetNextAnchor();});

			ShootB =  GameObject.Find ("ShootBB");
			butt = ShootB.GetComponent<Button> ();
			butt.onClick.AddListener (() => {OnShootPointerDown();});
			
		} 
		if (ChangeB)
			Debug.Log (name +"Have buttons now");
		else
			Debug.Log ("No buttons found");



	}
		

}
