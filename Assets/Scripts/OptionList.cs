using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum LanguageType
{
    English,
    Korean,
}

public class OptionList : Singleton
{
    const string KeyLang = "DWB_LANG";
    const string KeyBGMVolume = "DWB_BGM";
    const string KeySFXVolume = "DWB_SFX";

    public static LanguageType languageType;
    public static int bgmVolume;
    public static int sfxVolume;

    public Text labelTitle;
    public Text labelLanguage;
    public Text labelBGMVolume;
    public Text labelSFXVolume;

    public Text valueLanguage;
    public Text valueBGM;
    public Text valueSFX;
    public Slider sliderBGM;
    public Slider sliderSFX;

    private void Awake()
    {
        if (optionList == null)
            optionList = this;
        else
            Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        if(optionList == this)
            optionList = null;
    }

    private void OnEnable()
    {
        RefreshUI();
    }

    public static void SetOption()
    {
        languageType = (LanguageType)PlayerPrefs.GetInt(KeyLang, 0);
        bgmVolume = PlayerPrefs.GetInt(KeyBGMVolume, 10);
        sfxVolume = PlayerPrefs.GetInt(KeySFXVolume, 10);

        audioManager.bgmAudioSource.volume = 0.01f * (float)bgmVolume;
        audioManager.sfxAudioSource.volume = 0.1f * (float)sfxVolume;
    }

    public void RefreshUI()
    {
        labelTitle.text = Texts.menuLabels[1, (int)languageType];
        labelLanguage.text = Texts.optionLabels[0, (int)languageType];
        labelBGMVolume.text = Texts.optionLabels[1, (int)languageType];
        labelSFXVolume.text = Texts.optionLabels[2, (int)languageType];

        valueLanguage.text = Texts.languageValues[(int)languageType];
        valueBGM.text = bgmVolume.ToString();
        valueSFX.text = sfxVolume.ToString();
        sliderBGM.value = bgmVolume;
        sliderSFX.value = sfxVolume;

    }

    public void SetLanguage()
    {
        languageType = (LanguageType)(((int)languageType + 1) % System.Enum.GetValues(typeof(LanguageType)).Length);
        PlayerPrefs.SetInt(KeyLang, (int)languageType);
        RefreshUI();
        Observer.changeLang?.Invoke();
    }

    public void SetVolumeBGM(float value)
    {
        bgmVolume = (int)value;
        PlayerPrefs.SetInt(KeyBGMVolume, bgmVolume);
        audioManager.bgmAudioSource.volume = 0.01f * bgmVolume;
        RefreshUI();
    }

    public void SetVolumeSFX(float value)
    {
        sfxVolume = (int)value;
        PlayerPrefs.SetInt(KeySFXVolume, sfxVolume);
        audioManager.sfxAudioSource.volume = 0.1f * sfxVolume;
        RefreshUI();
    }

    public void Open()
    {
        SetOption();
        RefreshUI();
    }

    public void Close()
    {
        this.SetActive(false);
    }
}
