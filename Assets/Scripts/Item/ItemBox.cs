using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.Progress;


public class ItemBox : MonoBehaviour
{
    [SerializeField] Slot[] slots;   
    public static ItemBox instance;
    [SerializeField] Slot selectedSlot = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            slots = GetComponentsInChildren<Slot>();
        }
    
    }

    //PickupObjがクリックされたら、スロットにアイテムを入れる
    public void SetItem(Item item)
    {
        foreach (Slot slot in slots)
        {
            if (slot.IsEmpty())
            {
                
                slot.SetItem(item);
                break;
            }
        }

    }

    public void OnSelectSlot(int position)
    {
        foreach(Slot slot in slots)
        {
            slot.HideBGPanel();
        }

        if (slots[position].OnSelected()) 
        {
            selectedSlot = slots[position];
            //selectedSlot.gameObject.GetComponent<Image>();
            //selectedSlot.GetComponent<Image>();
            
        }  
        
        
    }
    public Item.Type TryUseItem()
    {
        //選択スロットがあるかどうか
        if (selectedSlot == null)
        {
            return Item.Type.None;
        }
        
            //Debug.Log("Item.Type.Food");
            return selectedSlot.GetItem().type;
        
        
           
    }

    public void ClearUseItem()
    {
        
        selectedSlot.SetItem(null);
        selectedSlot.HideBGPanel();
        selectedSlot =null;
        
    }
}
