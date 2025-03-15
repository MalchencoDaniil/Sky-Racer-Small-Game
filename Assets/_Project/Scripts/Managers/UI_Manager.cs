using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText, _recordText;

    private void Start()
    {
        _recordText.text = PlayerPrefs.GetInt("Record").ToString();
    }

    private void Update()
    {
        _scoreText.text = GameManager._instance._score.ToString();
    }
}