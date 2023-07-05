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

    //ƒAƒCƒeƒ€‚ðŽó‚¯Žæ‚Á‚½‚ç‰æ‘œ‚ðŽæ“¾
    public void SetItem(Item item)
    {
        UpdateImage(item);
    }

    void UpdateImage(Item item) 
    {
        image.sprite = item.sprite;
    }




}
