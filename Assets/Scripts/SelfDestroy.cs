using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour {
	public float delay;
	// Use this for initialization
	void Start () {
		delay = GetComponentInChildren<ParticleSystem> ().main.duration;
		StartCoroutine (Delay (delay));
	}
	
	// Update is called once per frame


	public IEnumerator Delay(float s)
	{
		yield return new WaitForSeconds (s);
		Destroy (gameObject);
	}
}
