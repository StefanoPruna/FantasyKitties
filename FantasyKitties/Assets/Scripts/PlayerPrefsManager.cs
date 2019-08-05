using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    public static void saveLevel(string level)
    {
        PlayerPrefs.SetString("Level", level);            
    }

    public static string loadLevel()
    {
       return PlayerPrefs.GetString("Level");
    }
}
