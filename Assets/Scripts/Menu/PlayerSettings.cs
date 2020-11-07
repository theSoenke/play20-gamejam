using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerSettings 
{    

    public static float MasterVolume
    {
        get
        {
            if (!PlayerPrefs.HasKey(nameof(MasterVolume)))
            {
                PlayerPrefs.SetFloat(nameof(MasterVolume), 1f);
                Save();
            }
            return PlayerPrefs.GetFloat(nameof(MasterVolume));
        } 
        set
        {
            PlayerPrefs.SetFloat(nameof(MasterVolume), value);
        }
    }  

    public static void Save()
    {
        PlayerPrefs.Save();
    }
}
