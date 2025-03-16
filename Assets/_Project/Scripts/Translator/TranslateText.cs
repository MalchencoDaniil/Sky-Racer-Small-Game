using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable] 
public class CurrentLangText
{
    public string currentText;
    public Language language;
}

public class TranslateText : MonoBehaviour
{
    private Language language;

    [SerializeField] private Text currentText;
    [SerializeField] private List<CurrentLangText> currentLangTexts = new List<CurrentLangText>();

    private void Start()
    {
        NewLanguage();
    }

    private void Update()
    {
        if (language != LanguageControl._instance._language)
        {
            NewLanguage();
            Debug.Log("Yes");
        }
    }

    public void NewLanguage()
    {
        language = LanguageControl._instance._language;

        for (int i = 0; i < currentLangTexts.Count; i++)
        {
            if (language == currentLangTexts[i].language)
            {
                currentText.text = currentLangTexts[i].currentText.ToString();
            }
        }
    }
}