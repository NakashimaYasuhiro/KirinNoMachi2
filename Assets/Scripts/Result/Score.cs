using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text bitePoint;
    // Start is called before the first frame update
    void Start()
    {
       bitePoint = GetComponent<Text>();
        bitePoint.text = Kirin.instance.bitePoints.ToString();
        Debug.Log("bitePoint"+bitePoint.text);
       

    }

    // Update is called once per frame
    void Update()
    {
       
        //Debug.Log("bitePoints" + bitePoint);
    }
}
