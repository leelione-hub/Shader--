using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;

public class FirstWindow:EditorWindow
{
    public Cubemap cubemap;
    public Transform targetPos;

    FirstWindow()
    {
        this.titleContent = new GUIContent("Create CubeMap");
    }

    [MenuItem("Tools/CraeteCubeMap")]
    static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(FirstWindow));
    }

    void OnGUI()
    {
        GUILayout.Space(10);
        GUI.skin.label.fontSize = 24;
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUILayout.Label("Create CubeMap");

        GUILayout.Space(20);
        cubemap = (Cubemap)EditorGUILayout.ObjectField("CubeMap", cubemap, typeof(Cubemap), true);
        targetPos = (Transform)EditorGUILayout.ObjectField("TargetPos", targetPos, typeof(Transform), true);

        GUILayout.Space(50);
        if (GUILayout.Button("Render"))
        {
            Render();
        }
    }

    void Render()
    {
        GameObject go = new GameObject("CubeMapCamera");
        go.AddComponent<Camera>();
        go.transform.position = targetPos.position;
        go.GetComponent<Camera>().RenderToCubemap(cubemap);
        DestroyImmediate(go);
    }
}
