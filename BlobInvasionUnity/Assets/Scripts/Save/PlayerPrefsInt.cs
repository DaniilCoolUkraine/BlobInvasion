using UnityEngine;


public class PlayerPrefsInt
{
    private string _prefsName;

    public PlayerPrefsInt(string playerPrefsName)
    {
        _prefsName = playerPrefsName;
    }

    public int Get()
    {
        return PlayerPrefs.GetInt(_prefsName);
    }

    public void Set(int value)
    {
        PlayerPrefs.SetInt(_prefsName, value);
        PlayerPrefs.Save();
    }

    public bool IsExist()
    {
        return PlayerPrefs.HasKey(_prefsName);
    }
}

