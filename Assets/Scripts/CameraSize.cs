using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraSize : MonoBehaviour {
    public enum Bounderies {TOP,BOTTOM,LEFT,RIGHT };
    public static float HBoundX;
    public static float HBoundY;
    public static float LBoundX;
    public static float LBoundY;

    private void Awake()
    {
         HBoundX = GetHBoundX();
         HBoundY = GetHBoundY();
         LBoundX = GetLBoundX();
         LBoundY = GetLBoundY();
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

    public static bool CheckIfOnScreen(Bounderies bd, float offset,Vector3 pos)
    {
        switch(bd)
        {
            case Bounderies.RIGHT:
                if (pos.x > HBoundX + offset)
                    return true;
                    break;
            case Bounderies.LEFT:
                if (pos.x < LBoundX - offset)
                    return true;
                    break;
            case Bounderies.TOP:
                if (pos.y > HBoundY + offset)
                    return true;
                    break;
            case Bounderies.BOTTOM:
                if (pos.y < LBoundY - offset)
                    return true;
                    break;
        }
        return false;
    }
}
