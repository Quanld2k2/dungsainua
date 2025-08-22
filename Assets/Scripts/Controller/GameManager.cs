using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    private void Awake()
    {
        GameManager.ins = this;

        OpAds1 = true;
        openAd12333 = false;
        OP1 = false; 
        OP3 = false;
        OP2 = false; iapiter = false;

        N1ADS = false; N2ADS = false;
        navi1 = false; navi2 = false; sod = false; alang = false; subs = false;
    }
    public bool subs = false;

    public bool alang = false;
    public bool N1ADS = false, N2ADS = false;
    public bool navi1 = false, navi2 = false;
    public bool sod = false;



    public bool OP1 = false;
    public bool OP2 = false;
    public bool OP3 = false;
    public bool OpAds1 = false;
    public bool openAd12333 = false;
    public bool iapiter = false;


    [Header("------------- Home------------")]

    public bool SHome = false;
    public bool SPlay = false;
    public bool Home = false;
    public bool Language = false;
    public bool Lose = false;
    public bool LockLv = false;
    public bool RSET = false;
    public bool Pause = false;
    public int Click1 = 0;
    public int Click2 = 0;
    public int Click3 = 0;
    public int Click4 = 0;
    public int Click5 = 0;
    public int Click6 = 0;
    public int numberAds = 0;
    public bool adslock = false;

    public bool hint1 = false;
    public bool hint2 = false;
    public bool hint3 = false;
    public bool hint4 = false;
    public bool hint5 = false;
    public bool hint6 = false;
    public bool hint7 = false;
    public bool hint8 = false;
    public bool hint9 = false;
    public bool hint10 = false;
    public bool hint11 = false;
    public bool hint12 = false;
    public bool hint13 = false;
    public bool hint14 = false;
    public bool hint15 = false;
    public bool hint16 = false;
    public bool hint17 = false;
    public bool hint18 = false;
    public bool hint19 = false;
    public bool hint20 = false;


    private void Start()
    {
        SHome = false;
        SPlay = false;
        Home = false;
        Language = false;
        Lose = false;
        LockLv = false;
        RSET = false;
        Pause = false;
        numberAds = 0;
        HintActive();
        adslock = false;
    }

    public void startGameOB()
    {

    }


    public void HintActive()
    {
        Click1 = 0;
        Click2 = 0;
        Click3 = 0;
        Click4 = 0;
        Click5 = 0;
        Click6 = 0;
        hint1 = false;
        hint2 = false;
        hint3 = false;
        hint4 = false;
        hint5 = false;
        hint6 = false;
        hint7 = false;
        hint8 = false;
        hint9 = false;
        hint10 = false;
        hint11 = false;
        hint12 = false;
        hint13 = false;
        hint14 = false;
        hint15 = false;
        hint16 = false;
        hint17 = false;
        hint18 = false;
        hint19 = false;
        hint20 = false;

    }

}
