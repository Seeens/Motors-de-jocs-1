using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Projector : MonoBehaviour
{

	private Vector3 originPosition;
	private Vector3 directionCast;

	private RaycastHit _hit;
	private Projector _projector;

	void Start ()
	{
		_projector = GameObject.FindWithTag("Projector").GetComponent<Projector>();
		originPosition = GameObject.GetComponent<Transform>().position;
		directionCast = GetComponent<Transform>().forward;
	}

	void Update ()
	{
		Physics.Raycast(originPosition, directionCast, out _hit);

	}

}
