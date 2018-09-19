using UnityEngine;
using System.Collections;

public class Boi : MonoBehaviour {


    public enum State
    {
        IDLE,
        MOVENGANG,
        MOVELUOICAU

    }

    public State currentState = State.IDLE;
    public int mCoin;
    private GameObject luoicau;
    public int tmgCheckLuoiCau=1;
    public float speed;


    public void setMove()
    {
        currentState = State.MOVENGANG;
    }

    void MoveLuoiCau()
    {
        if (currentState == State.MOVELUOICAU)
        {
            if (tmgCheckLuoiCau == 1)
            {
                this.transform.position = new Vector3(luoicau.transform.position.x, luoicau.transform.position.y - this.gameObject.GetComponent<MeshCollider>().bounds.size.y / 2, this.transform.position.z);
            }
            else if (tmgCheckLuoiCau == 2)
            {
                this.transform.position = new Vector3(luoicau.transform.position.x, luoicau.transform.position.y + this.gameObject.GetComponent<MeshCollider>().bounds.size.y / 3, this.transform.position.z);
            }

           
            if (luoicau.GetComponent<LuoiCau>().checkRemove==3)
            {
                currentState = State.IDLE;              
                
                this.gameObject.GetComponent<MeshCollider>().enabled = false;
                this.gameObject.GetComponent<MapMo>().setMove();

                if (GameController.instance.currentState == GameController.State.INGAME)
                {
                    GameController.instance.setDiem(mCoin);
                    SoundManager.Instance.Stop();
                    SoundManager.Instance.PlayAudioCongDiem();
                }
             

                //this.gameObject.GetComponent<TopBotton>().setTopBotton(this.gameObject.GetComponent<TopBotton>().checkTop);
                // this.transform.localEulerAngles = new Vector3(0, 0, 0);
                //this.RecycleSp();
             
            }
        }
    }


    //void OnCollisionEnter(Collision col1)
    //{
    //    Debug.Log("dkm:");
    //}

    void OnTriggerEnter(Collider other)
    {
       
         currentState = State.MOVELUOICAU;
         this.gameObject.GetComponent<TopBotton>().StopMove();
         luoicau = other.gameObject;
         tmgCheckLuoiCau = luoicau.GetComponent<LuoiCau>().checkRemove;
         this.transform.localEulerAngles = new Vector3(0, 0, UnityEngine.Random.Range(-16,16));
        
    }

    public void RecycleSp()
    {
        this.Recycle<Boi>();
    }

   

    void Move()
    {
        if (currentState == State.MOVENGANG)
        {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        MoveLuoiCau();
        if (this.transform.position.x > 800)
        {
            this.RecycleSp();
        }

      
	}
}
