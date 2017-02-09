using UnityEngine;
using System.Collections;
using System;

public class Clock : MonoBehaviour
{
	public GameObject hourHand;
	public GameObject minuteHand;
	public GameObject secondHand;

	// Comment goes here
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

		// temporary variable for minutes
		int minutes = time.Minute;
		// Construct an euler representation of minutes rotation
		Vector3 minutesEuler = new Vector3(0f, 0f, (1f - (minutes / 60f)) * 360f );
		// Convert minutes euler rotation to quaternion and assign to minute hand
		minuteHand.transform.rotation = Quaternion.Euler(minutesEuler);

		// Vector3.forward = new Vector3(0, 0, 1)

		// Set hour hand
		hourHand.transform.rotation = Quaternion.Euler(
			Vector3.forward * (1f - (time.Hour / 12f) * 360f) );
	}
}
