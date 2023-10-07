using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerater : MonoBehaviour
{
    [SerializeField] ItemListEntity itemListEntity;

    public static ItemGenerater instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    public Item Spawn(Item.Type type)
    {
        //type�ƈ�v����item�𐶐����ēn��
        foreach(Item item in itemListEntity.itemList)
        {
            if (item.type == type)
            {
                return new Item(item.type, item.sprite);
            }
        }
        return null;
    }

    public void MakeNashi()
    {
        // �v���n�u��GameObject�^�Ŏ擾
        GameObject obj = (GameObject)Resources.Load("Food(Nashi)");
        //float pos1= (Random.value * 10.0f);
        // �v���n�u�����ɁA�C���X�^���X�𐶐��A
        float i1 = Random.Range(-20, 25), i2 = Random.Range(-20, 25);
        Instantiate(obj, new Vector3(i1, i2, 0.0f), Quaternion.identity);
        
        //Vector3 pos1 = pos[i1], pos2 = pos[i2];  //pos1��pos2��n�Ԗڂ̍��W������
          
        //int i3 = Random.Range(0, 2); //i4 = Random.Range(0, 1);
        //GameObject obj = images[i3]; //obj2 = images[i4];

        //Instantiate(obj, pos1, Quaternion.identity);
        //Debug.Log("pos1" + i1);
        
        //Instantiate(obj2, pos2, Quaternion.identity);
    }
}
