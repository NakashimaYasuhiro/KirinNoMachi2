using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObj : MonoBehaviour
{
    [SerializeField] Item.Type itemType;
    Item item;
    [SerializeField] Parameter parameter;


    private void Start()
    {
        //itemType‚É‰‚¶‚Äitem‚ğ¶¬‚·‚é
        item = ItemGenerater.instance.Spawn(itemType);
    }
    public void OnClickObj()
    {
       
        //ItemBox.instance.SetItem(item);
        gameObject.SetActive(false);
        parameter.hp += 500;
    }
}
