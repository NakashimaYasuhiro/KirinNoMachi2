using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Parameter:MonoBehaviour
{
    [SerializeField] Text stomachText;
    [SerializeField] Kirin kirin;
    
      
    void Start()
    {
        //kirin.hp = 1000f;


         stomachText.text = kirin.hp.ToString();
        StartCoroutine(TimeLoop());
    }

    private void Update()
    {

    }

    IEnumerator TimeLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);//KirinÇ…Ç‡ÇΩÇπÇÈÅB
            --kirin.hp;//KirinÇ…Ç‡ÇΩÇπÇÈÅB
            stomachText.text = kirin.hp.ToString();
            //yield return null;
            
        }

    }

}
