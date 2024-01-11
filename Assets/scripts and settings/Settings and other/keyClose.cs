// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyClose : MonoBehaviour
{
    public Animator animator;
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            animator.SetBool("IsDoorOpen", false);
        }
    }
}
