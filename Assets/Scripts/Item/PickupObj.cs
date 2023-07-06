using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupObj : MonoBehaviour
{
    [SerializeField] Item.Type itemType;
    Item item;
    public UnityAction Eat;
    //[SerializeField] Kirin kirin;


    private void Start()
    {
        //itemType‚É‰‚¶‚Äitem‚ğ¶¬‚·‚é
        item = ItemGenerater.instance.Spawn(itemType);
    }
    public void OnClickObj()
    {
       
        //ItemBox.instance.SetItem(item);
        gameObject.SetActive(false);
        //kirin.hp += 500;
        Eat?.Invoke();
    }


}
