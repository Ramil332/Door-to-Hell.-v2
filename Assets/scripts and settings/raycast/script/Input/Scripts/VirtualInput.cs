// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky

using System;
using System.Collections.Generic;
using UnityEngine;


namespace UnityStandardAssets.CrossPlatformInput
{
    public abstract class VirtualInput
    {
        public Vector3 virtualMousePosition { get; private set; }
        
        
        protected Dictionary<string, InputManager.VirtualAxis> m_VirtualAxes = new Dictionary<string, InputManager.VirtualAxis>();
        protected Dictionary<string, InputManager.VirtualButton> m_VirtualButtons = new Dictionary<string, InputManager.VirtualButton>();
        protected List<string> m_AlwaysUseVirtual = new List<string>();
        

        public bool AxisExists(string name)
        {
            return m_VirtualAxes.ContainsKey(name);
        }

        public bool ButtonExists(string name)
        {
            return m_VirtualButtons.ContainsKey(name);
        }


        public void RegisterVirtualAxis(InputManager.VirtualAxis axis)
        {
            if (m_VirtualAxes.ContainsKey(axis.name))
            {
                Debug.LogError("There is already a virtual axis named " + axis.name + " registered.");
            }
            else
            {
                m_VirtualAxes.Add(axis.name, axis);

                if (!axis.matchWithInputManager)
                {
                    m_AlwaysUseVirtual.Add(axis.name);
                }
            }
        }


        public void RegisterVirtualButton(InputManager.VirtualButton button)
        {
            if (m_VirtualButtons.ContainsKey(button.name))
            {
                Debug.LogError("There is already a virtual button named " + button.name + " registered.");
            }
            else
            {
                m_VirtualButtons.Add(button.name, button);
                if (!button.matchWithInputManager)
                {
                    m_AlwaysUseVirtual.Add(button.name);
                }
            }
        }


        public void UnRegisterVirtualAxis(string name)
        {
            if (m_VirtualAxes.ContainsKey(name))
            {
                m_VirtualAxes.Remove(name);
            }
        }


        public void UnRegisterVirtualButton(string name)
        {
            if (m_VirtualButtons.ContainsKey(name))
            {
                m_VirtualButtons.Remove(name);
            }
        }

        public InputManager.VirtualAxis VirtualAxisReference(string name)
        {
            return m_VirtualAxes.ContainsKey(name) ? m_VirtualAxes[name] : null;
        }


        public void SetVirtualMousePositionX(float f)
        {
            virtualMousePosition = new Vector3(f, virtualMousePosition.y, virtualMousePosition.z);
        }


        public void SetVirtualMousePositionY(float f)
        {
            virtualMousePosition = new Vector3(virtualMousePosition.x, f, virtualMousePosition.z);
        }


        public void SetVirtualMousePositionZ(float f)
        {
            virtualMousePosition = new Vector3(virtualMousePosition.x, virtualMousePosition.y, f);
        }


        public abstract float GetAxis(string name, bool raw);
        
        public abstract bool GetButton(string name);
        public abstract bool GetButtonDown(string name);
        public abstract bool GetButtonUp(string name);

        public abstract void SetButtonDown(string name);
        public abstract void SetButtonUp(string name);
        public abstract void SetAxisPositive(string name);
        public abstract void SetAxisNegative(string name);
        public abstract void SetAxisZero(string name);
        public abstract void SetAxis(string name, float value);
        public abstract Vector3 MousePosition();
    }
}
