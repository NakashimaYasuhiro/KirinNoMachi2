using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] LayerMask solidObjectsLayer;
    [SerializeField] LayerMask encountLayer;
    

   // [SerializeField] GameController gameController;
   
    

    Animator animator;
    bool isMoving;
    public bool enCountStop = false;

    

    private void Awake()
    {
        
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        
    }
    void Update()
    {
        if (enCountStop == false)
        {
            if (isMoving == false)
            {
                float x = Input.GetAxisRaw("Horizontal");
                float y = Input.GetAxisRaw("Vertical");

                if (x != 0)
                {
                    y = 0;
                }

                if (x != 0 || y != 0)
                {
                    animator.SetFloat("InputX", x);
                    animator.SetFloat("InputY", y);

                    //transform.position += new Vector3(x, y);
                    StartCoroutine(Move(new Vector2(x, y)));
                }

            }
        }

        animator.SetBool("IsMoving", isMoving);
        
    }

    IEnumerator Move(Vector3 direction)
    {   
        isMoving = true;
        Vector3 targetPos = transform.position + direction;
        if (IsWalkable(targetPos) == false) 
        {
            isMoving = false;
            yield break;
        }
        while ((targetPos -transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 5f*Time.deltaTime);
            yield return null; //new waitsecond 
        }
        transform.position = targetPos;
        isMoving = false;

        CheckForEncounts();
    }

    void CheckForEncounts()
    {
        //移動した地点に、敵がいるか判断する
        Collider2D encount = Physics2D.OverlapCircle(transform.position, 0.2f, encountLayer);
               
    }

    bool IsWalkable(Vector3 targetPos)
    {
        return Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) == false;
    }


    public void SetDirection()
    {
        animator.SetFloat("InputX", 0);
        animator.SetFloat("InputY", -1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        // foodに衝突したら自オブジェクト削除
        if (collision.gameObject.tag == "Food")
        {
            Debug.Log("Hit");
            Destroy(collision.gameObject);
        }
    }



}
