using UnityEngine;

public static class InputMan
{
    private const string LHorizontal = "LHorizontal";
    private static bool allowControls = true;

    public static bool GetButtonDown(string key)
    {
        if (!allowControls)
            return false;

        return Input.GetButtonDown(key);
    }

    public static bool GetButtonUp(string key)
    {
        if (!allowControls)
            return false;

        return Input.GetButtonUp(key);
    }

    public static float GetLHorizontal()
    {
        if (!allowControls)
            return 0;

        return Input.GetAxis(LHorizontal);
    }

    public static void DisableControls()
    {
        allowControls = false;
    }

    public static void EnableControls()
    {
        allowControls = true;
    }
}
