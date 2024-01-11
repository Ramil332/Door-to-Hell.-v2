// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky

using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

namespace UnityStandardAssets.CrossPlatformInput
{
    public static class InputManager
    {
        private static VirtualInput virtualInput;


        static InputManager()
        {
#if MOBILE_INPUT
            virtualInput = new MobileInput ();
#else
            virtualInput = new StandaloneInput();
#endif
        }

        public static bool AxisExists(string name)
        {
            return virtualInput.AxisExists(name);
        }

        public static bool ButtonExists(string name)
        {
            return virtualInput.ButtonExists(name);
        }

        public static void RegisterVirtualAxis(VirtualAxis axis)
        {
            virtualInput.RegisterVirtualAxis(axis);
        }


        public static void RegisterVirtualButton(VirtualButton button)
        {
            virtualInput.RegisterVirtualButton(button);
        }


        public static void UnRegisterVirtualAxis(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            virtualInput.UnRegisterVirtualAxis(name);
        }


        public static void UnRegisterVirtualButton(string name)
        {
            virtualInput.UnRegisterVirtualButton(name);
        }


        public static VirtualAxis VirtualAxisReference(string name)
        {
            return virtualInput.VirtualAxisReference(name);
        }


        public static float GetAxis(string name)
        {
            return GetAxis(name, false);
        }


        public static float GetAxisRaw(string name)
        {
            return GetAxis(name, true);
        }

        private static float GetAxis(string name, bool raw)
        {
            return virtualInput.GetAxis(name, raw);
        }

        public static bool GetButton(string name)
        {
            return virtualInput.GetButton(name);
        }


        public static bool GetButtonDown(string name)
        {
            return virtualInput.GetButtonDown(name);
        }


        public static bool GetButtonUp(string name)
        {
            return virtualInput.GetButtonUp(name);
        }


        public static void SetButtonDown(string name)
        {
            virtualInput.SetButtonDown(name);
        }


        public static void SetButtonUp(string name)
        {
            virtualInput.SetButtonUp(name);
        }


        public static void SetAxisPositive(string name)
        {
            virtualInput.SetAxisPositive(name);
        }


        public static void SetAxisNegative(string name)
        {
            virtualInput.SetAxisNegative(name);
        }


        public static void SetAxisZero(string name)
        {
            virtualInput.SetAxisZero(name);
        }


        public static void SetAxis(string name, float value)
        {
            virtualInput.SetAxis(name, value);
        }


        public static Vector3 mousePosition
        {
            get { return virtualInput.MousePosition(); }
        }


        public static void SetVirtualMousePositionX(float f)
        {
            virtualInput.SetVirtualMousePositionX(f);
        }


        public static void SetVirtualMousePositionY(float f)
        {
            virtualInput.SetVirtualMousePositionY(f);
        }


        public static void SetVirtualMousePositionZ(float f)
        {
            virtualInput.SetVirtualMousePositionZ(f);
        }

        public class VirtualAxis
        {
            public string name { get; private set; }
            private float m_Value;
            public bool matchWithInputManager { get; private set; }


            public VirtualAxis(string name) : this(name, true)
            {
            }


            public VirtualAxis(string name, bool matchToInputSettings)
            {
                this.name = name;
                matchWithInputManager = matchToInputSettings;
            }

            public void Remove()
            {
                UnRegisterVirtualAxis(name);
            }

            public void Update(float value)
            {
                m_Value = value;
            }


            public float GetValue
            {
                get { return m_Value; }
            }


            public float GetValueRaw
            {
                get { return m_Value; }
            }
        }
        public class VirtualButton
        {
            public string name { get; private set; }
            public bool matchWithInputManager { get; private set; }

            private int m_LastPressedFrame = -5;
            private int m_ReleasedFrame = -5;
            private bool m_Pressed;


            public VirtualButton(string name) : this(name, true)
            {
            }


            public VirtualButton(string name, bool matchToInputSettings)
            {
                this.name = name;
                matchWithInputManager = matchToInputSettings;
            }

            public void Pressed()
            {
                if (m_Pressed)
                {
                    return;
                }
                m_Pressed = true;
                m_LastPressedFrame = Time.frameCount;
            }
            public void Released()
            {
                m_Pressed = false;
                m_ReleasedFrame = Time.frameCount;
            }

            public void Remove()
            {
                UnRegisterVirtualButton(name);
            }

            public bool GetButton
            {
                get { return m_Pressed; }
            }


            public bool GetButtonDown
            {
                get
                {
                    return m_LastPressedFrame - Time.frameCount == -1;
                }
            }


            public bool GetButtonUp
            {
                get
                {
                    return (m_ReleasedFrame == Time.frameCount - 1);
                }
            }
        }
    }
}
