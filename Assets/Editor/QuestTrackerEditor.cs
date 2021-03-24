using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(QuestTracker))]
    public class QuestTrackerEditor : UnityEditor.Editor
    {
        private string title;
        private string description;
        private string objective;
        private int quantity;
        public QuestData source;

        public override void OnInspectorGUI()
        {
            base.DrawDefaultInspector();
        
            QuestTracker tracker = (QuestTracker)target;
            GUILayout.Space(20f);
            GUILayout.Label("Add a Quest");
        
            GUILayout.BeginHorizontal();
            GUILayout.Label("Quest Source");
            source = EditorGUILayout.ObjectField(source, typeof(QuestData), true) as QuestData;
            GUILayout.EndHorizontal();
            
            if (GUILayout.Button("Save")) //8
            {
                // description = source.questDescription;
                // objective = source.questObjective;
                // quantity = source.objQuantity;
                tracker.AddQuest(source);
            }
        }
    }
}
