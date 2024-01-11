// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) 
        {
            if (transform.parent != null) 
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Destroy(transform.parent.gameObject); 
            }
        }
    }
}
