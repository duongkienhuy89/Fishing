using UnityEngine;
using System.Collections;

public class TopBotton : MonoBehaviour {

    public float speedMoveX;
    public float maxDistanceX;
    private float moveDistanceX;
    private float velocityX;
    public bool vecterTrend;
    public bool checkTop = true;

    public enum State
    {
        IDLE,
        MOVETOP,
        MOVEBOTTON
    }

    public State currentState = State.IDLE;


    void MoveTop()
    {
        if (currentState == State.MOVEBOTTON)
        {
            if (moveDistanceX > maxDistanceX)
            {
                velocityX = speedMoveX;
                currentState = State.MOVETOP;
                moveDistanceX = 0;
            }
        }
    }

    void MoveBotton()
    {
        if (currentState == State.MOVETOP)
        {
            if (moveDistanceX > maxDistanceX)
            {
                velocityX = -speedMoveX;
                currentState = State.MOVEBOTTON;
                moveDistanceX = 0;
            }
        }
    }

    public void LetMove(bool isTop)
    {

        if (isTop)
        {
            velocityX = speedMoveX;
            currentState = State.MOVETOP;
        }
        else
        {
            velocityX = -speedMoveX;
            currentState = State.MOVEBOTTON;
        }

    }

    public void setTopBotton(bool ok)
    {
        if (ok)
        {
            currentState = State.MOVETOP;
        }
        else
        {
            currentState = State.MOVEBOTTON;
        }
    }

    public void StopMove()
    {
        if (currentState == State.MOVETOP)
        {
            checkTop = true;
        }
        else
        {
            checkTop = false;
        }
        currentState = State.IDLE;
    }

    void Move()
    {
        if (currentState == State.MOVETOP || currentState == State.MOVEBOTTON)
        {

            float currentDistance = velocityX * Time.deltaTime;

            moveDistanceX += Mathf.Abs(currentDistance);
            this.transform.position += new Vector3(0, currentDistance, 0);
        }

    }


    // Use this for initialization
    void Start()
    {
        LetMove(vecterTrend);
    }

    // Update is called once per frame
    void Update()
    {
        MoveTop();
        MoveBotton();
        Move();
    }
}
