using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(GameEvent))]
public class GameEventEditor : Editor
{
    private List<bool> _feedbacksFoldout;
    private SerializedProperty _feedbacks;
    private Type[] _types;
    private string[] _typesStr;
    private int _dragStartID = -1;
    private int _dragEndID = -1;

    private void OnEnable()
    {
       
        _feedbacksFoldout = new List<bool>();
        _feedbacks = serializedObject.FindProperty("Feedbacks");

        for (int i = 0; i < _feedbacks.arraySize; i++)
        {
            _feedbacksFoldout.Add(false);
            
        }

        List<string> types = new List<string>();
        types.Add("Add new feedback");

        List<System.Type> gameEventTypes = (from domainAssembly in System.AppDomain.CurrentDomain.GetAssemblies()
            from assemblyType in domainAssembly.GetTypes()
            where assemblyType.IsSubclassOf(typeof(GameFeedback))
            select assemblyType).ToList();

        _types = gameEventTypes.ToArray();

        foreach (var item in gameEventTypes)
        {
            types.Add(item.ToString());
        }

        _typesStr = types.ToArray();
    }

    public override void OnInspectorGUI()
    {
        int controlId = GUIUtility.GetControlID(FocusType.Passive);
        serializedObject.Update();

        GameEvent gameEvent = target as GameEvent;
        

        int newItem = EditorGUILayout.Popup(0, _typesStr) -1;
        if (newItem >= 0)
        {
            GameFeedback newFeedBack = Activator.CreateInstance(_types[newItem]) as GameFeedback;

            Undo.RecordObject(gameEvent,"Add feedback");
            EditorUtility.SetDirty(gameEvent);
            gameEvent.Feedbacks.Add(newFeedBack);
            _feedbacksFoldout.Add(false);
        }
        
        for (int i = 0; i < _feedbacks.arraySize; i++)
        {
           

            SerializedProperty property = _feedbacks.GetArrayElementAtIndex(i) ;
            
            Rect horizontal = EditorGUILayout.BeginHorizontal();

            string tmp = property.managedReferenceFullTypename;
            string type = tmp.Split(' ')[1];

            Rect backgroundRect = GUILayoutUtility.GetRect(5f, 17f);
            float offset = 4f;
            backgroundRect.xMax = 5;
            backgroundRect.xMin = 0;
            Rect foldoutRect = backgroundRect;
            foldoutRect.xMin += offset;
            foldoutRect.width = 300;
            foldoutRect.height = 17;
            
            if(type.Equals("InstantiateFeedback")) EditorGUI.DrawRect(backgroundRect,Color.green);
            if(type.Equals("WaitFeedback")) EditorGUI.DrawRect(backgroundRect,Color.white);

            _feedbacksFoldout[i] = GUI.Toggle(foldoutRect, _feedbacksFoldout[i], gameEvent.Feedbacks[i].ToString(),EditorStyles.foldout);


            
            int indexRemove = -1;
            if (GUILayout.Button("-", EditorStyles.miniButton,
                GUILayout.Width(EditorStyles.miniButton.CalcSize(new GUIContent("-")).x)))
            {
                indexRemove = i;
            }
            
          
            EditorGUILayout.EndHorizontal();
            
            if (_feedbacksFoldout[i])
            {
                foreach (var item in GetChildren(property))
                {
                    EditorGUILayout.PropertyField(item);
                }
            }
            
            if (indexRemove != -1)
            {
                _feedbacks.DeleteArrayElementAtIndex(indexRemove);
                _feedbacksFoldout.RemoveAt(indexRemove);
            }

            var line = GUILayoutUtility.GetRect(1f, 1f);
            EditorGUI.DrawRect(line,Color.black);
            
            // DRAG --------------------------------------------------------------
            var eventCurrent = Event.current;
            if (eventCurrent.type == EventType.MouseDown)
            {
                
                GUIUtility.hotControl = controlId;
                
                if (horizontal.Contains(eventCurrent.mousePosition))
                {
                    _dragStartID = i;
                        _dragEndID = i;
                        eventCurrent.Use();
                }
                
                
            }
            
            if (horizontal.Contains(eventCurrent.mousePosition))
            {
                if (_dragStartID >= 0)
                {
                    _dragEndID = i;

                    Rect headerSplit = horizontal;
                    headerSplit.height *= 0.5f;
                    headerSplit.y += headerSplit.height;
                    if (headerSplit.Contains(eventCurrent.mousePosition)) _dragEndID = i + 1;
                }
            }

            if (_dragStartID == i)
            {
                Color color = new Color(0, 1, 0, 0.3f);
                EditorGUI.DrawRect(horizontal,color);
            }

            if (_dragStartID >= 0 && _dragEndID >= 0)
            {
                if (_dragEndID != _dragStartID)
                {
                    if (_dragEndID > _dragStartID) _dragEndID--;
                    _feedbacks.MoveArrayElement(_dragStartID, _dragEndID);
                    (_feedbacksFoldout[_dragStartID], _feedbacksFoldout[_dragEndID]) = (_feedbacksFoldout[_dragEndID], _feedbacksFoldout[_dragStartID]);
                    _dragStartID = _dragEndID;
                }
            }

            if (eventCurrent.type == EventType.MouseUp)
            {
                if (_dragStartID >= 0 || _dragEndID >= 0)
                {
                    _dragStartID = -1;
                    _dragEndID = -1;
                    eventCurrent.Use();
                }
            }
            
            

        }

        serializedObject.ApplyModifiedProperties();
    }

    public IEnumerable<SerializedProperty> GetChildren(SerializedProperty serializedProperty)
    {
        SerializedProperty currentProperty = serializedProperty.Copy();
        SerializedProperty nextSiblingProperty = serializedProperty.Copy();
        {
            nextSiblingProperty.Next(false);
        }

        if (currentProperty.Next(true))
        {
            do
            {
                if (SerializedProperty.EqualContents(currentProperty, nextSiblingProperty)) break;

                yield return currentProperty;
            } while (currentProperty.Next(false));
        }
    }
}
