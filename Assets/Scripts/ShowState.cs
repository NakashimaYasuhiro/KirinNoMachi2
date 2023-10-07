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
            text.text = "���Ă���";
        }
        else if (agentMovement.state == AgentMovement.State.Straying)
        {
            text.text = "������";
        }
        else if(agentMovement.state == AgentMovement.State.BiteDistance)
       
        {
                text.text = "�߂�";
        }
           
   
        

    }



}
