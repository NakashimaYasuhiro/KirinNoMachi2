
using System.Collections;
using System.Net;
using UnityEngine;
using UnityEngine.AI;
public class AgentMovement : MonoBehaviour
{

    Vector3 targetPos;
    Vector3 agentPos;

    NavMeshAgent agent;
    public GameObject shouzhou;


    Animator animator;


    enum State
    {
        Follow,
        Straying,
        BiteDistance,
    }
    State state;

    enum KirinDirection
    {
        Right,
        Left,
        Up,
        Down,
        Stay,
    }
    KirinDirection kirinDirection;
    private void Awake()
    {   
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Start()
    {
        StartCoroutine(LoopGame());

    }

    void Update()
    {

    }
    void CheckState()
    {
        /* ターゲットのポジションを取得 */
        targetPos = shouzhou.transform.position;

        /* プレイヤーのポジションを取得 */
        agentPos = agent.transform.position;

        /* ターゲットとプレイヤーの距離を取得 */
        float dis = Vector3.Distance(targetPos, agentPos);

        if (dis >= 2 && dis < 5)
            { state = State.Follow; }
        else if (dis >= 5)
            { state = State.Straying; }
        else if (dis < 2)
            { state = State.BiteDistance; }
        //Debug.Log(dis);
    }
    IEnumerator LoopGame()
      {
        


            while (true)
        {
            SetAgentDirection();
            CheckState();
            if (state == State.Straying)
            {
                yield return new WaitForSeconds(5);
            }
            
           
            switch (state)
            {
                case State.Follow:
                    SetTargetPosition();
                    SetAgentPosition();
                    Debug.Log(state);
                    break;

                case State.Straying:
                    StartCoroutine(SetRandomTargetPosition());
                    SetAgentPosition();
                    Debug.Log(state);
                    break;

                case State.BiteDistance:
                    Debug.Log(state);
                    break;
             }
            yield return null;
            
        }
               
       }   
    
    //shouzhouのポジションを取得
    void SetTargetPosition()
    {

        targetPos = shouzhou.transform.position;
        
    }
    //Kirinのポジションを取得
    void SetAgentPosition()
    {
      agent.SetDestination(new Vector3(targetPos.x, targetPos.y , transform.position.z));
    }

    //KirinのStray中のポジション
    IEnumerator SetRandomTargetPosition()
    {
        yield return new WaitForSeconds(5);
        targetPos = new Vector3(Random.Range(-18, 18), Random.Range(-5,5));
    }

    //Kirinアニメーションの向き
    private void SetAgentDirection()
    {
        Debug.Log("targetPosX"+targetPos.x);
        Debug.Log("agentPosX"+ agentPos.x);
        //Debug.Log("targetPosX-agentPosX" + (targetPos.x- agentPos.x));
        //Debug.Log("targetPosY-agentPosY" + (targetPos.y - agentPos.y));
        float absX = Mathf.Abs(targetPos.x - agentPos.x);
        //Debug.Log("absX"+absX);
        float absY = Mathf.Abs(targetPos.y - agentPos.y);
        //Debug.Log("absY" + absY);
        if (absX - absY > 0)
        {

          
            if (targetPos.x > agentPos.x)
            {
                kirinDirection = KirinDirection.Right;
                SetBoolRight();
                Debug.Log(KirinDirection.Right);
            }
            else
            {
                kirinDirection = KirinDirection.Left;
                SetBoolLeft();
                Debug.Log(KirinDirection.Left);
            }
        }

        if (absX - absY < 0)
        {
                if (targetPos.y > agentPos.y)
                {
                    kirinDirection = KirinDirection.Up;
                    SetBoolUp();
                    Debug.Log(KirinDirection.Up);
                }
                if(targetPos.y < agentPos.y)
                {
                    kirinDirection = KirinDirection.Down;
                SetBoolDown();
                    Debug.Log(KirinDirection.Down);
                }
        }

        void SetBoolLeft()
        {
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
        }
        void SetBoolRight()
        {
            animator.SetBool("Left", false);
            animator.SetBool("Right", true);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
        }
        void SetBoolUp()
        {
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
            animator.SetBool("Up", true);
            animator.SetBool("Down", false);
        }
        void SetBoolDown()
        {
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", true);
        }
    }


}
