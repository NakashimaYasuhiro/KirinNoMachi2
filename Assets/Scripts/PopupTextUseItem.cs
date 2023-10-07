using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PopupTextUseItem : MonoBehaviour
{
   // public GameObject UseItem;
    Text textUseItem;
    //private Vector3 itemUIPosition;
    public GameObject player;


    private void Awake()
    {
        textUseItem = GetComponent<Text>();
        
       
        gameObject.SetActive(false);
    }
    public void StartPopupUseItem(int textItemValue)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = player.gameObject.transform.position;
        //gameObject.transform.position = initialPosition;
        StopAllCoroutines();
        StartCoroutine(PopupCol(textItemValue));
    }
    
    IEnumerator PopupCol(int textItemValue)
    {
        
        textUseItem.text = "‚¨‚È‚©+" + textItemValue;
        yield return transform.DOMoveY(1f, 0.3f).SetRelative().WaitForCompletion();
        yield return new WaitForSeconds(0.5f);

        textUseItem.gameObject.SetActive(false);
    }
}
