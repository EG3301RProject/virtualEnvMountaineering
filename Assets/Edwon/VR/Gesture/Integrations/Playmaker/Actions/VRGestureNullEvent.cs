#if PLAYMAKER

using UnityEngine;
using Edwon.VR.Gesture;

namespace HutongGames.PlayMaker.Actions
{

    [ActionCategory("VR Infinite Gesture")]
    [Tooltip ("Fires when a gesture is captured but can't be recognized fromt the Edwon VR Gesture Tracker plugin")]
    public class VRGestureNullEvent : FsmStateAction
    {
        public FsmEvent gestureNullEvent;

        // Code that runs on entering the state.
        public override void OnEnter()
	    {
            GestureRecognizer.GestureRejectedEvent += OnGestureNull;
        }

	    // Code that runs when exiting the state.
	    public override void OnExit()
	    {
            GestureRecognizer.GestureRejectedEvent -= OnGestureNull;
        }

        void OnGestureNull (string error, string gestureName = null, double confidenceValue = 0)
        {
            Fsm.Event(gestureNullEvent);
        }
    }

}

#endif