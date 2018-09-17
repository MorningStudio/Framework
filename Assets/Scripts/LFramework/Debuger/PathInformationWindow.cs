using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace LFramework
{
    internal sealed class PathInformationWindow : ScrollableDebuggerWindowBase
    {
        protected override void OnDrawScrollableWindow()
        {
            GUILayout.Label("<b>Path Information</b>");
            GUILayout.BeginVertical("box");
            {
                DrawItem("Data Path:", Application.dataPath);
                DrawItem("Persistent Data Path:", Application.persistentDataPath);
                DrawItem("Streaming Assets Path:", Application.streamingAssetsPath);
                DrawItem("Temporary Cache Path:", Application.temporaryCachePath);
            }
            GUILayout.EndVertical();
        }
    }
}
