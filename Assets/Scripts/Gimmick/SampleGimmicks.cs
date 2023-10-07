using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleGimmicks : MonoBehaviour
{
    [SerializeField] Kirin kirin;
    [SerializeField] GameObject player;
    [SerializeField] GameObject kirinObject;
    [SerializeField] PopupTextUseItem popupTextUseItem;
    public Sound sound;
    [SerializeField] GameObject TextShoukan;
    Transform kirinTransform;
    
    public void Awake()
    {
        kirinTransform = kirinObject.GetComponent<Transform>();
    }
    

    public void OnClickObj()
    {

        Item.Type useItemType =ItemBox.instance.TryUseItem();
        if (useItemType == Item.Type.Nashi)
        {
            Debug.Log("useItemType == Nashi");
            ItemBox.instance.ClearUseItem();
            kirin.hp += 5;
            popupTextUseItem.StartPopupUseItem(5);
            sound.PickSound();

            ItemGenerater.instance.MakeNashi();

        }
        else if (useItemType == Item.Type.Kani)
        {
            Debug.Log("useItemType == Kani");
            ItemBox.instance.ClearUseItem();
            kirin.hp += 10;
            popupTextUseItem.StartPopupUseItem(10);
            sound.PickSound();
        }
        else if (useItemType == Item.Type.Washi)
        {
            Debug.Log("useItemType == Washi");
            ItemBox.instance.ClearUseItem();



            Vector3 playerPositon = player.transform.position;
            Debug.Log("playerPosition"+playerPositon);
           
            Debug.Log("kirinPosition" + kirin.transform.position);

           
            kirinTransform.transform.position = playerPositon;
            //kirin.hp += 5;
            //popupTextUseItem.StartPopupUseItem(5);
            sound.PickSound();
        }
        else
        {
            Debug.Log("useItemType == ?");
        }

        //選択したスロットのsourceimageをBackgroundに変更する
    
    }

   


}
