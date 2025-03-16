using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText, _recordText;

    [SerializeField]
    private GameObject _lossPanel;

    [SerializeField]
    private Text _finalScoreText;

    [SerializeField]
    private GameObject _gamePanel;

    private void Start()
    {
        _recordText.text = PlayerPrefs.GetInt("Record").ToString();
    }

    private void Update()
    {
        _scoreText.text = GameManager._instance._score.ToString();
    }

    public IEnumerator OpenLossPanel()
    {
        _gamePanel.SetActive(false);

        yield return new WaitForSeconds(2);

        _lossPanel.SetActive(true);

        _finalScoreText.text = GameManager._instance._score.ToString();
    }
}