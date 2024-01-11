// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky

using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class InputAxisScrollbar : MonoBehaviour
    {
        public string axis;

	    void Update() { }

	    public void HandleInput(float value)
        {
            InputManager.SetAxis(axis, (value*2f) - 1f);
        }
    }
}
