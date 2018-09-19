using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    public enum State
    {
        IDE,
        MOVE
    }
    public State currentState = State.IDE;
    float numColorA = 1f;
    public float speed;

    public void setMove(int pCoin)
    {
        currentState = State.MOVE;
        this.gameObject.GetComponent<tk2dTextMesh>().text = "+ " + pCoin;
      
    }

    void Move()
    {
        if (currentState == State.MOVE)
        {
            if (numColorA > 0)
            {
                numColorA = numColorA - 0.03f;
                this.gameObject.GetComponent<tk2dTextMesh>().color = new Color(this.gameObject.GetComponent<tk2dTextMesh>().color.r, this.gameObject.GetComponent<tk2dTextMesh>().color.g, this.gameObject.GetComponent<tk2dTextMesh>().color.b, numColorA);
            }
            else
            {
                currentState = State.IDE;
                GameController.instance.setText();
                numColorA = 1f;
                this.gameObject.GetComponent<tk2dTextMesh>().color = new Color(this.gameObject.GetComponent<tk2dTextMesh>().color.r, this.gameObject.GetComponent<tk2dTextMesh>().color.g, this.gameObject.GetComponent<tk2dTextMesh>().color.b, numColorA);
                this.RecycleSp();
            }

            this.gameObject.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
    }

    public void RecycleSp()
    {
        this.Recycle<Coin>();
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}
}
