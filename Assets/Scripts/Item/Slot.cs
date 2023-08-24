using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image;
    Item item;
    ItemListEntity itemListEntity;
    [SerializeField] GameObject backgroundPanel;
    Sprite defaultSprite;

    private void Awake()
    {
       // image = GetComponent<Image>();
        

    }
    private void Start()
    {
          backgroundPanel.SetActive(false);
          defaultSprite = image.sprite;
    }

    public bool IsEmpty()
    {
        if (item == null)
        {
            return true;
        }
        return false;
    }

    //ƒAƒCƒeƒ€‚ðŽó‚¯Žæ‚Á‚½‚ç‰æ‘œ‚ðŽæ“¾
    public void SetItem(Item item)
    {
        this.item = item;
        
        UpdateImage(item);
    }

    public Item GetItem()
    {
        return item;
    }

    void UpdateImage(Item item) 
    {
        if (item == null)
        {
            image.sprite = defaultSprite;
        }
        else
        {
            Debug.Log(item);
            image.sprite = item.sprite;
        }

    }

    public bool OnSelected()
    {
        if (item == null)
        {
            return false;
        }

        backgroundPanel.SetActive(true);
        return true;
    }

    public void HideBGPanel()
    {
        backgroundPanel.SetActive(false);
    }

}
