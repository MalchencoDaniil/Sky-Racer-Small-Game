using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Language
{
    English,
    Russian
}

public class LanguageControl : MonoBehaviour
{
    public static LanguageControl _instance;

    [HideInInspector] public LanguageControl _languageControl;

    [SerializeField] internal Language _language;
    [SerializeField] private Dropdown _dropdown;

    private void Awake()
    {
        _instance = this;

        _language = (Language)PlayerPrefs.GetInt("LanguageID");

        if (_dropdown != null)
        {
            string[] _languages = Enum.GetNames(typeof(Language));

            List<string> _names = new List<string>(_languages);

            _dropdown.AddOptions(_names);
            _dropdown.value = PlayerPrefs.GetInt("LanguageID");
            _dropdown.RefreshShownValue();
        }
    }

    public void SetLanguage(int langID)
    {
        _language = (Language)langID;
        PlayerPrefs.SetInt("LanguageID", langID);
    }
}