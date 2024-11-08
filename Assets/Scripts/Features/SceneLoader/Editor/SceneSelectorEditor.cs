using UnityEngine;
using UnityEditor;
using Assets.Scripts.Features.SceneLoader;

[CustomEditor(typeof(SceneSelector))]
public class SceneSelectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var sceneSelector = (SceneSelector)target;

        sceneSelector.SceneAsset = EditorGUILayout.ObjectField("Scene", sceneSelector.SceneAsset, typeof(SceneAsset), false) as SceneAsset;

        if (sceneSelector.SceneAsset != null)
        {
            sceneSelector.SceneName = sceneSelector.SceneAsset.name;
        }

        EditorGUILayout.LabelField("Scene Name", sceneSelector.SceneName);

        if (GUI.changed)
            EditorUtility.SetDirty(sceneSelector);
    }
}