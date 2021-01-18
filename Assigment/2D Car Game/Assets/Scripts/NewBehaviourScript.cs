using UnityEngine;
using UnityEditor;


public class NewBehaviourScriptEditor : Editor
{

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Choose", GUILayout.Width(70), GUILayout.Height(20)))
        {
            string filepath = EditorUtility.OpenFilePanelWithFilters("Choose", "", new string[] { "CSharp", "cs" });
            Debug.Log("filepath is " + filepath);
            EditorUtility.DisplayProgressBar("Processing..", "Shows a progress", 0.2f);
            System.Threading.Thread.Sleep(8000);
            EditorUtility.ClearProgressBar();
            EditorUtility.DisplayDialog("Message", "Success.", "Ok");
            GUIUtility.ExitGUI();
        }
    }
}
