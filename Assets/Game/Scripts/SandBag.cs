using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBag : MonoBehaviour {
	[SerializeField] public bool m_PickedUp;
	public bool m_PlacedDown;
	public bool m_BeingThrown;
	private Rigidbody m_SandBagRigidBody;


	private void Start()
	{
		m_SandBagRigidBody = GetComponent<Rigidbody>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		m_BeingThrown = false;
	}
}


