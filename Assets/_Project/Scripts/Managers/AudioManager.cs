using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer _audioMixer;

    [SerializeField]
    private Slider _volumeSlider;

    [SerializeField]
    private Text _volumeText;

    private string volumeParameterName = "Master";

    private float _volumeScaleFactor = 100f / 80f;

    private void Start()
    {
        float _initialVolume;

        bool _result = _audioMixer.GetFloat(volumeParameterName, out _initialVolume);

        if (_result)
        {
            _volumeSlider.value = _initialVolume;
            UpdateVolumeText(_initialVolume);
        }

        _volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    public void OnSliderValueChanged(float value)
    {
        _audioMixer.SetFloat(volumeParameterName, value);
        UpdateVolumeText(value);
    }

    private void UpdateVolumeText(float volumeInDecibels)
    {
        float volumePercentage = Mathf.Clamp01((volumeInDecibels + Mathf.Abs(_volumeSlider.minValue)) / Mathf.Abs(_volumeSlider.minValue)) * 100f;
        _volumeText.text = Mathf.RoundToInt(volumePercentage).ToString();
    }
}