using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leduDoor : MonoBehaviour
{
    public Animator animator;
    public AudioSource laugh;

    bool isSound = true;
    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("istrigger", true);

        if (isSound)
            laugh.Play();
        isSound = false;

    }
}

