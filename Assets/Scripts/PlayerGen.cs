using UnityEngine;
using System.Collections;

public class PlayerGen : MonoBehaviour {
    //generowanie mesha dla gracza w krztalcie trojkata(nieuzywane)
	// Use this for initialization
	public void Generate() {

		MeshFilter mf =gameObject.AddComponent<MeshFilter>();
		Mesh mesh = new Mesh();
		mesh.Clear();
		mf.mesh = mesh;

		int[] triangles = GetTriangles();
		Vector3[] vertices = GetVertices();
		Vector3[] normales = SetNormales();
		Vector2[] UVs = SetUVs();

		mesh.vertices = vertices;
		mesh.normals = normales;
		mesh.uv = UVs;
		mesh.triangles = triangles;
		mesh.RecalculateBounds();

//			EdgeCollider2D Edge2d = gameObject.AddComponent<EdgeCollider2D> ();
//			Vector2[] EdgeBuffer = new Vector2[vertices.Length+1];
//			for (int i = 0; i < EdgeBuffer.Length-1; i++) {
//				EdgeBuffer [i] = new Vector2 (vertices [i].x, vertices [i].y);
//			}
//		EdgeBuffer [vertices.Length] = EdgeBuffer [0];
//
//			Edge2d.points = EdgeBuffer;

	}

	Vector3[] GetVertices()
	{
		Vector3[] vertices = new Vector3[3];

		vertices[0] = new Vector3(0f, 16, 0);
		vertices[1] = new Vector3(-10f,-8f,0);
		vertices[2] = new Vector3(10f,-8f,0);
		return vertices;
	}
	private int[] GetTriangles()
	{
		int[] triangles = new int[3];
		triangles[0] = 2;
		triangles[1] = 1;
		triangles[2] = 0;
		return triangles;
	}
	private Vector3[] SetNormales()
	{
		Vector3[] normales = new Vector3[3];

			normales[0] = -Vector3.forward;
			normales[1] = -Vector3.forward;
			normales[2] = -Vector3.forward;


		return normales;
	}
	private Vector2[] SetUVs()
	{

		Vector2[] UVs = new Vector2[3];
			
			
			UVs[0] = new Vector2(1, 1);
			UVs[1] = new Vector2(1, 1);
			UVs[2] = new Vector2(1, 1);
		return UVs;
	}


}
