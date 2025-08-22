using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spine.Unity;
using Spine;
using System.Collections;

public class Setting : MonoBehaviour
{
    public static Setting ins;
    public GameObject board, black, f1, f2, f3, board2;
    public SkeletonGraphic a_setting1;
    public Image btCan, btCon, btHome, btsound, btmusic, btok,st2,black2;
    public Text Set;

    public Sprite on, off;
    private void Awake()
    {
        Setting.ins = this;
    }
    private void Start()
    {
        a_setting1.AnimationState.Complete += OnAnimationComplete1;

        int sound = PlayerPrefs.GetInt("sound");
        Debug.Log("soundsound" + sound);
        if (sound == 1)
        {
            btsound.sprite = off;
            AudioManager.ins.playMusic1.mute = true;
            AudioManager.ins.playMusic2.mute = true;
            AudioManager.ins.playMusic3.mute = true;
            AudioManager.ins.playMusicGame.mute = true;
            AudioManager.ins.Click.mute = true;
            AudioManager.ins.SFXSource.mute = true;
           

        }
        else
        {
            btsound.sprite = on;
            AudioManager.ins.playMusic1.mute = false;
            AudioManager.ins.playMusic2.mute = false;
            AudioManager.ins.playMusic3.mute = false;
            AudioManager.ins.playMusicGame.mute = false;
            AudioManager.ins.Click.mute = false;
            AudioManager.ins.SFXSource.mute = false;


        }



        int music = PlayerPrefs.GetInt("music");

        if (music == 1)
        {
            AudioManager.ins.stMusic();
            btmusic.sprite = off;
        }
        else
        {
            AudioManager.ins.plMusic();
            btmusic.sprite = on;
        }
        AudioManager.ins.musicSource.mute = true;

    }
    private void OnAnimationComplete1(TrackEntry trackEntry)
    {
        if (trackEntry.Animation != null)
        {
            if (trackEntry.Animation.Name == "Open")
            {
                if (GameManager.ins.Home == false)
                {
                    btCan.gameObject.SetActive(true);
                    btCan.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    btCan.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack);
                }
                else if (GameManager.ins.Home == true)
                {
                    btCon.gameObject.SetActive(true);
                    btCon.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    btCon.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack);

                    btHome.gameObject.SetActive(true);
                    btHome.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    btHome.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack);
                }
              
              //  Time.timeScale = 0f;
            }
        }
    }

    public void OpenSetting()
    {
     

        black.gameObject.SetActive(true);
        board.SetActive(false);
        board2.SetActive(false);

        btCan.gameObject.SetActive(false);
        btCon.gameObject.SetActive(false);
        btHome.gameObject.SetActive(false);


        Set.gameObject.SetActive(true);
        Set.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        Set.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            board.SetActive(true);

            f1.gameObject.SetActive(true);
            f1.transform.localScale = new Vector3(0.5f, 1f, 1f);
            f1.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);

            f2.gameObject.SetActive(true);
            f2.transform.localScale = new Vector3(0.5f, 1f, 1f);
            f2.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);

            f3.gameObject.SetActive(true);
            f3.transform.localScale = new Vector3(0.5f, 1f, 1f);
            f3.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);

            //  DOVirtual.DelayedCall(0.1f, () =>
            //  {
            // });
        });

        a_setting1.gameObject.SetActive(true);
        a_setting1.AnimationState.ClearTrack(1);
        a_setting1.AnimationState.SetAnimation(1, "Open", false);
    }

    public void SLanguague_open()
    {
        board2.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 0f, 0f);

        board2.gameObject.SetActive(true);
        btok.gameObject.SetActive(false);

        st2.gameObject.SetActive(true);

        st2.transform.localScale = new Vector3(0f, 0f, 0f);
        st2.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            btok.gameObject.SetActive(true);
            btok.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            btok.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack);
        });
        GameManager.ins.Language = true;
    }
    public void SLanguague_close()
    {
        Debug.Log(LocalSelector.ins.ids);
        //int codeLanguage = PlayerPrefs.GetInt("GameLanguageID");
        LocalSelector.ins.SetLocal2(LocalSelector.ins.ids);
        //StartCoroutine(load());
        board2.GetComponent<RectTransform>().anchoredPosition = new Vector3(1000f, 10000f, 100f);
    }
    IEnumerator load()
    {
        yield return new WaitForSeconds(0.1f);
        board2.SetActive(false);

    }

    // adudio
    public void sound()
    {
        int sound = PlayerPrefs.GetInt("sound");
        Debug.Log("soundsound" + sound);

        if (sound == 1)
        {
            Debug.Log("off");
            AudioManager.ins.SFXSource.mute = false;
            AudioManager.ins.Click.mute = false;


            AudioManager.ins.playMusic1.mute = false;
            AudioManager.ins.playMusic2.mute = false;
            AudioManager.ins.playMusic3.mute = false;
            AudioManager.ins.playMusicGame.mute = false;

            //  AudioManager.ins.playMusicGame.mute = true;

            btsound.sprite = on;
            PlayerPrefs.SetInt("sound", 0);
            PlayerPrefs.Save();
         //   AudioListener.volume = 0f; // Âm thanh bật

        }
        else
        {
            Debug.Log("on");
            AudioManager.ins.SFXSource.mute = true;
            AudioManager.ins.Click.mute = true;

            AudioManager.ins.playMusic1.mute = true;
            AudioManager.ins.playMusic2.mute = true;
            AudioManager.ins.playMusic3.mute = true;
            
                 AudioManager.ins.playMusicGame.mute = true;
            btsound.sprite = off;
            PlayerPrefs.SetInt("sound", 1);
            PlayerPrefs.Save();
            //   AudioListener.volume = 1f; // Âm thanh bật
          //  GetComponent<Button>().onClick.AddListener(() =>
          //  {
           //     VibrationManager.Vibrate();
           // });
        }
    }
    public void music()
    {
        if (GameManager.ins.sod == false)
        {
            int music = PlayerPrefs.GetInt("music");

            if (music == 0)
            {
                AudioManager.ins.musicSource.mute = true;

                Debug.Log("off");
                AudioManager.ins.stMusic();
                //AudioManager.ins.musicSource.mute = false;

                btmusic.sprite = off;
                PlayerPrefs.SetInt("music", 1);
                PlayerPrefs.Save();
                GetComponent<Button>().onClick.AddListener(() =>
                {
                    VibrationManager.Vibrate();
                });
            }
            else
            {
                Debug.Log("on");
                AudioManager.ins.musicSource.mute = false;

                //AudioManager.ins.musicSource.mute = true;
                AudioManager.ins.plMusic();

                btmusic.sprite = on;
                PlayerPrefs.SetInt("music", 0);
                PlayerPrefs.Save();
            }
        }
        
    }


}
