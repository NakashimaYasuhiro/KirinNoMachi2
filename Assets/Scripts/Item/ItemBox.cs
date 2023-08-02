using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemBox : MonoBehaviour
{
    [SerializeField] Slot slot0;   
    public static ItemBox instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    
    }

    //PickupObj���N���b�N���ꂽ��A�X���b�g�ɃA�C�e��������
    public void SetItem(Item item)
    {
        slot0.SetItem(item);
        Debug.Log(item);
    }
}
