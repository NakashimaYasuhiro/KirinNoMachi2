
using System.Collections;
using System.Net;
using UnityEngine;
using UnityEngine.AI;
public class AgentMovement : MonoBehaviour
{

    Vector3 targetPos;

    NavMeshAgent agent;
    public GameObject shouzhou;

    enum State
    {
        Follow,
        Straying,
        BiteDistance,
    }

    State state;
    private void Awake()
    {
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
        Vector3 targetPos = shouzhou.transform.position;

        /* プレイヤーのポジションを取得 */
        Vector3 playerPos = agent.transform.position;

        /* ターゲットとプレイヤーの距離を取得 */
        float dis = Vector3.Distance(targetPos, playerPos);

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
                    //Debug.Log(state);
                    break;

                case State.Straying:
                    StartCoroutine(SetRandomTargetPosition());
                    SetAgentPosition();
                    //Debug.Log(state);
                    break;

                case State.BiteDistance:
                    //Debug.Log(state);
                    break;
             }
            yield return null;
            
        }
               

       }
    
    

    void SetTargetPosition()
    {

        targetPos = shouzhou.transform.position;
        
    }

    void SetAgentPosition()
    {
      agent.SetDestination(new Vector3(targetPos.x, targetPos.y , transform.position.z));
    }


    IEnumerator SetRandomTargetPosition()
    {
        yield return new WaitForSeconds(5);
        targetPos = new Vector3(Random.Range(-18, 18), Random.Range(-5,5));
    }



}
