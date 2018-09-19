using UnityEngine;
using System.Collections;

public class PopUpController : MonoBehaviour {


    #region Singleton
    private static PopUpController _instance;

    public static PopUpController instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<PopUpController>();
            return _instance;
        }
    }
    #endregion

    public float showY;
    public float hideY;
    public float moveSpeed;

    public GameObject sha;
    public GameObject menuMain;
    public SPCau spDoCau;
    public GameOver gameOver;
    public NextLevel nextgame;

    //------NextGame
    public void ShowNextGame()
    {

        nextgame.setData();
        StartCoroutine(ieMoveDown(nextgame.gameObject, showY));
    }
    public void HideNextGame()
    {
        StartCoroutine(ieMoveUp(nextgame.gameObject, hideY));
    }



    //------GameOver
    public void ShowGameOver()
    {

        gameOver.setData();
        StartCoroutine(ieMoveDown(gameOver.gameObject, showY));
    }
    public void HideGameOver()
    {
        StartCoroutine(ieMoveUp(gameOver.gameObject, hideY));
    }


    //------Tool Cau
    public void ShowDoCau()
    {
        spDoCau.transform.position = new Vector3(spDoCau.gameObject.transform.position.x, showY, spDoCau.gameObject.transform.position.z);
        spDoCau.setLuoiCau();
       // StartCoroutine(ieMoveDown(spDoCau, showY));
    }
    public void HideDoCau()
    {
        StartCoroutine(ieMoveUp(spDoCau.gameObject, hideY));
    }

    //------Menu
    public void ShowMenu()
    {
        menuMain.transform.position = new Vector3(menuMain.gameObject.transform.position.x, showY, menuMain.gameObject.transform.position.z);
      //  StartCoroutine(ieMoveDown(menuMain, showY));
    }
    public void HideMenu()
    {
        menuMain.transform.position = new Vector3(menuMain.gameObject.transform.position.x, hideY, menuMain.gameObject.transform.position.z);
        //StartCoroutine(ieMoveUp(menuMain, hideY));
    }

    //------sha
    public void ShowSha()
    {

        StartCoroutine(ieMoveDown(sha, showY));
    }
    public void HideSha()
    {
        StartCoroutine(ieMoveUp(sha, hideY));
    }


    IEnumerator ieMoveDown(GameObject popup, float SY)
    {
        while (popup.transform.position.y >= SY)
        {
            popup.transform.position += Vector3.down
                * (moveSpeed)
                * Time.deltaTime;
            yield return 0;
        }
        popup.transform.position = new Vector3(popup.gameObject.transform.position.x, SY, popup.gameObject.transform.position.z);

    }

    IEnumerator ieMoveUp(GameObject popup, float HY)
    {
        while (popup.transform.position.y <= HY)
        {
            popup.transform.position += Vector3.up
                * (moveSpeed)
                * Time.deltaTime;
            yield return 0;
        }
        popup.transform.position = new Vector3(popup.gameObject.transform.position.x, HY, popup.gameObject.transform.position.z);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
