
using DG.Tweening;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class AgentMovement : MonoBehaviour
{

    Vector3 targetPos;
    Vector3 agentPos;
    Vector3 childPos;

    NavMeshAgent agent;
    public Kirin kirin;
    public GameObject shouzhou;
    [SerializeField] ChildPrefabMaker childPrefabMaker;
    Animator animator;
    Slot slot;
    public float dis;
    [SerializeField] Sprite childGold;

    [SerializeField] PopupText popupText;
    public AudioClip sound1;
    AudioSource audioSource;
    [SerializeField] PopupTextUseItem popupTextUseItem;

    public enum State
    {
        Follow,
        Straying,
        BiteDistance,
    }
    //[SerializeField] State state; 
    public State state;

    enum KirinDirection
    {
        Right,
        Left,
        Up,
        Down,
        Stay,
    }
    Coroutine coroutine;
    WaitForSeconds checkWait = new WaitForSeconds(0.2f);
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Start()
    {
        
        coroutine = StartCoroutine(LoopGame());
        StartCoroutine(CheckDis());

    }
    IEnumerator CheckDis()
    {
        while (true)
        {
            yield return checkWait;
            dis = Vector3.Distance(shouzhou.transform.position, agent.transform.position);

            if (state == State.Straying && dis < 5)
            {
                StopCoroutine(coroutine);
                coroutine = null;
                Debug.Log("近づいた");
                coroutine = StartCoroutine(LoopGame());
            }
        }
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
        dis = Vector3.Distance(targetPos, agentPos);

        if (dis >= 3 && dis < 8)
            { state = State.Follow; }
        else if (dis >= 8)
            { state = State.Straying; }
        else if (dis < 3)
            { state = State.BiteDistance; }
        //Debug.Log(dis);
    }

    
    //クリックしたときにオブジェクトのPosとtagを判定
      public bool BiteDisChildCheck(GameObject Child)
    {
        /* ターゲットのポジションを取得 
        targetPos = shouzhou.transform.position;

        /* プレイヤーのポジションを取得 */
        childPos = Child.transform.position;
         //ターゲットとプレイヤーの距離を取得
       float biteDis = Vector3.Distance(targetPos, childPos);
        if (biteDis < 3.5f)
        {
          return true;
        }
        else
        {
            return false;
        }
        
        }
        

        //クリックしたのが子供かどうか判定するため
     [SerializeField] GameObject clickedGameObject;
    [SerializeField] LayerMask layerMask;
   

    IEnumerator LoopGame()
      {
         while (true)
        {
          
            if (Input.GetMouseButtonDown(0))
            {

                clickedGameObject = null;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);


                if (hit2d)
                {
                    clickedGameObject = hit2d.transform.gameObject;
                    
                 if (clickedGameObject.tag == "Child" && state==State.BiteDistance) 
                    {
                        
                        bool isBiteDisChild = BiteDisChildCheck(clickedGameObject);
                        if (isBiteDisChild)
                        { 
                                                       
                            StartCoroutine(BiteSetPosition(clickedGameObject));

                            
                           
                            childPrefabMaker.MakeChild();
                        }
                        
                      
                    }
                }
            }

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
                    //Debug.Log(state);
                    break;

                case State.Straying:
                    StartCoroutine(SetRandomTargetPosition());
                    //Debug.Log("dis"+dis);
                    if (dis <5)
                    {
                        StopAllCoroutines();
                    }
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

        //targetPos = new Vector3(5,5);
        targetPos = new Vector3(UnityEngine.Random.Range(-15f, 15f), UnityEngine.Random.Range(-15f, 15f));
    }

    //Kirinアニメーションの向き
    private void SetAgentDirection()
    {

        float absX = Mathf.Abs(targetPos.x - agentPos.x);
        //Debug.Log("absX"+absX);
        float absY = Mathf.Abs(targetPos.y - agentPos.y);
        //Debug.Log("absY" + absY);
        if (absX - absY > 0)
        {

          
            if (targetPos.x > agentPos.x)
            {
                //kirinDirection = KirinDirection.Right;
                SetBoolRight();
                //Debug.Log(KirinDirection.Right);
            }
            else
            {
               // kirinDirection = KirinDirection.Left;
                SetBoolLeft();
                //Debug.Log(KirinDirection.Left);
            }
        }

        if (absX - absY < 0)
        {
                if (targetPos.y > agentPos.y)
                {
                   // kirinDirection = KirinDirection.Up;
                    SetBoolUp();
                    //Debug.Log(KirinDirection.Up);
                }
                if(targetPos.y < agentPos.y)
                {
                   // kirinDirection = KirinDirection.Down;
                SetBoolDown();
                    //Debug.Log(KirinDirection.Down);
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


    public void StopRunTime()
    {
        StopAllCoroutines();
    }
    IEnumerator BiteSetPosition(GameObject clickedGameObject)
    {
        SpriteRenderer s = clickedGameObject.GetComponent<SpriteRenderer>();
        Debug.Log(s.sprite);
        s.tag = "GoldChild";

        //clickedGameObject(子供)の座標を取得して、横に移動する
        Vector3 childPosi = clickedGameObject.transform.position;
         childPosi.x += 2;
        
        yield return transform.DOMove(new Vector3(childPosi.x+0.2f,childPosi.y),0.35f).WaitForCompletion();
        //

        animator.SetTrigger("Bite");
        yield return new WaitForSeconds(0.5f);
        s.sprite = childGold;
        
        kirin.bitePoints = kirin.bitePoints + 1;
        kirin.hp += 5;

        popupText.transform.position = transform.position;
        popupText.StartPopup(1);
        audioSource.PlayOneShot(sound1);
        popupTextUseItem.StartPopupUseItem(5);

    }



}
