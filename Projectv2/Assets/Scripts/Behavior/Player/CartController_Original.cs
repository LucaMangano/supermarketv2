﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CartController_Original : MonoBehaviour
{
	public AnimationCurve RotationSpeedCurve;
	public Rigidbody RigidB;

	[SerializeField]
	private float _movementSpeed = 0.0f;

	public float MaxSpeed = 5.0f;
	public float MaxAcceleration = 2.0f;

	private float _deceleration = 0.1f;

	public float RotationSpeed = 20.0f;


	void Start()
	{

	}
	void Update()
	{
		var pos = transform.localPosition;
		pos.y = 0.58f;
		transform.localPosition = pos;
		transform.localRotation = Quaternion.Euler(0.0f, transform.localRotation.eulerAngles.y, 0.0f);

		_movementSpeed *= 1.0f - ((Time.deltaTime * 0.7f) * RotationSpeedCurve.Evaluate(Mathf.Abs(_movementSpeed) / MaxSpeed));

		_movementSpeed += MaxAcceleration * (Input.GetAxis("Acceleration") - Input.GetAxis("Deceleration") + Input.GetAxis("Vertical")) * Time.deltaTime;
		_movementSpeed = Mathf.Clamp(_movementSpeed, -MaxSpeed / 2.0f, MaxSpeed);

		transform.Rotate(Vector3.down, -Input.GetAxis("Horizontal") * RotationSpeed * Time.deltaTime * RotationSpeedCurve.Evaluate(Mathf.Abs(_movementSpeed) / MaxSpeed));

		RigidB.velocity = transform.localRotation * Vector3.forward * _movementSpeed;
		RigidB.angularVelocity = Vector3.zero;
	}
		
}
