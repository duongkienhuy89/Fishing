using UnityEngine;
using System.Collections;

public class SongBien : MonoBehaviour {

  
    public float speedMove;
    public GameObject tamquay;
 

    public enum State
    {
        UP,
        DOWN
    }

    public State currentState;

	// Use this for initialization
	void Start () {
        //currentState = State.DEAR;
	}

  


    void MoveState()
    {
        if (currentState == State.DOWN || currentState == State.UP)
        {
      
            if (currentState == State.UP)
            {
              
                // Debug.Log("llll:" + this.transform.eulerAngles.z);
                if (this.transform.eulerAngles.z <= 353f && this.transform.eulerAngles.z > 7f)
                {

                    currentState = State.DOWN;
                }
            
            }
            else
            {
               
                //Debug.Log("rrrr:" + this.transform.eulerAngles.z);
                if (this.transform.eulerAngles.z >= 7f && this.transform.eulerAngles.z < 353f)
                {

                    currentState = State.UP;

                }
             
            }
        }         

           

    }

    void Move()
    {
        if (currentState == State.UP)
        {
            this.transform.RotateAround(tamquay.transform.position, Vector3.back, speedMove * Time.deltaTime);
        }
        else if (currentState == State.DOWN)
        {
            this.transform.RotateAround(tamquay.transform.position, Vector3.forward, speedMove * Time.deltaTime);
        }
    }
	
	// Update is called once per frame
	void Update () {

        MoveState();
        Move();
       
      //  this.transform.rotation = Quaternion.Slerp
      //(
      //    this.transform.rotation,
      //    Quaternion.Euler(0, 0, -15f),
      //    20 * Time.deltaTime
      //);
        

	}
}
