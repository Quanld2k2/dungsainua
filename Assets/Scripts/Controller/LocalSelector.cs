using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using System.Globalization;
using Spine.Unity;
using Spine;



public class LocalSelector : MonoBehaviour
{
    public static LocalSelector ins;

    private const string LanguageKey = "GameLanguage";  // Key lưu ngôn ngữ trong PlayerPrefs
    private const string CodeKey = "GameLanguageID";  // Key lưu ngôn ngữ trong PlayerPrefs

    private void Awake()
    {
        LocalSelector.ins = this;
        //PlayerPrefs.DeleteAll();

    }
    void Start()
    {
        if (!PlayerPrefs.HasKey(LanguageKey))
        {
            UpdateLanguage();  // Nếu chưa có ngôn ngữ lưu, lấy theo hệ thống
        }
        else
        {
            string savedLanguage = PlayerPrefs.GetString(LanguageKey);
           SetLanguage(savedLanguage);

            int codeLanguage = PlayerPrefs.GetInt(CodeKey);
            Debug.Log("aaaaaa" + codeLanguage);
            selection(codeLanguage);
        }
    }

    public void UpdateLanguage()
    {
        string languageCode = "en"; // Mặc định tiếng Anh
        int abc = 1;
        try
        {
            RegionInfo regionInfo = RegionInfo.CurrentRegion;
            string countryCode = regionInfo.TwoLetterISORegionName;

            switch (countryCode)
            {
                case "KR": // Hàn Quốc
                    languageCode = "ko"; abc = 3; break;
                case "VN": // Việt Nam
                    languageCode = "vi"; abc = 6; break;
                case "JP": // Nhật Bản
                    languageCode = "ja"; abc = 2; break;
                case "CN":
                case "TW":
                case "HK": // Trung Quốc (bao gồm Đài Loan & Hồng Kông)
                    languageCode = "zh"; abc = 0; break;
                case "PT": // Bồ Đào Nha (bao gồm Brazil)
                    languageCode = "pt"; abc = 4; break;
                case "ES": // Tây Ban Nha
                    languageCode = "es"; abc = 5; break;
                case "SA":
                case "EG":
                case "AE": // Ả Rập (Saudi, UAE, Ai Cập)
                    languageCode = "ar"; 
                    abc = 1     ; break;
                default:
                    languageCode = "en"; // Mặc định là tiếng Anh
                    abc = 1;
                    break;
            }
        }
        catch
        {
            Debug.LogWarning("Không thể lấy thông tin khu vực, sử dụng tiếng Anh mặc định.");
        }

        // Lưu lại ngôn ngữ vào PlayerPrefs
        PlayerPrefs.SetString(LanguageKey, languageCode);
        PlayerPrefs.Save();

        PlayerPrefs.SetInt(CodeKey, abc);
        PlayerPrefs.Save();
        selection(abc);

        // Cập nhật ngôn ngữ trong game
        SetLanguage(languageCode);
    }

    public void SetLanguage(string langCode)
    {
        Debug.Log("Cập nhật ngôn ngữ: " + langCode);
        // Ở đây bạn có thể gọi hệ thống localization của game
        // Ví dụ:
        int codeLanguage = PlayerPrefs.GetInt(CodeKey);
        ChangeLocale(codeLanguage);
      // LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale(langCode);

    }

    public void ChangeLanguageManually(string langCode)
    {
        if (IsValidLanguage(langCode))
        {
            PlayerPrefs.SetString(LanguageKey, langCode);
            PlayerPrefs.Save();
            SetLanguage(langCode);
        }
        else
        {
            int codeLanguage = PlayerPrefs.GetInt(CodeKey);
            selection(codeLanguage);
            Debug.LogWarning("Ngôn ngữ không hợp lệ: " + langCode);
        }
    }

    private bool IsValidLanguage(string langCode)
    {
        string[] supportedLanguages = { "en", "ko", "vi", "ja", "zh", "pt", "es", "ar" };
        return System.Array.Exists(supportedLanguages, lang => lang == langCode);
    }

    ////////////////////////////////////////////////////////////////////////////////////

    [SerializeField] public  Image[] _selcet;
    public int ids = 0;
    public void selection(int id)
    {
        Debug.Log("selectionselectionselection");
        for (int i = 0;i < _selcet.Length; i++)
        {
            if (i == id)
            {
                _selcet[i].gameObject.SetActive(true);
                ids = i;
            }
            else
            {
                _selcet[i].gameObject.SetActive(false);

            }

        }
    }

    ////
    /// 
    private bool active = false;

    public void ChangeLocale(int localeID)
    {
        if (active) return;


        if (LocalizationSettings.InitializationOperation.IsDone)
        {
            // Nếu đã khởi tạo, đổi ngay lập tức
            ApplyLocale(localeID);
        }
        else
        {
            // Nếu chưa khởi tạo, chờ xong rồi đổi
            StartCoroutine(SetLocale(localeID));
        }
    }

    private void ApplyLocale(int _localeID)
    {

        var a = _localeID + 1;
        if (a > 6)
        {
            //_localeID -= 1;
        }
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[a];
        //_localeID ;
        PlayerPrefs.SetInt(CodeKey, _localeID);
        PlayerPrefs.Save();
    }

    IEnumerator SetLocale(int _localeID)
    {
        _localeID += 1;
           active = true;
        yield return LocalizationSettings.InitializationOperation;
        ApplyLocale(_localeID);
        active = false;
    }

    public void SetLocal2(int _localeID)
    {
        _localeID += 1;

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        _localeID -= 1;
        PlayerPrefs.SetInt(CodeKey, _localeID);
        PlayerPrefs.Save();
    }

}
