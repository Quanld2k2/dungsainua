using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    public static void Vibrate()
    {
#if UNITY_ANDROID || UNITY_IOS
        Handheld.Vibrate();
#endif
    }
}