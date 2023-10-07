using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PickupObj : MonoBehaviour
{
    [SerializeField] Item.Type itemType = default;
    //[SerializeField] Item item = default;

    Item item;
    public UnityAction Eat;
    //[SerializeField] Kirin kirin;


    private void Start()
    {
        //itemTypeに応じてitemを生成する
        item = ItemGenerater.instance.Spawn(itemType);
        
    }
    public void OnClickObj()
    {
       
        if (gameObject.tag == "Nashi")
        {
            
            ItemBox.instance.SetItem(item);
            Debug.Log("nashiです");

        }
        else if(gameObject.tag == "Kani")
        {
            Debug.Log("kaniです");
            ItemBox.instance.SetItem(item);
        }
        else if (gameObject.tag == "Washi")
        {
            Debug.Log("washiです");
            ItemBox.instance.SetItem(item);
        }


        gameObject.SetActive(false);
        //kirin.hp += 500;
        //Eat?.Invoke();
    }


}
