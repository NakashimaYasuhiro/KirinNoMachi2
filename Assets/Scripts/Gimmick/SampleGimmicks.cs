using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleGimmicks : MonoBehaviour
{
    [SerializeField] Kirin kirin;
    public void OnClickObj()
    {

        
        bool clear =ItemBox.instance.TryUseItem();
        if (clear == true)
        {
            Debug.Log("clear == true");
            ItemBox.instance.ClearUseItem();
            kirin.hp += 50;

        }
        else
        {
            Debug.Log("clear == false");
        }

        //�I�������X���b�g��sourceimage��Background�ɕύX����
    
    }
   

}
