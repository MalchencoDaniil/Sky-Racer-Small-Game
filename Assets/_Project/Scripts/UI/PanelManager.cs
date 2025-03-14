using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public void OpenPanel(GameObject _panel) => _panel.SetActive(true);

    public void ClosePanel(GameObject _panel) => _panel.SetActive(false);
}