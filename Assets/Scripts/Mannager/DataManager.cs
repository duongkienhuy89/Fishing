using UnityEngine;
using System.Collections;

public class DataManager  {

    private static string TAG_HIGHTCOIN = "clgt";
    //lay lai gia tri chuoi diem tung level da vuot qua.

    public static string GetHightStringCoin()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHTCOIN))
        {
            return PlayerPrefs.GetString(TAG_HIGHTCOIN);
        }
        else
        {
            return "0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0+0";
        }
    }

    //luu lai gia tri chuoi diem tung level da vuot qua.
    public static void SaveHightStringCoin(string newHightScore)
    {
        PlayerPrefs.SetString(TAG_HIGHTCOIN, newHightScore);
    }
}
