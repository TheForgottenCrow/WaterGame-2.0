using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBag : MonoBehaviour {
	[SerializeField] public bool m_PickedUp;
	public bool m_PlacedDown;
	private Rigidbody m_SandBagRigidBody;

	private void Start()
	{
		m_SandBagRigidBody = GetComponent<Rigidbody>();
	}
	private void Update()
	{
		m_SandBagRigidBody.velocity = Vector3.zero;
		m_SandBagRigidBody.angularVelocity = Vector3.zero;
	}
}
