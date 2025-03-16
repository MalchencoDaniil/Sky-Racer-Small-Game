using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    public static GameManager _instance;

    private UI_Manager _uiManager;

    internal int _score;

    private int _record = 0;

    private void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _uiManager = FindObjectOfType<UI_Manager>();

        _record = PlayerPrefs.GetInt("Record");
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        _score = (int)(_playerMovement.transform.position.z * 2);
    }

    public void Loss()
    {
        if (_score > _record) PlayerPrefs.SetInt("Record", _score);
        CursorManager._instance.UpdateCursorState(CursorManager.CursorState.UnLocked);

        StartCoroutine(_uiManager.OpenLossPanel());
    }
}