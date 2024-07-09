using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ÀÛ¼ºÀÚ : Àü¹ÎÇõ
/// </summary>
public class ResolutionManager : MonoBehaviour
{
    FullScreenMode fullScreenMode;
    [SerializeField] Dropdown resolutionDropDown;
    public Toggle fullScreenButton;
    List<Resolution> resolutionList = new List<Resolution>();
    int resolutionNumber;

    void Start()
    {
        InitUI();
    }

    void InitUI()
    {
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Mathf.RoundToInt((float)Screen.resolutions[i].refreshRateRatio.value) == 60)
            {
                resolutionList.Add(Screen.resolutions[i]);
            }
        }

        resolutionDropDown.options.Clear();

        int optionNumber = 0;
        foreach (var item in resolutionList)
        {
            Dropdown.OptionData optionData = new Dropdown.OptionData();
            optionData.text = item.width + " x " + item.height + " " + Mathf.RoundToInt((float)item.refreshRateRatio.value) + "hz";
            resolutionDropDown.options.Add(optionData);

            if (item.width == Screen.width && item.height == Screen.height)
                resolutionDropDown.value = optionNumber;
            optionNumber++;
        }
        resolutionDropDown.RefreshShownValue();

        fullScreenButton.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
    }

    public void DropboxOptionChange(int number)
    {
        resolutionNumber = number;
    }

    public void FullScreenButton(bool isFull)
    {
        fullScreenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }

    public void ClickCheckButton()
    {
        Screen.SetResolution(resolutionList[resolutionNumber].width,
            resolutionList[resolutionNumber].height,
            fullScreenMode);
    }
}
