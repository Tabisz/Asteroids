using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Generator : MonoBehaviour {
    /* Generowanie meshow ktore tworza asteroidy*/

	private int radius;
	private int vertCount;
	private int randomness;


	public GameObject asteroidPrefab;



	private IEnumerator SplitC(GameObject hitObject)
	{
		AsteroidParam param = hitObject.GetComponentInChildren<AsteroidParam> ();
		if (param.vertCount > 6) 
		{
			Generate(param.radius / 2, param.vertCount / 2, param.randomness / 2 ,hitObject.transform.position);
			yield return new WaitForEndOfFrame ();
			Generate (param.radius / 2, param.vertCount / 2, param.randomness / 2,new Vector3(hitObject.transform.position.x+2*radius,hitObject.transform.position.y+2*radius,0));
		}
		Destroy(hitObject);
	}

	public void Split(GameObject hitObject)
	{
		StartCoroutine (SplitC (hitObject));
	}

	public void Generate(int _radius,int _vertCount,int _randomness, Vector3 _pos)
	{
		radius = _radius;
		vertCount = _vertCount;
		randomness = _randomness;

		GameObject ast = (GameObject)Instantiate (asteroidPrefab, _pos, Quaternion.identity, transform);

		ast.transform.GetComponentInChildren<MeshFilter>().mesh = GenerateMF (_radius, _vertCount, _randomness);
		CircleCollider2D Circle2d =  ast.transform.GetChild(0).gameObject.AddComponent<CircleCollider2D> ();
		Circle2d.radius = 2 * radius+randomness;
		Circle2d.offset = new Vector2(0,0);

		ast.transform.GetComponentInChildren<AsteroidParam>().SetUpParam(_radius,_vertCount,_randomness);
	}

	public Mesh GenerateMF(int _radius,int _vertCount,int _randomness)
	{

		Mesh mesh = new Mesh();
		mesh.Clear();

		int[] triangles = GetTriangles();
		Vector3[] vertices = GetVertices();
		Vector3[] normales = SetNormales();
		Vector2[] UVs = SetUVs();

		mesh.vertices = vertices;
		mesh.normals = normales;
		mesh.uv = UVs;
		mesh.triangles = triangles;
		mesh.RecalculateBounds();

		return mesh;

	}


	private Vector3[] GetVertices()
	{
		Vector3[] vertices = new Vector3[vertCount + 1];
		System.Random rand = new System.Random();
		float x, y;
		double radian;
		double angle = 90;
		double stepAngle = 360 / (double)vertCount;

		vertices[0] = new Vector3(0,0,0);

		//radian = Math.PI * angle / 180.0;

		for (int i = 1; i < vertCount + 1; i++)
		{

			int r = radius + rand.Next (radius, radius + randomness);
			radian = Math.PI * angle / 180.0;
			y = r * (float)Math.Sin(radian);
			x = r * (float)Math.Cos(radian);
			vertices[i] = new Vector3(x, y, 0);
			angle += stepAngle;

		}

		return vertices;
	}
	private int[] GetTriangles()
	{
		int[] triangles = new int[vertCount*3];
		int trC = 0;
		for (int i = 0; i < triangles.Length-3; i +=3)
		{
			triangles [i] = vertCount-trC;
			triangles[i+ 1] =vertCount -(trC+1) ;
			triangles [i + 2] = 0;
			trC++;
		}
		triangles [triangles.Length - 3] = 1;
		triangles [triangles.Length - 2] = vertCount;
		triangles [triangles.Length-1] = 0;

		return triangles;
	}

	private Vector3[] SetNormales()
	{
		Vector3[] normales = new Vector3[vertCount+1];
		for (int i = 0; i< vertCount+1; i++)
		{
			normales[i] = -Vector3.forward;
		}
		return normales;
	}
	private Vector2[] SetUVs()
	{

		Vector2[] UVs = new Vector2[vertCount+1];
		for(int i = 0; i<vertCount;i++)
			UVs[i] = new Vector2(1, 1);

		return UVs;
	}
}
