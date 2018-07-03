#if PLAYMAKER

using UnityEngine;
using UnityEditor;
using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMakerEditor;
using Edwon.VR.Gesture;

[CustomActionEditor(typeof(VRGestureDetectedEvent))]
public class VRGestureDetectedEventEditor : CustomActionEditor
{
    public override void OnEnable()
    {
        // Do any expensive initialization stuff here.
        // This is called when the editor is created.
    }

    public override bool OnGUI()
    {
        var action = target as VRGestureDetectedEvent;

        var isDirty = true;

        GUILayout.Label("Gesture Conditions:", EditorStyles.boldLabel);

        EditField("gestureName");
        EditField("checkDoubleHanded");

        if (action.checkDoubleHanded.Value == false)
        {
            EditField("checkLeftOrRightHand");
            if (action.checkLeftOrRightHand.Value == true)
            {
                EditField("handToCheck");
            }
        }

        GUILayout.Label("FSM Event:", EditorStyles.boldLabel);
        EditField("gestureDetectedEvent");

        return isDirty || GUI.changed;
    }
}

#endif