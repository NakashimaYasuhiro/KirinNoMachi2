using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupObj : MonoBehaviour
{
    [SerializeField] Item.Type item = default;
    
    //Item item;
    public UnityAction Eat;
    //[SerializeField] Kirin kirin;


    private void Start()
    {
        //itemTypeに応じてitemを生成する
        //item = ItemGenerater.instance.Spawn(itemType);
    }
    public void OnClickObj()
    {
        Debug.Log("OnClickObj");
        
        //ItemBox.instance.SetItem(item);
        gameObject.SetActive(false);
        //kirin.hp += 500;
        //Eat?.Invoke();
    }


}
