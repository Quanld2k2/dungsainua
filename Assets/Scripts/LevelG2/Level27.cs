using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spine.Unity;
using Spine;
using System.Collections;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Components;
using RotateMode = DG.Tweening.RotateMode; // Xác định rõ `RotateMode` là của DOTween
using Sequence = DG.Tweening.Sequence; // Alias cho Sequence của DOTween

public class Level27 : MonoBehaviour
{
    public static Level27 ins;

    public Image bg1, bg2, bt1, bt2, bt3;
    public Image coffin1, coffin2, lid1, lid2, bg3;
    public Image[] wwho;
    public Image v1_1, v1_2, v1_3, v2_1, v2_2, v2_3;
    public Image garlic, cross, stethoscope, flower, tablet1, tablet, heart1,heart2, z1_1, z1_2,z2_1,z2_2;
    public GameObject a1, a2;

    private void Awake()
    {
        Level27.ins = this;
    }
    private void Start()
    {
        startLevel();
    }
    public void startLevel()
    {
        bg1.gameObject.SetActive(true);
        bg2.gameObject.SetActive(true);
        coffin1.gameObject.SetActive(true);
        coffin2.gameObject.SetActive(true);
        lid1.gameObject.SetActive(true);
        lid2.gameObject.SetActive(true);
        bg3.gameObject.SetActive(true);
        a1.SetActive(true);
        a2.SetActive(true);
        v1_1.gameObject.SetActive(true);
        v1_2.gameObject.SetActive(false);
        v1_3.gameObject.SetActive(false);
        v2_1.gameObject.SetActive(true);
        v2_2.gameObject.SetActive(false);
        v2_3.gameObject.SetActive(false);
        garlic.gameObject.SetActive(true);
        cross.gameObject.SetActive(true);
        stethoscope.gameObject.SetActive(true);
        flower.gameObject.SetActive(true);
        tablet.gameObject.SetActive(false);
        tablet1.gameObject.SetActive(true);
        heart1.gameObject.SetActive(false);
        heart2.gameObject.SetActive(false);

        z1_1.gameObject.SetActive(false);
        z1_2.gameObject.SetActive(false);
        z2_1.gameObject.SetActive(false);
        z2_2.gameObject.SetActive(false);

        bt1.gameObject.SetActive(false);
        bt2.gameObject.SetActive(false);
        bt3.gameObject.SetActive(false);

        l21a1 = false;
        l21a2 = false;
        number1 = 0;
        for (int i = 0; i < wwho.Length; i++)
        {
            wwho[i].gameObject.SetActive(false);
        }
        AudioManager.ins.playmusicgame(AudioManager.ins.level27[2]);

        // int result = RandomOneOrTwo();
        //  Debug.Log("Random result: " + result); // In ra 1 hoặc 2
    }
    public int number1 = 0;
    public int RandomOneOrTwo()
    {
        return Random.Range(1, 3);
    }
    public void ressetGame()
    {
        l21a1 = false;
        l21a2 = false;
      
        v1_1.gameObject.SetActive(true);
        v1_2.gameObject.SetActive(false);
        v1_3.gameObject.SetActive(false);
        v2_1.gameObject.SetActive(true);
        v2_2.gameObject.SetActive(false); z1_1.gameObject.SetActive(false);
        z1_2.gameObject.SetActive(false);
        z2_1.gameObject.SetActive(false);
        z2_2.gameObject.SetActive(false);
        v2_3.gameObject.SetActive(false);
        heart1.gameObject.SetActive(false);
        heart2.gameObject.SetActive(false);
        a1.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-270f, -80f, 0f), 0.7f)
            .SetDelay(0.5f).OnComplete(() =>
            {

            });
        a2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(270f, -80f, 0f), 0.7f)
           .SetDelay(0.5f).OnComplete(() =>
           {

           });
    }
    public void selectTrue()
    {
        bt1.gameObject.SetActive(false);
        bt2.gameObject.SetActive(false);
        bt3.gameObject.SetActive(false);

        lid1.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-650f, -80f, 0f);
        lid2.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(650f, -80f, 0f);

        a1.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(-1000f, -80f, 0f), 0.8f)
            .SetDelay(0.4f).OnComplete(() =>
            {
                
            });
        a2.gameObject.GetComponent<RectTransform>().DOAnchorPos(new Vector3(1000f, -80f, 0f), 0.8f)
           .SetDelay(0.4f).OnComplete(() =>
           {
               wwho[number1].gameObject.SetActive(true);
                number1 += 1;
               if (number1 == 6)
               {
                   textCoroutine2 = StartCoroutine(ENDGAME());
               }
               else
               {
                   ressetGame();

               }
           });
        
    }
    public IEnumerator v2_1s()
    {
        Debug.Log(Level27.ins.l21a1);
        Debug.Log(Level27.ins.l21a2);

        yield return new WaitForSeconds(1f);
        AudioManager.ins.play1shot(AudioManager.ins.level27[3]);

        bt3.gameObject.SetActive(true);
        bt1.gameObject.SetActive(true);
        bt2.gameObject.SetActive(true);

    }

    public void checkma1()
    {
        if (l21a1 == true)
        {
            selectTrue();
        }
        else
        {
            textCoroutine2 = StartCoroutine(ENDOVER());
        }
    }
    public void checkma2()
    {
        if (l21a2 == true)
        {
            selectTrue();
        }
        else
        {
            textCoroutine2 = StartCoroutine(ENDOVER());
        }
    }
    public Text numberText1, numberText2; // Nếu dùng TextMeshPro

    public void UpdateNumber(int num)
    {
        if (l21a1 == true)
        {
            numberText1.text = num.ToString();
        }
        else
        {
            numberText2.text = num.ToString();
        }

    }
    public IEnumerator CountNumber()
    {
        int num = 1;

        // Tăng nhanh từ 1 → 10
        while (num <= 134)
        {
            UpdateNumber(num++);
            yield return new WaitForSeconds(0.01f);
        }

        // Tăng chậm dần đến 140
        float delay = 0.001f;
        while (num <= 140)
        {
            UpdateNumber(num++);
            yield return new WaitForSeconds(delay);
            delay += 0.003f;
        }

        // Lùi về 135
        for (int i = 139; i >= 135; i--)
        {
            UpdateNumber(i);
            yield return new WaitForSeconds(0.001f);
        }
    }
    public bool l21a1 = false, l21a2 = false;

    public void PauseAnimation()
    {
        // GameManager.ins.Pause = true;
        //  a_boy.timeScale = 0;
        //  a_girl.timeScale = 0;
    }

    public void ResumeAnimation()
    {
        // GameManager.ins.Pause = true;
        //   a_boy.timeScale = 1;
        //   a_girl.timeScale = 1;
    }

    public void OnAnimationComplete3(TrackEntry trackEntry)
    {
        //    Level5.ins.a_perfume.gameObject.SetActive(false);


    }

    public int gameover = 0;
    private Coroutine textCoroutine2; // Lưu trữ coroutine đang chạy
    public void endGame()
    {

        Debug.Log("endgame");
        if (gameover == 10)
        {
            textCoroutine2 = StartCoroutine(ENDGAME());
            Debug.Log("gameover");
        }
        else if (gameover == 100)
        {
            textCoroutine2 = StartCoroutine(ENDOVER());
            Debug.Log("gameover");
        }

    }
    public bool head = false;
    public IEnumerator ENDGAME()
    {
        yield return new WaitForSeconds(1f);
        UiController.ins.WinGame();
    }
    public IEnumerator ENDOVER()
    {
        yield return new WaitForSeconds(1f);
        UiController.ins.OpenLose();
    }
}
