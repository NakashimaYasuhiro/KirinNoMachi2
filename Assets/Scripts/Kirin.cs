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
