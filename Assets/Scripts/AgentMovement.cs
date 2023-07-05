
using System.Collections;
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
    void Update()
    {
        /* ターゲットのポジションを取得 */
        Vector3 targetPos = shouzhou.transform.position;

        /* プレイヤーのポジションを取得 */
        Vector3 playerPos = agent.transform.position;

        /* ターゲットとプレイヤーの距離を取得 */
        float dis = Vector3.Distance(targetPos, playerPos);

        if (dis >= 2 && dis<10) { state = State.Follow;}
        else if (dis >= 10) { state = State.Straying;}
        else if (dis <2) { state = State.BiteDistance; }
        switch (state)
        {
            case 
                State.Follow:
                SetTargetPosition();
                SetAgentPosition();
                //Debug.Log(state);
                break;

            case State.Straying:
                StartCoroutine(SetRandomTargetPosition2());
                SetAgentPosition();
                //Debug.Log(state);
                break;

            case State.BiteDistance:
                //Debug.Log(state);
                break;


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

    void SetRandomTargetPosition()
    {

      targetPos = new Vector3(Random.Range(-100,50), Random.Range(-100, 50), Random.Range(1, 50));
      
    }

    IEnumerator SetRandomTargetPosition2()
    {
        yield return new WaitForSeconds(5);
        yield return targetPos = new Vector3(Random.Range(-100, 50), Random.Range(-100, 50), Random.Range(1, 50));
    }



}
