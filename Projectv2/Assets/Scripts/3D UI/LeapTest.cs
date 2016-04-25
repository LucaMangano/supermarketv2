using UnityEngine;
using System.Collections.Generic;
using Leap;

public class LeapTest : MonoBehaviour {

	Controller controller;
	void Start ()
	{
		controller = new Controller ();
	}

	void Update ()
	{
		
		Frame frame = controller.Frame (); // controller is a Controller object


//		if(frame.Hands.Count > 0)
//		{
//			List<Hand> hands = frame.Hands;
//			Hand firstHand = hands [0];
//			Hand secondHand = hands [1];
//		}
			//float grabAngle = Leap.Hand.GrabAngle;
			//if (grabAngle > 2.5) {
			//print ("Grab detected");
		}
	}



//	using UnityEngine;
//	using System.Collections;
//	using Leap;
//	using Leap.Unity;
//	
//	public class HandAccessor : MonoBehaviour {
//	
//		IHandModel hand_model;
//		Hand leap_hand;
//	
//		void Start() 
//		{
//			hand_model = GetComponent<IHandModel>();
//			leap_hand = hand_model.GetLeapHand();
//			if (leap_hand == null) Debug.LogError("No leap_hand founded");
//			else Debug.Log("Hand " + (leap_hand.IsLeft ? "left " : "right ") + "ID: " + leap_hand.Id);
//		}
	