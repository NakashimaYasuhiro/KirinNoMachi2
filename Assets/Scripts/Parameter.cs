using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Parameter:MonoBehaviour
{
    [SerializeField] GameObject Stomach; 
    public float hp;
    [SerializeField] GameObject circle;
      
    void Start()
    {
        hp = 1000f;
        
        Stomach.GetComponent<Text>().text = hp.ToString();
       
    }

    private void Update()
    {
        hp = hp-1;
        Stomach.GetComponent<Text>().text = hp.ToString();

        
    }


}
