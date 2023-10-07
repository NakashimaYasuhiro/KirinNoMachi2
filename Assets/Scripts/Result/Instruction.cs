using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instruction : MonoBehaviour
{
    [SerializeField] GameObject InstructionPanel;

    private void Awake()
    {
        
    }

    public void ShowInstruction()
    {
        InstructionPanel.SetActive(true);
    }
    public void CloseInstruction()
    {
        InstructionPanel.SetActive(false);
    }
}
