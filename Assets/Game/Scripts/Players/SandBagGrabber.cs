using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBagGrabber : MonoBehaviour {
	[SerializeField] private KeyCode m_Interact;
	public bool m_CurrentlyHolding;
	private Transform m_SandBagPosition;
	private BoxCollider m_SandBagCollider;
	public SandBag m_SandBagHolding;

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
					m_SandBagPosition = collision.gameObject.GetComponent<Transform>();
					m_SandBagPosition.parent = transform.parent;
					m_SandBagCollider = m_SandBagPosition.GetComponent<BoxCollider>();
					m_SandBagCollider.isTrigger = true;
					m_SandBagHolding.m_PickedUp = true;
					m_CurrentlyHolding = true;
				}
				else if (m_SandBagHolding != null)
				{
					if (m_SandBagHolding.m_PickedUp == true && m_CurrentlyHolding == true)
					{
						m_SandBagHolding.m_PickedUp = false;
						m_CurrentlyHolding = false;
						m_SandBagCollider.isTrigger = false;
						m_SandBagPosition.parent = null;
						m_SandBagPosition = null;
						m_SandBagCollider = null;
						m_SandBagHolding = null;
					}
				}
			}
		}
		if (collision.gameObject.CompareTag("SpawnerCrate") && m_SandBagHolding == null)
		{
			SpawnerBlock sandBagSpawner = collision.gameObject.GetComponent<SpawnerBlock>();

			if (m_CurrentlyHolding == false && sandBagSpawner.m_SandBagsInCrate > 0)
			{
				m_SandBagHolding = sandBagSpawner.TakeFromCrate(transform);
				m_SandBagPosition = m_SandBagHolding.gameObject.GetComponent<Transform>();
				m_SandBagPosition.parent = transform.parent;
				m_SandBagCollider = m_SandBagPosition.GetComponent<BoxCollider>();
				m_SandBagCollider.isTrigger = true;
				m_SandBagHolding.m_PickedUp = true;
				m_CurrentlyHolding = true;
			}
		}
	}
}
