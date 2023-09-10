using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Kirin : MonoBehaviour
{
    [SerializeField] PickupObj pickupObj;
    
    public float hp;
    public float bitePoints;
    public static Kirin instance;
    public float foodStock;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }

    }

    void Start()
    {
        pickupObj.Eat = Heal;
       
        //hp = 10;
        bitePoints = 0;
        StartCoroutine(KirinHP());
        
    }

    
    IEnumerator KirinHP()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            hp -= 1;
            yield return null;
        }
    }
    public void Heal() 
    {
        hp += 100;
    }




}
