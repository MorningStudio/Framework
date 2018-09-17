using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace LFramework
{
    internal sealed class SettingsWindow : ScrollableDebuggerWindowBase
    {
        private float m_LastIconX = 0f;
        private float m_LastIconY = 0f;
        private float m_LastWindowX = 0f;
        private float m_LastWindowY = 0f;
        private float m_LastWindowWidth = 0f;
        private float m_LastWindowHeight = 0f;
        private float m_LastWindowScale = 0f;

        public override void Initialize(params object[] args)
        {
            m_LastIconX = SettingManager.Instance.GetFloat("Debugger.Icon.X", DebugerManager.DefaultIconRect.x);
            m_LastIconY = SettingManager.Instance.GetFloat("Debugger.Icon.Y", DebugerManager.DefaultIconRect.y);
            m_LastWindowX = SettingManager.Instance.GetFloat("Debugger.Window.X", DebugerManager.DefaultWindowRect.x);
            m_LastWindowY = SettingManager.Instance.GetFloat("Debugger.Window.Y", DebugerManager.DefaultWindowRect.y);
            m_LastWindowWidth = SettingManager.Instance.GetFloat("Debugger.Window.Width", DebugerManager.DefaultWindowRect.width);
            m_LastWindowHeight = SettingManager.Instance.GetFloat("Debugger.Window.Height", DebugerManager.DefaultWindowRect.height);
            DebugerManager.Instance.WindowScale = m_LastWindowScale = SettingManager.Instance.GetFloat("Debugger.Window.Scale", DebugerManager.DefaultWindowScale);
            DebugerManager.Instance.IconRect = new Rect(m_LastIconX, m_LastIconY, DebugerManager.DefaultIconRect.width, DebugerManager.DefaultIconRect.height);
            DebugerManager.Instance.WindowRect = new Rect(m_LastWindowX, m_LastWindowY, m_LastWindowWidth, m_LastWindowHeight);
        }

        public override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            if (m_LastIconX != DebugerManager.Instance.IconRect.x)
            {
                m_LastIconX = DebugerManager.Instance.IconRect.x;
                SettingManager.Instance.SetFloat("Debugger.Icon.X", DebugerManager.Instance.IconRect.x);
            }

            if (m_LastIconY != DebugerManager.Instance.IconRect.y)
            {
                m_LastIconY = DebugerManager.Instance.IconRect.y;
                SettingManager.Instance.SetFloat("Debugger.Icon.Y", DebugerManager.Instance.IconRect.y);
            }

            if (m_LastWindowX != DebugerManager.Instance.WindowRect.x)
            {
                m_LastWindowX = DebugerManager.Instance.WindowRect.x;
                SettingManager.Instance.SetFloat("Debugger.Window.X", DebugerManager.Instance.WindowRect.x);
            }

            if (m_LastWindowY != DebugerManager.Instance.WindowRect.y)
            {
                m_LastWindowY = DebugerManager.Instance.WindowRect.y;
                SettingManager.Instance.SetFloat("Debugger.Window.Y", DebugerManager.Instance.WindowRect.y);
            }

            if (m_LastWindowWidth != DebugerManager.Instance.WindowRect.width)
            {
                m_LastWindowWidth = DebugerManager.Instance.WindowRect.width;
                SettingManager.Instance.SetFloat("Debugger.Window.Width", DebugerManager.Instance.WindowRect.width);
            }

            if (m_LastWindowHeight != DebugerManager.Instance.WindowRect.height)
            {
                m_LastWindowHeight = DebugerManager.Instance.WindowRect.height;
                SettingManager.Instance.SetFloat("Debugger.Window.Height", DebugerManager.Instance.WindowRect.height);
            }

            if (m_LastWindowScale != DebugerManager.Instance.WindowScale)
            {
                m_LastWindowScale = DebugerManager.Instance.WindowScale;
                SettingManager.Instance.SetFloat("Debugger.Window.Scale", DebugerManager.Instance.WindowScale);
            }
        }

        protected override void OnDrawScrollableWindow()
        {
            GUILayout.Label("<b>Window Settings</b>");
            GUILayout.BeginVertical("box");
            {
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Position:", GUILayout.Width(60f));
                    GUILayout.Label("Drag window caption to move position.");
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    float width = DebugerManager.Instance.WindowRect.width;
                    GUILayout.Label("Width:", GUILayout.Width(60f));
                    if (GUILayout.RepeatButton("-", GUILayout.Width(30f)))
                    {
                        width--;
                    }
                    width = GUILayout.HorizontalSlider(width, 100f, Screen.width - 20f);
                    if (GUILayout.RepeatButton("+", GUILayout.Width(30f)))
                    {
                        width++;
                    }
                    width = Mathf.Clamp(width, 100f, Screen.width - 20f);
                    if (width != DebugerManager.Instance.WindowRect.width)
                    {
                        DebugerManager.Instance.WindowRect = new Rect(DebugerManager.Instance.WindowRect.x, DebugerManager.Instance.WindowRect.y, width, DebugerManager.Instance.WindowRect.height);
                    }
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    float height = DebugerManager.Instance.WindowRect.height;
                    GUILayout.Label("Height:", GUILayout.Width(60f));
                    if (GUILayout.RepeatButton("-", GUILayout.Width(30f)))
                    {
                        height--;
                    }
                    height = GUILayout.HorizontalSlider(height, 100f, Screen.height - 20f);
                    if (GUILayout.RepeatButton("+", GUILayout.Width(30f)))
                    {
                        height++;
                    }
                    height = Mathf.Clamp(height, 100f, Screen.height - 20f);
                    if (height != DebugerManager.Instance.WindowRect.height)
                    {
                        DebugerManager.Instance.WindowRect = new Rect(DebugerManager.Instance.WindowRect.x, DebugerManager.Instance.WindowRect.y, DebugerManager.Instance.WindowRect.width, height);
                    }
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    float scale = DebugerManager.Instance.WindowScale;
                    GUILayout.Label("Scale:", GUILayout.Width(60f));
                    if (GUILayout.RepeatButton("-", GUILayout.Width(30f)))
                    {
                        scale -= 0.01f;
                    }
                    scale = GUILayout.HorizontalSlider(scale, 0.5f, 4f);
                    if (GUILayout.RepeatButton("+", GUILayout.Width(30f)))
                    {
                        scale += 0.01f;
                    }
                    scale = Mathf.Clamp(scale, 0.5f, 4f);
                    if (scale != DebugerManager.Instance.WindowScale)
                    {
                        DebugerManager.Instance.WindowScale = scale;
                    }
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    if (GUILayout.Button("0.5x", GUILayout.Height(60f)))
                    {
                        DebugerManager.Instance.WindowScale = 0.5f;
                    }
                    if (GUILayout.Button("1.0x", GUILayout.Height(60f)))
                    {
                        DebugerManager.Instance.WindowScale = 1f;
                    }
                    if (GUILayout.Button("1.5x", GUILayout.Height(60f)))
                    {
                        DebugerManager.Instance.WindowScale = 1.5f;
                    }
                    if (GUILayout.Button("2.0x", GUILayout.Height(60f)))
                    {
                        DebugerManager.Instance.WindowScale = 2f;
                    }
                    if (GUILayout.Button("2.5x", GUILayout.Height(60f)))
                    {
                        DebugerManager.Instance.WindowScale = 2.5f;
                    }
                    if (GUILayout.Button("3.0x", GUILayout.Height(60f)))
                    {
                        DebugerManager.Instance.WindowScale = 3f;
                    }
                    if (GUILayout.Button("3.5x", GUILayout.Height(60f)))
                    {
                        DebugerManager.Instance.WindowScale = 3.5f;
                    }
                    if (GUILayout.Button("4.0x", GUILayout.Height(60f)))
                    {
                        DebugerManager.Instance.WindowScale = 4f;
                    }
                }
                GUILayout.EndHorizontal();

                if (GUILayout.Button("Reset Window Settings", GUILayout.Height(30f)))
                {
                    DebugerManager.Instance.IconRect = DebugerManager.DefaultIconRect;
                    DebugerManager.Instance.WindowRect = DebugerManager.DefaultWindowRect;
                    DebugerManager.Instance.WindowScale = DebugerManager.DefaultWindowScale;
                }
            }
            GUILayout.EndVertical();
        }
    }
}
