using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Parameter:MonoBehaviour
{
    [SerializeField] Text stomachText;
    [SerializeField] Text bitePointsText;
    [SerializeField] Kirin kirin;
    
      
    void Start()
    {
        //kirin.hp = 1000f;


         stomachText.text = kirin.hp.ToString();
         bitePointsText.text = kirin.bitePoints.ToString();
        //StartCoroutine(TimeLoop());
    }

    private void Update()
    {
        stomachText.text = kirin.hp.ToString(); 
        bitePointsText.text = kirin.bitePoints.ToString();
    }

    /*
    IEnumerator TimeLoop()
    {
        while (true)
        {
           
            stomachText.text = kirin.hp.ToString();
            yield return null;
            
        }

    }
    */

}
