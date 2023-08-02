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

    //�A�C�e�����󂯎������摜���擾
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
        //�A�C�e����List�ɂ���
        List<Item> getItemList = new List<Item>();
        getItemList.Add(item);
        for (int i = 0; i < getItemList.Count; i++)
        {
            Debug.Log(getItemList[i]);
        }
    }



}
