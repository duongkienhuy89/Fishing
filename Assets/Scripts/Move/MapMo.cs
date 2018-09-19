using UnityEngine;
using System.Collections;

public class MapMo : MonoBehaviour
{

    public enum State
    {
        IDE,
        MOVE
    }
    public State currentState = State.IDE;
    float numColorA = 1f;
    public float speed;

    public void setMove()
    {
        currentState = State.MOVE;
    }

    void Move()
    {
        if (currentState == State.MOVE)
        {
            if (numColorA > 0)
            {
                numColorA = numColorA - 0.03f;
                this.gameObject.GetComponent<tk2dSprite>().color = new Color(this.gameObject.GetComponent<tk2dSprite>().color.r, this.gameObject.GetComponent<tk2dSprite>().color.g, this.gameObject.GetComponent<tk2dSprite>().color.b, numColorA);
            }
            else
            {
                currentState = State.IDE;

                //Goi diem coin map mo ra
                GroupFishController.instance.CreateCoin(this.gameObject.GetComponent<Boi>().mCoin);

                numColorA = 1f;
                this.gameObject.GetComponent<tk2dSprite>().color = new Color(this.gameObject.GetComponent<tk2dSprite>().color.r, this.gameObject.GetComponent<tk2dSprite>().color.g, this.gameObject.GetComponent<tk2dSprite>().color.b, numColorA);
                this.gameObject.GetComponent<MeshCollider>().enabled = true;
                this.gameObject.GetComponent<TopBotton>().setTopBotton(this.gameObject.GetComponent<TopBotton>().checkTop);
                this.transform.localEulerAngles = new Vector3(0, 0, 0);
                this.gameObject.GetComponent<Boi>().RecycleSp();
             
            }

            this.gameObject.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}