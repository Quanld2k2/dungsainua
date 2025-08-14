using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;
public class Hint : MonoBehaviour
{
    public LocalizeStringEvent localizeStringEvent;
    public static Hint ins;

    private void Awake()
    {
        Hint.ins = this;
    }
    public void ChangeDialogue(string key)
    {
        if (localizeStringEvent != null)
        {
            localizeStringEvent.StringReference.TableEntryReference = key;
            localizeStringEvent.RefreshString();
        }
        else
        {
            Debug.LogError("LocalizeStringEvent is not set.");
        }
    }


    // public LocalizationManager localizationManager;

    void Start()
    {
        // Thay đổi đoạn thoại theo ngôn ngữ đã chọn
        //  ChangeDialogue("DatComLenban");
    }

    public void OnChangeLanguage(int languageIndex)
    {
        // Thay đổi ngôn ngữ (0: English, 1: Vietnamese, ...)
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[languageIndex];
    }

    public void allLevel(int idd)
    {
        if (idd == 0)
        {
            Level1();
        }
        else if (idd == 1)
        {
            Level2();

        }
        else if (idd == 2)
        {
            Level3();

        }
        else if (idd == 3)
        {
            Level4();

        }
        else if (idd == 4)
        {
            Level5();

        }
        else if (idd == 5)
        {
            Level6();

        }
        else if (idd == 6)
        {
            Level7();
        }
        else if (idd == 7)
        {
            Level8();
        }
        else if (idd == 8)
        {
            Level9();
        }
        else if (idd == 9)
        {
            Level10();
        }
        else if (idd == 10)
        {
            Level11();
        }
        else if (idd == 11)
        {
            Level12();
        }
        else if (idd == 12)
        {
            Level13();
        }
        else if (idd == 13)
        {
            Level14();
        }
        else if (idd == 14)
        {
            Level15();
        }
        else if (idd == 15)
        {
            Level16();
        }
        else if (idd == 16)
        {
            Level17();
        }
        else if (idd == 17)
        {
            Level18();
        }
        else if (idd == 18)
        {
            Level19();
        }
        else if (idd == 19)
        {
            Level20();
        }
        else if (idd == 20)
        {
            Level21();
        }
        else if (idd == 21)
        {
            Level22();
        }
        else if (idd == 22)
        {
            Level23();
        }
        else if (idd == 23)
        {
            Level24();
        }
        else if (idd == 24)
        {
            Level25();
        }
        else if (idd == 25)
        {
            Level26();
        }
        else if (idd == 26)
        {
            Level27();

        }
        else if (idd == 27)
        {
            Level28();
        }
        else if (idd == 28)
        {
            Level29();
        }
        else if (idd == 29)
        {
            Level30();
        }
    }

    public void Level1()
    {

        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi1_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi1_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi1_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi1_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi1_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi1_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi1_7");

        }
        else if (GameManager.ins.hint8 == false)
        {
            ChangeDialogue("hi1_8");

        }
        else if (GameManager.ins.hint9 == false)
        {
            ChangeDialogue("hi1_9");

        }
        else if (GameManager.ins.hint10 == false)
        {
            ChangeDialogue("hi1_10");

        }
    }
    public void Level2()
    {

        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi2_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi2_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi2_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi2_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi2_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi2_6");

        }
    }
    public void Level3()
    {

        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi3_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi3_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi3_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi3_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi3_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi3_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi3_7");

        }
    }
    public void Level4()
    {

        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi4_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi4_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi4_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi4_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi4_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi4_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi4_7");

        }
        else if (GameManager.ins.hint8 == false)
        {
            ChangeDialogue("hi4_8");

        }
    }
    public void Level5()
    {

        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi5_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi5_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi5_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi5_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi5_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi5_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi5_7");

        }
        else if (GameManager.ins.hint8 == false)
        {
            ChangeDialogue("hi5_8");

        }
        else if (GameManager.ins.hint9 == false)
        {
            ChangeDialogue("hi5_9");

        }
        else if (GameManager.ins.hint10 == false)
        {
            ChangeDialogue("hi5_10");

        }
    }
    public void Level6()
    {

        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi6_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi6_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi6_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi6_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi6_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi6_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi6_7");

        }
        else if (GameManager.ins.hint8 == false)
        {
            ChangeDialogue("hi6_8");
        }
        else if(GameManager.ins.hint9 == false)
        {
            ChangeDialogue("hi6_9");
        }
        else if (GameManager.ins.hint10 == false)
        {
            ChangeDialogue("hi6_10");
        }
    }
    public void Level7()
    {

        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi7_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi7_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi7_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi7_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi7_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi7_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi7_7");

        }
        else if (GameManager.ins.hint8 == false)
        {
            ChangeDialogue("hi7_8");

        }
        else if (GameManager.ins.hint9 == false)
        {
            ChangeDialogue("hi7_9");

        }
        else if (GameManager.ins.hint10 == false)
        {
            ChangeDialogue("hi7_10");

        }
        else if (GameManager.ins.hint11 == false)
        {
            ChangeDialogue("hi7_11");

        }
        else if (GameManager.ins.hint12 == false)
        {
            ChangeDialogue("hi7_12");

        }
        else if (GameManager.ins.hint13 == false)
        {
            ChangeDialogue("hi7_13");

        }
    }
    public void Level8()
    {
        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi8_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi8_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi8_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi8_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi8_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi8_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi8_7");

        }
        else if (GameManager.ins.hint8 == false)
        {
            ChangeDialogue("hi8_8");

        }
        else if (GameManager.ins.hint9 == false)
        {
            ChangeDialogue("hi8_9");

        }
    }
    public void Level9()
    {

        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi9_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi9_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi9_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi9_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi9_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi9_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi9_7");

        }
    }
    public void Level10()
    {

        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi10_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi10_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi10_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi10_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi10_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi10_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi10_7");

        }
        else if (GameManager.ins.hint8 == false)
        {
            ChangeDialogue("hi10_8");

        }
    }
    public void Level11()
    {

        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi11_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi11_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi11_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi11_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi11_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi11_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi11_7");

        }
        else if (GameManager.ins.hint8 == false)
        {
            ChangeDialogue("hi11_8");

        }
        else if (GameManager.ins.hint9 == false)
        {
            ChangeDialogue("hi11_9");

        }
        else if (GameManager.ins.hint10 == false)
        {
            ChangeDialogue("hi11_10");

        }
        else if (GameManager.ins.hint11 == false)
        {
            ChangeDialogue("hi11_11");

        }
        else if (GameManager.ins.hint12 == false)
        {
            ChangeDialogue("hi11_12");

        }
    }
    public void Level12()
    {

        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi12_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi12_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi12_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi12_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi12_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi12_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi12_7");

        }
        else if (GameManager.ins.hint8 == false)
        {
            ChangeDialogue("hi12_8");

        }
        else if (GameManager.ins.hint9 == false)
        {
            ChangeDialogue("hi12_9");

        }
        else if (GameManager.ins.hint10 == false)
        {
            ChangeDialogue("hi12_10");

        }
        else if (GameManager.ins.hint11 == false)
        {
            ChangeDialogue("hi12_11");

        }
    }
    public void Level13()
    {

        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi13_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi13_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi13_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi13_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi13_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi13_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi13_7");

        }
        else if (GameManager.ins.hint8 == false)
        {
            ChangeDialogue("hi13_8");

        }
        else if (GameManager.ins.hint9 == false)
        {
            ChangeDialogue("hi13_9");

        }
        else if (GameManager.ins.hint10 == false)
        {
            ChangeDialogue("hi13_10");

        }
        else if (GameManager.ins.hint11 == false)
        {
            ChangeDialogue("hi13_11");

        }
        else if (GameManager.ins.hint12 == false)
        {
            ChangeDialogue("hi13_12");

        }
        else if (GameManager.ins.hint13== false)
        {
            ChangeDialogue("hi13_13");

        }
    }
    public void Level14()
    {

        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi14_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi14_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi14_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi14_4");

        }
        else if (GameManager.ins.hint5 == false)
        {
            ChangeDialogue("hi14_6");

        }
        else if (GameManager.ins.hint6 == false)
        {

            ChangeDialogue("hi14_5");

        }
        
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi14_7");

        }
        else if (GameManager.ins.hint8 == false)
        {
            ChangeDialogue("hi14_8");

        }
    }
    public void Level15()
    {

        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi15_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi15_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi15_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi15_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi15_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi15_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi15_7");

        }
        else if (GameManager.ins.hint8 == false)
        {
            ChangeDialogue("hi15_8");

        }
        else if (GameManager.ins.hint9 == false)
        {
            ChangeDialogue("hi15_9");

        }
        else if (GameManager.ins.hint10 == false)
        {
            ChangeDialogue("hi15_10");

        }
        else if (GameManager.ins.hint11 == false)
        {
            ChangeDialogue("hi15_11");

        }
    }
    public void Level16()
    {
        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi16_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi16_2");
        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi16_4");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi16_5");

        }
        else if (GameManager.ins.hint5 == false)
        {
            ChangeDialogue("hi16_6");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi16_7");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi16_8");

        }
    }
    public void Level17()
    {
        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi17_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi17_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi17_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi17_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi17_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi17_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi17_7");

        }
        else if (GameManager.ins.hint8 == false)
        {
            ChangeDialogue("hi17_8");

        }
        else if (GameManager.ins.hint9 == false)
        {
            ChangeDialogue("hi17_9");

        }
        else if (GameManager.ins.hint10 == false)
        {
            ChangeDialogue("hi17_10");

        }
        else if (GameManager.ins.hint11 == false)
        {
            ChangeDialogue("hi17_11");

        }
        else if (GameManager.ins.hint12 == false)
        {
            ChangeDialogue("hi17_12");

        }
        else if (GameManager.ins.hint13 == false)
        {
            ChangeDialogue("hi17_13");

        }
    }
    public void Level18()
    {
        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi18_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi18_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi18_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi18_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi18_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi18_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi18_7");

        }
        else if (GameManager.ins.hint8 == false)
        {
            ChangeDialogue("hi18_8");

        }
        else if (GameManager.ins.hint9 == false)
        {
            ChangeDialogue("hi18_9");

        }
    }
    public void Level19()
    {
        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi19_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi19_2");
        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi19_3");
        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi19_4");
        }
        else if (GameManager.ins.hint5 == false)
        {
            ChangeDialogue("hi19_9");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi19_6");
        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi19_7");
        }
        else if (GameManager.ins.hint8 == false)
        {
            ChangeDialogue("hi19_8");
        }
        else if (GameManager.ins.hint9 == false)
        {
            ChangeDialogue("hi19_5");

        }
        else if (GameManager.ins.hint10 == false)
        {
            ChangeDialogue("hi19_10");
        }
        else if (GameManager.ins.hint11 == false)
        {
            ChangeDialogue("hi19_11");
        }
        else if (GameManager.ins.hint12 == false)
        {
            ChangeDialogue("hi19_12");
        }
    }
    public void Level20()
    {
        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi20_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi20_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi20_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi20_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi20_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi20_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi20_7");

        }
        else if (GameManager.ins.hint8 == false)
        {
            ChangeDialogue("hi20_8");

        }
    }
    public void Level21()
    {
        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi21_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi21_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi21_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi21_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi21_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi21_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi21_7");

        }
        else if (GameManager.ins.hint8 == false)
        {
            ChangeDialogue("hi21_8");

        }
    }
    public void Level22()
    {
        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi22_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi22_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi22_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi22_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi22_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi22_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi22_7");

        }
    }
    public void Level23()
    {
        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi23_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi23_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi23_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi23_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi23_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi23_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi23_7");

        }
    }
    public void Level24()
    {
        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi24_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi24_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi24_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi24_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi24_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi24_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi24_7");

        }
        else if (GameManager.ins.hint8 == false)
        {
            ChangeDialogue("hi24_8");

        }
        else if (GameManager.ins.hint9 == false)
        {
            ChangeDialogue("hi24_9");

        }
    }
    public void Level25()
    {
        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi25_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi25_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi25_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi25_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi25_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi25_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi25_7");

        }
        else if (GameManager.ins.hint8 == false)
        {
            ChangeDialogue("hi25_8");

        }
        else if (GameManager.ins.hint9 == false)
        {
            ChangeDialogue("hi25_9");

        }
        else if (GameManager.ins.hint10 == false)
        {
            ChangeDialogue("hi25_10");

        }
        else if (GameManager.ins.hint11 == false)
        {
            ChangeDialogue("hi25_11");

        }
        else if (GameManager.ins.hint12 == false)
        {
            ChangeDialogue("hi25_12");

        }
        else if (GameManager.ins.hint13 == false)
        {
            ChangeDialogue("hi25_13");

        }
        else if (GameManager.ins.hint14 == false)
        {
            ChangeDialogue("hi25_14");

        }
        else if (GameManager.ins.hint15 == false)
        {
            ChangeDialogue("hi25_15");

        }
        else if (GameManager.ins.hint16 == false)
        {
            ChangeDialogue("hi25_16");

        }

    }
    public void Level26()
    {
        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi26_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi26_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi26_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi26_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi26_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi26_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi26_7");

        }
    }
    public void Level27()
    {
        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi27_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi27_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi27_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi27_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi27_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi27_6");

        }
    }
    public void Level28()
    {
        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi28_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi28_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi28_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi28_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi28_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi28_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi28_7");

        }
        else if (GameManager.ins.hint8 == false)
        {
            ChangeDialogue("hi28_8");

        }
        else if (GameManager.ins.hint9 == false)
        {
            ChangeDialogue("hi28_9");

        }
        else if (GameManager.ins.hint10 == false)
        {
            ChangeDialogue("hi28_10");

        }
    }
    public void Level29()
    {
        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi29_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi29_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi29_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi29_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi29_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi29_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi29_7");

        }
        else if (GameManager.ins.hint8 == false)
        {
            ChangeDialogue("hi29_8");

        }
        else if (GameManager.ins.hint9 == false)
        {
            ChangeDialogue("hi29_9");

        }
    }
    public void Level30()
    {
        if (GameManager.ins.hint1 == false)
        {
            ChangeDialogue("hi30_1");
        }
        else if (GameManager.ins.hint2 == false)
        {
            ChangeDialogue("hi30_2");

        }
        else if (GameManager.ins.hint3 == false)
        {
            ChangeDialogue("hi30_3");

        }
        else if (GameManager.ins.hint4 == false)
        {
            ChangeDialogue("hi30_4");

        }
        else if (GameManager.ins.hint5 == false)
        {

            ChangeDialogue("hi30_5");

        }
        else if (GameManager.ins.hint6 == false)
        {
            ChangeDialogue("hi30_6");

        }
        else if (GameManager.ins.hint7 == false)
        {
            ChangeDialogue("hi30_7");

        }
        else if (GameManager.ins.hint8 == false)
        {
            ChangeDialogue("hi30_8");

        }
        else if (GameManager.ins.hint9 == false)
        {
            ChangeDialogue("hi30_9");

        }
        else if (GameManager.ins.hint10 == false)
        {
            ChangeDialogue("hi30_10");

        }
        else if (GameManager.ins.hint11 == false)
        {
            ChangeDialogue("hi30_11");

        }
        else if (GameManager.ins.hint12 == false)
        {
            ChangeDialogue("hi30_12");

        }
        else if (GameManager.ins.hint13 == false)
        {
            ChangeDialogue("hi30_13");

        }
        else if (GameManager.ins.hint14 == false)
        {
            ChangeDialogue("hi30_14");

        }
    }
}
