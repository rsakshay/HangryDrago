using UnityEngine;

public static class InputMan
{
    private const string LHorizontal = "LHorizontal";

    public static bool GetButtonDown(string key)
    {
        return Input.GetButtonDown(key);
    }

    public static bool GetButtonUp(string key)
    {
        return Input.GetButtonUp(key);
    }

    public static float GetLHorizontal()
    {
        return Input.GetAxis(LHorizontal);
    }

}
