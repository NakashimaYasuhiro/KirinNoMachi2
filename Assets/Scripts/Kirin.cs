using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kirin : MonoBehaviour
{
    [SerializeField] PickupObj pickupObj;
    public float hp;
    // Start is called before the first frame update
    
    
    void Start()
    {
        pickupObj.Eat = Heal; 
        hp = 100;
    }

    /*
    IEnumerator KirinHP()
    {
        while (true)
        {

            hp = -1;
            yield return null;
        }
    }
    */

    public void Heal() 
    {
        hp += 100;
    }

}
