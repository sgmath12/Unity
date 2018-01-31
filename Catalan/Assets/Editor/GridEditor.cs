using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridScript)), CanEditMultipleObjects]
public class FreeMoveHandleExampleEditor : Editor
{
	protected virtual void OnSceneGUI()
	{
		GridScript example=(GridScript) target;

		float size = HandleUtility.GetHandleSize(example.transform.position) * 0.5f;
		Vector3 snap = Vector3.one * 0.5f;

		Handles.color = Color.yellow;

		EditorGUI.BeginChangeCheck();
		Vector3 NewPosition = Handles.FreeMoveHandle(example.transform.position, 
			Quaternion.identity, size, snap, 
			Handles.RectangleHandleCap);

		Handles.color = Color.red;


		Vector3 EndTargetPosition = Handles.FreeMoveHandle(example.EndPosition, 
			Quaternion.identity, size, snap, 
			Handles.RectangleHandleCap);
		


		if (EditorGUI.EndChangeCheck())
		{
			Undo.RecordObject(example, "Change Look At Target Position");
			example.transform.position = NewPosition;
			example.EndPosition = EndTargetPosition;
		}
	}
}
