// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky

using UnityEngine;

public class HideCursor : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
    }
}
