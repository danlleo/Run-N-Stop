using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Spline))]
public class SplineEditor : Editor
{
    private bool _closedLoop;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GUILayout.Space(20);
        GUIStyle headerStyle = new GUIStyle(GUI.skin.label);

        headerStyle.fontSize = 20;
        headerStyle.fontStyle = FontStyle.Bold;
        headerStyle.alignment = TextAnchor.UpperLeft;

        GUILayout.Label("Actions", headerStyle);
        GUILayout.Space(5);

        if (GUILayout.Button("Add Bezier Curve"))
        {
            Spline spline = (Spline)target;

            spline.AddBezierCurve();
        }

        if (GUILayout.Button("Remove Bezier Curve"))
        {
            Spline spline = (Spline)target;

            spline.RemoveBezierCurve();
        }

        GUILayout.Space(20);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        _closedLoop = GUILayout.Toggle(_closedLoop, "Closed Loop");

        GUILayout.EndHorizontal();
    }
}
