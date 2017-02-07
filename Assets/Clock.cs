using UnityEngine;
using System.Collections;
using System;

public class Clock : MonoBehaviour
{
	public GameObject hourHand;
	public GameObject minuteHand;
	public GameObject secondHand;

	void Update()
	{
		// Fetch the current time from system.
		DateTime time = DateTime.Now;

		// Set the seconds hand root.
		int seconds = time.Second;

		// map seconds (0,60) to a rotation (0, 360)
		float seconds_normalized = seconds / 60f;
		float seconds_degrees = seconds_normalized * 360f;
		float clockwise_seconds = 360f - seconds_degrees;
			
		// { x, y, z }
		Vector3 secondsRotation = new Vector3(0f, 0f, clockwise_seconds);
		Quaternion secondsRotationQuat = Quaternion.Euler(secondsRotation);
		secondHand.transform.rotation = secondsRotationQuat;


	}
}
