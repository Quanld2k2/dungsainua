using UnityEngine;

public class PurchareIAP : MonoBehaviour
{
    void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        try
        {
            using (var versionInfo = new AndroidJavaClass("com.android.billingclient.api.BillingClient"))
            {
                string version = versionInfo.GetStatic<string>("LIBRARY_VERSION");
                Debug.Log("[Billing] Play Billing Library version: " + version);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("[Billing] Cannot find BillingClient: " + e.Message);
        }
#else
        Debug.Log("[Billing] Only works on real Android device.");
#endif
    }
}