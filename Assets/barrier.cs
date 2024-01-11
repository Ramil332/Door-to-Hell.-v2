using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{
    public GameObject door;
    AudioSource close;

    private void Start()
    {
        door.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        door.SetActive(true);
        close.Play();
    }

}
