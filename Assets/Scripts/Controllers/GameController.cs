using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class GameController : MonoBehaviour {


    #region Singleton
    private static GameController _instance;

    public static GameController instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<GameController>();
            return _instance;
        }
    }
    #endregion

    void Awake()
    {
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = -1;
    }

    public enum State
    {

        SHA,
        START,
        INGAME,
        GAMEOVER
    }
    public State currentState;
    public int mDiem;
    public int mNumberType=4;
    public int mTarget=200;
    public int mLevel=1;
    public tk2dTextMesh txtDiem;
    public tk2dTextMesh txtTime;
    public tk2dTextMesh txtTarget;
    public tk2dTextMesh txtLevel;
    int mTime = 90;
    int demframe = 0;
    public string stCoin;
    BannerView bannerView;

    public void resetGame()
    {
        mTime = 90;
        demframe = 0;
        mDiem = 0;
        setText();
        txtTime.text = "Time:" + mTime;
    }

    public void setTartget()
    {
        txtTarget.text = "Target: "+mTarget;
        txtLevel.text="Level "+mLevel;
    }

    public void setDiem(int pDiem)
    {
        mDiem += pDiem;        
    }

    public void setText()
    {
        txtDiem.text = "Score: " + mDiem;
    }

    void LoadBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(Config.adsInIDBanner, AdSize.Banner, AdPosition.Top);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }
    public void HideBanner()
    {
        bannerView.Hide();
    }

	// Use this for initialization
	void Start () {
        currentState = State.SHA;
        LoadBanner();
        StartCoroutine(WaitTimeLoadData(3f));
        mDiem = 0;
        setTartget();
        stCoin = DataManager.GetHightStringCoin();
	}

    IEnumerator WaitTimeLoadData(float mtime)
    {
        yield return new WaitForSeconds(mtime);

        
        PopUpController.instance.HideSha();
        PopUpController.instance.ShowMenu();
        currentState = State.START;


        bannerView.Show();


    }



	
	// Update is called once per frame
	void Update () {


        if (currentState == State.INGAME)
        {
            if (demframe < 30)
            {
                demframe++;
            }
            else
            {
                mTime--;
                txtTime.text = "Time:" + mTime;
                //if (mTime <= 10)
                //{
                //    txtTime.color = new Color(1, 0, 1, 1);
                //}

                demframe = 0;
                if (mTime <= 0)
                {
                    currentState = State.GAMEOVER;
                    PopUpController.instance.ShowGameOver();
                   // GroupFishController.instance.currentState = GroupFishController.State.CRS;
                    //hết giờ thì game over
            
                }
            }
        }
	}
}
