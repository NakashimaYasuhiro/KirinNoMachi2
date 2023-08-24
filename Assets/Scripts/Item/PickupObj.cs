using System.Collections;
using System.Collections.Generic;
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
        //itemTypeÇ…âûÇ∂ÇƒitemÇê∂ê¨Ç∑ÇÈ
        item = ItemGenerater.instance.Spawn(itemType);
    }
    public void OnClickObj()
    {
       
        if (gameObject.tag == "Food")
        {
            
            ItemBox.instance.SetItem(item);
        }
        else if(gameObject.tag == "Washi")
        {
            Debug.Log("washiÇ≈Ç∑");
            ItemBox.instance.SetItem(item);
        }
       
        
        gameObject.SetActive(false);
        //kirin.hp += 500;
        //Eat?.Invoke();
    }


}
