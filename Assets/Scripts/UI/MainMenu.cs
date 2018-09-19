using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public tk2dUIItem btnContinute;

    void onClick_Continute()
    {
        if (GameController.instance.currentState == GameController.State.START)
        {
            PopUpController.instance.ShowDoCau();
            PopUpController.instance.HideMenu();
            GameController.instance.currentState = GameController.State.INGAME;
            GroupFishController.instance.Create();

            GameController.instance.HideBanner();
        }
    }

	// Use this for initialization
	void Start () {
        
        btnContinute.OnClick += onClick_Continute;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
