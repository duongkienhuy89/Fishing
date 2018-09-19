using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

    public tk2dUIItem btnPlay;
    public tk2dTextMesh txtLevel;
    public tk2dTextMesh txtTarget;
    public tk2dUIItem btnShare;
    public tk2dUIItem btnRank;

    public void setData()
    {
        txtLevel.text = "Level "+GameController.instance.mLevel;
        txtTarget.text = "Target " + GameController.instance.mTarget;
    }

    void onClickPlay()
    {
        PopUpController.instance.HideNextGame();
        GameController.instance.currentState = GameController.State.INGAME;
       // GroupFishController.instance.Create();
        GameController.instance.setTartget();
        Toucher.resetTouch();
    }

    void onClick_Share()
    {
        ShareRate.Share();
    }
    void onClick_Rank()
    {
        ShareRate.Rate();
    }

	// Use this for initialization
	void Start () {

        btnPlay.OnClick += onClickPlay;
        btnShare.OnClick += onClick_Share;
        btnRank.OnClick += onClick_Rank;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
