// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Animator animator;
    void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Key"))
        {
            animator = GetComponent<Animator>();
            animator.SetBool("IsDoorOpen", true);
            Destroy(other.gameObject);
        }
    }
}
