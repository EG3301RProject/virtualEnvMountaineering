#if PLAYMAKER

using UnityEngine;
using Edwon.VR.Gesture;
using Edwon.VR;

namespace HutongGames.PlayMaker.Actions
{

    [ActionCategory("VR Infinite Gesture")]
    [Tooltip ("Listens for gestures detected with the Edwon VR Gesture Tracker plugin")]
    public class VRGestureDetectedEvent : FsmStateAction
    {
        [Tooltip("name of the gesture to listen for")]
        public FsmString gestureName;
        [Tooltip("if all the gesture conditions are met, this is the FSM event that will be fired")]
        public FsmEvent gestureDetectedEvent;
        [Tooltip("only fire the FSM event if both hands performed the double handed gesture. NOTE: if the gesture is a double handed gesture and this is unchecked, the event will fir even if you only did the gesture with one hand")]
        public FsmBool checkDoubleHanded;
        [Tooltip("check whether the left or right hand is the one that did the gesture before firing the FSM event")]
        public FsmBool checkLeftOrRightHand;
        [Tooltip("only send the FSM event if this hand did the gesture")]
        public Handedness handToCheck;

        // Code that runs on entering the state.
        public override void OnEnter()
	    {
            GestureRecognizer.GestureDetectedEvent += OnGestureDetected;
        }

	    // Code that runs when exiting the state.
	    public override void OnExit()
	    {
            GestureRecognizer.GestureDetectedEvent -= OnGestureDetected;
        }

        void OnGestureDetected (string _gestureName, double _confidence, Handedness _hand, bool _isDoubleHanded)
        {
            if (_gestureName == gestureName.Value)
            {
                if (checkDoubleHanded.Value == true)
                {
                    if (_isDoubleHanded == true)
                    {
                        Fsm.Event(gestureDetectedEvent);
                    }
                }
                else if (checkLeftOrRightHand.Value == true)
                { 
                    if (_hand == handToCheck)
                    {
                        Fsm.Event(gestureDetectedEvent);
                    }
                }
                else
                {
                    Fsm.Event(gestureDetectedEvent);
                }
            }
        }
    }

}

#endif