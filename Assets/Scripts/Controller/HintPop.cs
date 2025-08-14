using UnityEngine;

public class HintPop : MonoBehaviour
{
    public void bt_HintAndReward()
    {
        int hiNum = PlayerPrefs.GetInt("hiGame");

        int coins2 = PlayerPrefs.GetInt("txt_gold");
        if (coins2 >= 100)
        {
            hiNum += 1;
            coins2 -= 100;
            PlayerPrefs.SetInt("hiGame", hiNum);
            PlayerPrefs.SetInt("txt_gold", coins2);
            Debug.Log("doen");
            time.ins.startHi();

        }
        else
        {
            Debug.Log("faild");

        }

      ///  txthint.text = "" + hiNum;
    }
}
