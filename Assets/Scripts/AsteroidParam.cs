using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidParam : MonoBehaviour {

	[HideInInspector]
	public int radius;
	[HideInInspector]
	public int vertCount;
	[HideInInspector]
	public int randomness;


	public void SetUpParam(int _radius,int _vertCount,int _randomness)
	{
		radius = _radius;
		vertCount = _vertCount;
		randomness = _randomness;

	}


}
