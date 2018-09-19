using UnityEngine;
using System.Collections;

public class LuoiCau : MonoBehaviour {


    public GameObject tamquay;
    private Vector3 velocity;
    public int checkRemove = 1;



    public enum State
    {

        IDE,
        LEFT,
        RIGHT,
        DOWN,
        ON
    }
    public State currentState;
    private State currentStateLeftRight;
    public Vector3 povisitionStart;
    public float speedCanCau;
    private float curentSpeedCanCau;
    public float speedVangCan;
    public float maxCau;
    private float sumCoinColider;

    public void setQuay()
    {
        povisitionStart = this.transform.position;
        currentState = State.LEFT;
    }

    // Use this for initialization
    void Start()
    {


        sumCoinColider = 0;

    }

    void MoveLeftRight()
    {
        if (currentState == State.LEFT)
        {
            this.transform.RotateAround(tamquay.transform.position, Vector3.back, speedVangCan * Time.deltaTime);
            // Debug.Log("llll:" + this.transform.GetChild(0).eulerAngles.z);
            if (this.transform.eulerAngles.z <= 310f && this.transform.eulerAngles.z > 40f)
            {

                currentState = State.RIGHT;
                this.transform.RotateAround(tamquay.transform.position, Vector3.forward, speedVangCan * Time.deltaTime);
            }
        }

        if (currentState == State.RIGHT)
        {
            this.transform.RotateAround(tamquay.transform.position, Vector3.forward, speedVangCan * Time.deltaTime);
            // Debug.Log("rrrr:" + this.transform.GetChild(0).eulerAngles.z);
            if (this.transform.eulerAngles.z >= 40f && this.transform.eulerAngles.z < 310f)
            {

                currentState = State.LEFT;
                this.transform.RotateAround(tamquay.transform.position, Vector3.back, speedVangCan * Time.deltaTime);

            }
        }

        //if (currentState == State.LEFTRIGHT)
        //{
        //    this.transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * 1f) * 75);
        //}
    }
    void GetDirectionMove()
    {
        Vector3 direction = new Vector3(this.transform.GetChild(0).position.x - tamquay.transform.position.x, this.transform.GetChild(0).position.y - tamquay.transform.position.y, 0f);

        velocity = direction.normalized;


    }

    public bool IsVisibleToCamera(Transform transform)
    {
        Vector3 visTest = Camera.main.WorldToViewportPoint(transform.position);
        return (visTest.x >= 0 && visTest.y >= 0) && (visTest.x <= 1.2 && visTest.y <= 1);
    }

    void MoveUpDown()
    {
        if (currentState == State.DOWN)
        {
            GetDirectionMove();
            this.transform.GetComponent<Rigidbody>().velocity = velocity * curentSpeedCanCau;
        }
        else if (currentState == State.ON)
        {
            this.transform.GetComponent<Rigidbody>().velocity = (-velocity) * curentSpeedCanCau;
        }
    }

    //void OnCollisionEnter(Collision col1)
    //{
    //   // Debug.Log("dkm:");
    //}

    void OnTriggerEnter(Collider other)
    {

        if (currentState == State.DOWN || currentState == State.ON)
        {
            sumCoinColider += other.gameObject.GetComponent<Boi>().mCoin;
            curentSpeedCanCau = speedCanCau / 2 - sumCoinColider/2;
            if (curentSpeedCanCau <= 100)
            {
                curentSpeedCanCau = 100;
            }
            currentState = State.ON;

            StartCoroutine(WaitTimeSetCheck(0.1f));
            //tuong duong voi checkMove=2
        }
        else
        {
            checkRemove = 3;
        }
       
        
      
    }

    IEnumerator WaitTimeSetCheck(float time)
    {
        yield return new WaitForSeconds(time);
        checkRemove = 2;
    }



    // Update is called once per frame
    void Update()
    {


        //Debug.Log("dddd:" + IsVisibleToCamera(this.transform.GetChild(0).transform));

        MoveLeftRight();

        if (Toucher.CheckTouch() && (currentState == State.LEFT || currentState == State.RIGHT)&& GameController.instance.currentState==GameController.State.INGAME)
        {
            currentStateLeftRight = currentState;
            curentSpeedCanCau = speedCanCau;
            currentState = State.DOWN;
            checkRemove = 1;
            SoundManager.Instance.PlayAudioCham();
       

        }

        if (currentState == State.DOWN)
        {
            if (this.transform.position.y < maxCau || IsVisibleToCamera(this.transform.transform) == false)
            {
                currentState = State.ON;
                StartCoroutine(WaitTimeSetCheck(0.1f));
            }
        }

        if (currentState == State.ON)
        {
            if (this.transform.position.y >= povisitionStart.y)
            {
                checkRemove = 3;
                this.transform.position = povisitionStart;
                this.transform.localEulerAngles = new Vector3(0, 0, 0);
                this.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
                currentState = currentStateLeftRight;
                sumCoinColider = 0;
                if (curentSpeedCanCau == speedCanCau)
                {
                    SoundManager.Instance.PlayAudioOver();
                }
                Toucher.resetTouch();
                
         

            }
        }

        MoveUpDown();




        this.gameObject.GetComponent<LineRenderer>().SetPosition(0, tamquay.transform.position);
        this.gameObject.GetComponent<LineRenderer>().SetPosition(1, new Vector3(this.transform.GetChild(0).position.x, this.transform.GetChild(0).position.y, this.transform.GetChild(0).position.z));

    }
}
