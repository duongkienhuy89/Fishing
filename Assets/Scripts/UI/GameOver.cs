using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class GameOver : MonoBehaviour {

    public tk2dUIItem btnContinute;
    public tk2dSprite gameoverText;
    public tk2dTextMesh txtScore;
    public tk2dTextMesh txtBest;

    InterstitialAd interstitial;

    private void LoadAdsInterstitial()
    {
        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(Config.adsInIDGameOver);
        // Create an empty ad request.
        AdRequest requestIN = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("365BCE5DDF729BFD1E6E40D79CE8F42B").Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(requestIN);
    }

    private void ShowAdsInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }



    public void setData()
    {
        LoadAdsInterstitial();
        try
        {
            if (GameController.instance.stCoin.Contains("+"))
            {
                string[] mang = GameController.instance.stCoin.Split('+');
                if (GameController.instance.mDiem > int.Parse(mang[GameController.instance.mLevel - 1]))
                {
                    txtBest.text = "" + GameController.instance.mDiem;
                    
                    mang[GameController.instance.mLevel - 1] = "" + GameController.instance.mDiem;
                    GameController.instance.stCoin = "";
                    for (int i = 0; i < mang.Length; i++)
                    {
                        if (i != mang.Length - 1)
                        {
                            GameController.instance.stCoin += mang[i] + "+";
                        }
                        else
                        {
                            GameController.instance.stCoin += mang[i];
                        }
                    }
                    DataManager.SaveHightStringCoin(GameController.instance.stCoin);
                }
                else
                {
                    txtBest.text = "" + mang[GameController.instance.mLevel - 1]; 
                }
            }
           
        }
        catch
        {
            Debug.Log("clgt");
        }



        txtScore.text = "" + GameController.instance.mDiem;


        if (GameController.instance.mDiem >= GameController.instance.mTarget)
        {
            gameoverText.SetSprite("winner");
            GameController.instance.mLevel++;
            if (GameController.instance.mNumberType <= 15)
            {
                GameController.instance.mNumberType++;
                GameController.instance.mTarget += 200;
            }
            else
            {
                GameController.instance.mTarget += 100;
            }

            SoundManager.Instance.Stop();
            SoundManager.Instance.PlayAudioWin();
        }
        else
        {
            gameoverText.SetSprite("gameovertext");
            SoundManager.Instance.Stop();
            SoundManager.Instance.PlayAudioOver();
        }



       
    }

    void onClick_Continute()
    {
      
        GameController.instance.resetGame();
        PopUpController.instance.HideGameOver();
        PopUpController.instance.ShowNextGame();

        if (GameController.instance.mLevel % 2 != 0)
        {
            ShowAdsInterstitial();
        }
 
     
    }

	// Use this for initialization
	void Start () {
        btnContinute.OnClick += onClick_Continute;
        LoadAdsInterstitial();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
