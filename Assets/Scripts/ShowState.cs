using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowState : MonoBehaviour
{
    public AgentMovement agentMovement;
    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }
    void Start()
    {
        

    }

    private void Update()
    {
        if (agentMovement.state == AgentMovement.State.Follow)
        {
            text.text = "ついていく";
        }
        else if (agentMovement.state == AgentMovement.State.Straying)
        {
            text.text = "迷い中";
        }
        else if(agentMovement.state == AgentMovement.State.BiteDistance)
       
        {
                text.text = "近い";
        }
           
   
        

    }



}
