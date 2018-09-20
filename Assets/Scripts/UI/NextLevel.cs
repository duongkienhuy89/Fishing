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
        try
        {
        txtLevel.text = "Level "+GameController.instance.mLevel;
        txtTarget.text = "Target " + GameController.instance.mTarget;
        }
        catch (System.Exception)
        {


            throw;
        }
    }

    void onClickPlay()
    {
        try
        {
        PopUpController.instance.HideNextGame();
        GameController.instance.currentState = GameController.State.INGAME;
       // GroupFishController.instance.Create();
        GameController.instance.setTartget();
        Toucher.resetTouch();
        }
        catch (System.Exception)
        {


            throw;
        }
    }

    void onClick_Share()
    {
        try
        {
        ShareRate.Share();
        }
        catch (System.Exception)
        {


            throw;
        }
    }
    void onClick_Rank()
    {
        try
        {
        ShareRate.Rate();
        }
        catch (System.Exception)
        {


            throw;
        }
    }

	// Use this for initialization
	void Start () {

        try
        {
        btnPlay.OnClick += onClickPlay;
        btnShare.OnClick += onClick_Share;
        btnRank.OnClick += onClick_Rank;
        }
        catch (System.Exception)
        {


            throw;
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
