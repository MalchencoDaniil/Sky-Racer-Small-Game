using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private GameObject _firstCamera, _secondCamera;

    public void Switch(bool _state)
    {
        _firstCamera.SetActive(_state);
        _secondCamera.SetActive(!_state);
    }
}