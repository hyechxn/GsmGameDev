using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �ۼ��� : ������
/// </summary>
public class MainScene : MonoBehaviour
{
    [SerializeField] string inGameSceneName = "Game"; // ���� �� �̸� ����
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
