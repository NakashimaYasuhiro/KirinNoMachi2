using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    Image image;
    Item item;
    ItemListEntity itemListEntity;

    private void Awake()
    {
        image = GetComponent<Image>();
        

    }

    //アイテムを受け取ったら画像を取得
    public void SetItem(Item item)
    {
        UpdateImage(item);
    }

    void UpdateImage(Item item) 
    {
        image.sprite = item.sprite;
    }

    public void SetGetItem(GameObject getobject)
    {
        if (getobject.tag == "Food")
        {
            Debug.Log(getobject.tag + "getobject.tag,"+getobject+"getobject");
            //string item = "Food";
            //int num = itemListEntity.itemList.Type.IndexOf(item);
        }
        //アイテムをListにする
        List<Item> getItemList = new List<Item>();
        getItemList.Add(item);
        for (int i = 0; i < getItemList.Count; i++)
        {
            Debug.Log(getItemList[i]);
        }
    }



}
