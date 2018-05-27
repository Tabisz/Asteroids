using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraSize : MonoBehaviour {
    public enum Bounderies {TOP,BOTTOM,LEFT,RIGHT };
    public static float HBoundX;
    public static float HBoundY;
    public static float LBoundX;
    public static float LBoundY;
    public static float SizeY;
    public static float SizeX;

    private void Awake()
    {
        HBoundX = GetHBoundX();
        HBoundY = GetHBoundY();
        LBoundX = GetLBoundX();
        LBoundY = GetLBoundY();
        SizeX = GetSizeX();
        SizeY = GetSizeY();
}

    public static float GetSizeY()
    {
        return Camera.main.orthographicSize * 2;
    }

    public static float GetSizeX()
    {
        return GetSizeY() * Screen.width / Screen.height;
    }

    private float GetHBoundX()
    {
        return Camera.main.transform.position.x + GetSizeX() / 2;
    }

    private float GetLBoundX()
    {
        return Camera.main.transform.position.x - GetSizeX() / 2;
    }

    private float GetHBoundY()
    {
        return Camera.main.transform.position.y + GetSizeY() / 2;
    }

    private float GetLBoundY()
    {
        return Camera.main.transform.position.y - GetSizeY() / 2;
    }

    public static Vector3 CheckIfOnScreenWithTransfer(float offset,Vector3 pos)
    {

                if (pos.x > HBoundX + offset)
            return new Vector3(LBoundX - offset, pos.y, pos.z);

        if (pos.x < LBoundX - offset)
            return new Vector3(HBoundX + offset, pos.y, pos.z);

        if (pos.y > HBoundY + offset)
            return new Vector3(pos.x, LBoundY - offset, pos.z);

        if (pos.y < LBoundY - offset)
                    return new Vector3(pos.x,HBoundY + offset, pos.z);

        return pos;
    }
    public static bool CheckIfOnScreen(float offset, Vector3 pos)
    {

        if (pos.x > HBoundX + offset)
            return false;

        if (pos.x < LBoundX - offset)
            return false;

        if (pos.y > HBoundY + offset)
            return false;

        if (pos.y < LBoundY - offset)
            return false;

        return true;
    }


}
