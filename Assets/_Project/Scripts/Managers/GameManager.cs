using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    public static GameManager _instance;

    internal int _score;

    private int _record = 0;

    private void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();

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

        SceneTransistion._instance.Restart();
    }
}