using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider MasterVolumeSlider;
    public InputField MasterVolumeInput;
    public SceneField BackScene;

    private float MasterVolume = 1f;

    private void Awake()
    {
        MasterVolume = PlayerSettings.MasterVolume;

        MasterVolumeInput.text = MasterVolume.ToString("0.00");
        MasterVolumeSlider.value = MasterVolume;
        MasterVolumeSlider.onValueChanged.AddListener(f =>
        {
            MasterVolume = f;
            MasterVolumeInput.text = MasterVolume.ToString("0.00");
        });
        //MasterVolumeInput.onValidateInput.
        MasterVolumeInput.onEndEdit.AddListener(s =>
        {
            MasterVolume = float.Parse(s);
            MasterVolumeSlider.value = MasterVolume;
        });
    }

    public void BackClick()
    {
        PlayerSettings.MasterVolume = MasterVolume;
        PlayerSettings.Save();
        SceneManager.LoadScene(BackScene.SceneName);
    }

    public void ResetClick()
    {
        MasterVolume = PlayerSettings.MasterVolume;
        MasterVolumeInput.text = MasterVolume.ToString("0.00");
        MasterVolumeSlider.value = MasterVolume;
    }
}
