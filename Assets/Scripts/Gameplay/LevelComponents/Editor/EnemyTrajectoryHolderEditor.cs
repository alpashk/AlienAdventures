using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Gameplay.LevelComponents.Editor
{
    [CustomEditor(typeof(EnemyTrajectoryHolder))]
    public class EnemyTrajectoryHolderEditor : UnityEditor.Editor
    {
        private EnemyTrajectoryHolder targetObject;
        void OnEnable()
        {
            targetObject = (EnemyTrajectoryHolder) serializedObject.targetObject;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("GenerateTrajectory"))
            {
                List<Vector3> list = targetObject.MovementTargets;
                list.Clear();
                foreach (Transform child in targetObject.transform)
                {
                    list.Add(child.position);
                }
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}