using UnityEngine;
using System.Collections;


public class Config
{

#if UNITY_IPHONE
 
        public static string adsInIDGameOver = "ca-app-pub-2127327600096597/4305651266";
    public static string adsInIDBanner = "ca-app-pub-2127327600096597/3188844864";
   

#endif

#if UNITY_ANDROID


    public static string adsInIDGameOver = "ca-app-pub-2577061470072962/7672486336";
    public static string adsInIDBanner = "ca-app-pub-2577061470072962/2337774735";


#endif

}
