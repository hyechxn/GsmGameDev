using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ¿€º∫¿⁄ : ¿¸πŒ«ı
/// </summary>
public class MainScene : MonoBehaviour
{
    [SerializeField] string inGameSceneName = "Game"; // ∞‘¿” æ¿ ¿Ã∏ß ¿˚±‚
    [SerializeField] GameObject settingPanel;

    public void OnClickStartButton()
    {
        SceneManager.LoadScene(inGameSceneName);
    }

    public void OnClickSettingButton()
    {
        settingPanel.SetActive(true);
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }
}
