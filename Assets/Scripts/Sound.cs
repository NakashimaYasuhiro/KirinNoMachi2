using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField]AudioSource audioSourcePick;
    [SerializeField] AudioClip clip1;
    public void PickSound()
    {
        audioSourcePick = GetComponent<AudioSource>();
        audioSourcePick.PlayOneShot(clip1);
    }

}
