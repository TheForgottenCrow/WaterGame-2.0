using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBagGrabber : MonoBehaviour {
	[SerializeField] private KeyCode m_Interact;
	[SerializeField] private KeyCode m_ThrowKey;
	[SerializeField] private float m_ForwardForce;
	[SerializeField] private float m_UpWardForce;
	public bool m_CurrentlyHolding;
	private Transform m_SandBagPosition;
	private BoxCollider m_SandBagCollider;
	private Rigidbody m_Rigidbody;
	public SandBag m_SandBagHolding;

	private SandBag m_SandBagIThrew;

	private void Update()
	{
		if(m_CurrentlyHolding == true)
		{
			m_SandBagPosition.position = transform.position;
			
		}
	}


	private void OnTriggerStay(Collider collision)
	{
		if (Input.GetKeyDown(m_Interact))
		{
			if (collision.gameObject.CompareTag("SandBag"))
			{
				m_SandBagHolding = collision.gameObject.GetComponent<SandBag>();

				if (m_SandBagHolding.m_PickedUp == false && m_CurrentlyHolding == false)
				{
					PickUp();
				}
				else if (m_SandBagHolding != null)
				{
					if (m_SandBagHolding.m_PickedUp == true && m_CurrentlyHolding == true)
					{
						LetGo();
					}
				}
			}
		}
		else if(m_CurrentlyHolding == false && collision.gameObject.CompareTag("SandBag") && collision.GetComponent<SandBag>().m_BeingThrown == true)
		{
			m_SandBagHolding = collision.gameObject.GetComponent<SandBag>();
			if(m_SandBagHolding != m_SandBagIThrew)
			{
				PickUp();
			}
			else
			{
				m_SandBagHolding = null;
			}
		}
		else if (Input.GetKeyDown(m_ThrowKey) && m_SandBagHolding != null)
		{
			m_Rigidbody.velocity = Vector3.zero;
			m_Rigidbody.angularVelocity = Vector3.zero;
			m_Rigidbody.AddForce(transform.forward * m_ForwardForce, ForceMode.Impulse);
			m_Rigidbody.AddForce(transform.up * m_UpWardForce, ForceMode.Impulse);
			m_SandBagHolding.m_BeingThrown = true;
			m_SandBagIThrew = m_SandBagHolding;
			LetGo();
			
		}
		if (collision.gameObject.CompareTag("SpawnerCrate") && m_SandBagHolding == null)
		{
			SpawnerBlock sandBagSpawner = collision.gameObject.GetComponent<SpawnerBlock>();

			if (m_CurrentlyHolding == false && sandBagSpawner.m_SandBagsInCrate > 0)
			{
				m_SandBagHolding = sandBagSpawner.TakeFromCrate(transform);
				PickUp();
			}
		}
	}

	private void PickUp()
	{
		m_Rigidbody = m_SandBagHolding.GetComponent<Rigidbody>();
		m_SandBagPosition = m_SandBagHolding.GetComponent<Transform>();
		m_SandBagPosition.parent = transform.parent;
		m_SandBagCollider = m_SandBagPosition.GetComponent<BoxCollider>();
		m_SandBagCollider.isTrigger = true;
		m_SandBagHolding.m_PickedUp = true;
		m_CurrentlyHolding = true;
		m_Rigidbody.useGravity = false;
		m_Rigidbody.velocity = Vector3.zero;
		m_Rigidbody.angularVelocity = Vector3.zero;
	}

	private void LetGo()
	{
		m_CurrentlyHolding = false;
		m_SandBagHolding.m_PickedUp = false;
		m_SandBagCollider.isTrigger = false;
		m_Rigidbody.useGravity = true;
		m_SandBagPosition.parent = null;
		m_SandBagPosition = null;
		m_SandBagCollider = null;
		m_SandBagHolding = null;
		m_Rigidbody = null;
	}

	private void OnTriggerExit(Collider other)
	{
		if (m_SandBagIThrew != null)
		{
			if (other.gameObject == m_SandBagIThrew.gameObject)
			{
				m_SandBagIThrew = null;
			}
		}
	}
}
