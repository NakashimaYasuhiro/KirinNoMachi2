using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChildMovement : MonoBehaviour
{
    private Vector3 targetpos;

   
    private void Start()
    {
        targetpos = transform.position;
        //StartCoroutine(ChildMoveH());
    }

    private void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time)*2.0f + targetpos.x, targetpos.y, targetpos.z);
        //StartCoroutine(ChildMoveH());
    }

    /*
    IEnumerator ChildMoveH()
    {
        
        yield return transform.DOMove(new Vector3(0.001f, 0), 0.1f).WaitForCompletion();
        yield return new WaitForSeconds(0.5f);
        yield return transform.DOMove(new Vector3(-0.001f, 0), 0.11f).WaitForCompletion();
    }
    */
    
    

}
