using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    Image image;

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




}
