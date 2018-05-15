using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraSize : MonoBehaviour {


	public static float SizeY()
	{
		return Camera.main.orthographicSize * 2;
	}
	public static float SizeX()
	{
		return SizeY () * Screen.width / Screen.height;
	}
	public static float HBoundX()
	{
		return Camera.main.transform.position.x + SizeX () / 2;
	}
	public static float LBoundX()
	{
		return Camera.main.transform.position.x - SizeX () / 2;
		 
	}
	public static float HBoundY()
	{
		return Camera.main.transform.position.y + SizeY () / 2;

	}
	public static float LBoundY()
	{
		return Camera.main.transform.position.y - SizeY () / 2;
	}



}
