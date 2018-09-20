using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GroupFishController : MonoBehaviour {

    public Boi spPrefabXanh;
    public Boi spPrefabXanhVang;
    public Boi spPrefabVit;
    public Boi spPrefabTuong;
    public Boi spPrefabSaoBien;
    public Boi spPrefabRuaBien;
    public Boi spPrefabRua;
    public Boi spPrefabNgua;
    public Boi spPrefabMuc;
    public Boi spPrefabHongVang;
    public Boi spPrefabHaiCau;
    public Boi spPrefabDoVang;
    public Boi spPrefabCua;
    public Boi spPrefabCo;
    public Boi spPrefabBachTuoc;
    private Boi spPrefabTam;

    public BoiMo spPrefabMoBoi;
    public BongBong spPrefabBongBong;


    public Coin coinPrefab;

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float TbtX;
    List<GameObject> children = new List<GameObject>();


    #region Singleton
    private static GroupFishController _instance;

    public static GroupFishController instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<GroupFishController>();
            return _instance;
        }
    }
    #endregion


    public enum State
    {
        CRS,
        CRT,
        WAIT

    }
    public State currentState;


    //Tao Bong Bong


    void CreateBongBong()
    {
        for (int i = 0; i < 7; i++)
        {
            float chonY = UnityEngine.Random.Range(-900, -600);
            float chonX = UnityEngine.Random.Range(-300, 300);
            CreateDetailBongBong(chonX, chonY);
        }
    }

    void CreateDetailBongBong(float positionX, float positionY)
    {
        BongBong levelCreate = spPrefabBongBong.Spawn<BongBong>
        (
              new Vector3(positionX, positionY, 55),
          spPrefabBongBong.transform.rotation
        );
     
        float pScale = UnityEngine.Random.Range(0.5f, 1f);
        levelCreate.gameObject.GetComponent<tk2dSprite>().scale = new Vector3(pScale, pScale, 1);
        levelCreate.transform.parent = this.gameObject.transform;
    }


    //Tao Ca map mo
    void CreateMapMoCa()
    {
        for (int i = 0; i < 10; i++)
        {
             float chonY = UnityEngine.Random.Range(minY, maxY);
             float chonX = UnityEngine.Random.Range(minX-700, maxX);
              CreateDetailCaMapMo(chonX, chonY);
        }
    }


    void CreateDetailCaMapMo(float positionX, float positionY)
    {
        BoiMo levelCreate = spPrefabMoBoi.Spawn<BoiMo>
        (
              new Vector3(positionX, positionY, 60),
          spPrefabMoBoi.transform.rotation
        );
        levelCreate.gameObject.GetComponent<tk2dSprite>().color = new Color(1, 1, 1, UnityEngine.Random.Range(0.3f, 1f));
        float pScale = UnityEngine.Random.Range(0.5f, 1f);
        levelCreate.gameObject.GetComponent<tk2dSprite>().scale = new Vector3(pScale, pScale, 1);
        levelCreate.transform.parent = this.gameObject.transform;
        
    }


    //Tao Diem
    void CreateDetailCoin(float positionX, float positionY,int pCoin)
    {
        Coin levelCreate = coinPrefab.Spawn<Coin>
       (
          new Vector3(positionX, positionY, 47),
          coinPrefab.transform.rotation
       );
        levelCreate.setMove(pCoin);

    }

    public void CreateCoin(int pCoin)
    {
        try
        {
        CreateDetailCoin(UnityEngine.Random.Range(-100, 150), UnityEngine.Random.Range(maxY+10, maxY + 110), pCoin);
        }
        catch (System.Exception)
        {


            throw;
        }
    }




    //Tao ca that
    void CreateLevel(float positionX, float positionY)
    {


        int chon = UnityEngine.Random.Range(0, GameController.instance.mNumberType + 1);
        switch (chon)
        {
            case 2:
                spPrefabTam = spPrefabVit;
                break;
            case 3:
                spPrefabTam = spPrefabXanhVang;
                break;
            case 4:
                spPrefabTam = spPrefabDoVang;
                break;
            case 5:
                spPrefabTam = spPrefabNgua;
                break;
            case 6:
                spPrefabTam = spPrefabCo;
                break;
            case 7:
                spPrefabTam = spPrefabTuong;
                break;
            case 8:
                spPrefabTam = spPrefabHongVang;
                break;
            case 9:
                spPrefabTam = spPrefabRuaBien;
                break;
            case 10:
                spPrefabTam = spPrefabBachTuoc;
                break;
            case 11:
                spPrefabTam = spPrefabMuc;
                break;
            case 12:
                spPrefabTam = spPrefabRua;
                break;
            case 13:
                spPrefabTam = spPrefabCua;
                break;
            case 14:
                spPrefabTam = spPrefabHaiCau;
                break;
            case 15:
                spPrefabTam = spPrefabSaoBien;
                break;
            default:
                spPrefabTam = spPrefabXanh;
                break;
        }


        Boi levelCreate = spPrefabTam.Spawn<Boi>
          (
             new Vector3(positionX, positionY, 47),
           spPrefabTam.transform.rotation
          );

        levelCreate.transform.parent = this.gameObject.transform;
        levelCreate.setMove();
        children.Add(levelCreate.gameObject);
    }

    void doPhanPhat()
    {

        float chonX;
        float chonY = UnityEngine.Random.Range(minY, maxY);

        if (currentState == State.CRS)
        {
            chonX = UnityEngine.Random.Range(minX, maxX);
        }else 
        {
            chonX = UnityEngine.Random.Range(minX+TbtX-100, maxX+TbtX-100);
        }

        CreateLevel(chonX, chonY);
    }

    public void Create()
    {
        int sl;
        if (currentState == State.CRS)
        {
            sl = 6;
        }
        else
        {
            sl = UnityEngine.Random.Range(3, 7);
        }

     



        children.Clear();
        for (int i = 1; i <= sl; i++)
        {

            doPhanPhat();
        }
        currentState = State.WAIT;
    }

    //public void setEmptyChild()
    //{
    //    var children = new List<GameObject>();
    //    foreach (Transform child in this.transform)
    //    {
    //        children.Add(child.gameObject);
    //    }


    //    foreach (GameObject item in children)
    //    {

           
        
    //        item.transform.parent = null;
    //        item.transform.Recycle();
    //    }



    //}

	// Use this for initialization
	void Start () {
        //Create(10);
        try
        {
        currentState = State.CRS;
        CreateMapMoCa();
        CreateBongBong();
        }
        catch (System.Exception)
        {


            throw;
        }
	}

    void doCheckCreate()
    {
        if (currentState == State.WAIT)
        {
            foreach (GameObject item in children)
            {
                if (item.transform.position.x > TbtX)
                {
                    currentState = State.CRT;
                    Create();
                    break;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        doCheckCreate();
	}
}
