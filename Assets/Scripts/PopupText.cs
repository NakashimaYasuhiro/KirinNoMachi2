using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PopupText : MonoBehaviour
{
    Text textBite;
    Text textEat;
    private void Awake()
    {
        textBite = GetComponentInChildren<Text>();
        textBite.gameObject.SetActive(false);
    }
    public void StartPopup(int textValue)
    {
        StopAllCoroutines();
        StartCoroutine(PopupCol(textValue));
    }
    
    IEnumerator PopupCol(int textValue)
    {
        textBite.gameObject.SetActive(true);
        textBite.text = "+" + textValue + "‚©‚Ý";
        yield return transform.DOMoveY(0.1f, 0.3f).WaitForCompletion();
        yield return new WaitForSeconds(0.5f);
        textBite.gameObject.SetActive(false);
    }
}
