using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridGenerator))]
public class GridGeneratorEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GridGenerator grid = (GridGenerator)target;

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Generate Grid"))
        {
            /*if (grid.Overwrite)
            {
                grid.overwriteGrid();
            }
            else
            {
                grid.generateGrid();
            }*/
            grid.overwriteGrid();
        }

        if(GUILayout.Button("Delete Grid"))
        {
            grid.deleteGrid();
        }
        EditorGUILayout.EndHorizontal();
    }
}
