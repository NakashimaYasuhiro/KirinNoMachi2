using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildPrefabMaker : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        // Cube�v���n�u��GameObject�^�Ŏ擾
        GameObject obj = (GameObject)Resources.Load("Child");
        // Cube�v���n�u�����ɁA�C���X�^���X�𐶐��A
        Instantiate(obj, new Vector3(0.0f, 2.0f, 0.0f), Quaternion.identity);
        
    }

    public void MakeChild()
    {  
        // Cube�v���n�u��GameObject�^�Ŏ擾
        GameObject obj = (GameObject)Resources.Load("Child");
        // Cube�v���n�u�����ɁA�C���X�^���X�𐶐��A
        //Instantiate(obj, new Vector3(1.0f, 1.0f, 0.0f), Quaternion.identity);
        int i1 = Random.Range(0, 20), i2 = Random.Range(0, 11);
        Vector3 pos1 = pos[i1], pos2 = pos[i2];  //pos1��pos2��n�Ԗڂ̍��W������

        int i3 = Random.Range(0, 2); //i4 = Random.Range(0, 1);
        //GameObject obj = images[i3]; //obj2 = images[i4];

       Instantiate(obj, pos1, Quaternion.identity);
        Debug.Log("pos1"+i1);
        Debug.Log(pos[i1]);
        //Instantiate(obj2, pos2, Quaternion.identity);
    }

    public List<Vector3> pos = new List<Vector3>();   //���߂�ꂽ10�̍��W
    public List<GameObject> images = new List<GameObject>();  //�摜���܂񂾃Q�[���I�u�W�F�N�g20��

    //Set()���Ăяo���ă����_���ɐݒu
  


}
