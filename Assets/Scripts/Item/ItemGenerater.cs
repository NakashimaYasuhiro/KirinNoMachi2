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
        //typeと一致するitemを生成して渡す
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
        // プレハブをGameObject型で取得
        GameObject obj = (GameObject)Resources.Load("Food(Nashi)");
        //float pos1= (Random.value * 10.0f);
        // プレハブを元に、インスタンスを生成、
        float i1 = Random.Range(-20, 25), i2 = Random.Range(-20, 25);
        Instantiate(obj, new Vector3(i1, i2, 0.0f), Quaternion.identity);
        
        //Vector3 pos1 = pos[i1], pos2 = pos[i2];  //pos1とpos2にn番目の座標を入れる
          
        //int i3 = Random.Range(0, 2); //i4 = Random.Range(0, 1);
        //GameObject obj = images[i3]; //obj2 = images[i4];

        //Instantiate(obj, pos1, Quaternion.identity);
        //Debug.Log("pos1" + i1);
        
        //Instantiate(obj2, pos2, Quaternion.identity);
    }
}
