using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBagGrabber : MonoBehaviour {
	[SerializeField] private KeyCode m_Interact;
	public bool m_CurrentlyHolding;
	private Transform m_SandBagPosition;
	private BoxCollider m_SandBagCollider;
	private SandBag m_SandBagHolding;

	private void Update()
	{
		if(m_CurrentlyHolding == true)
		{
			m_SandBagPosition.position = transform.position;
			
		}
	}


	private void OnTriggerStay(Collider collision)
	{
		if (collision.gameObject.CompareTag("SandBag"))
		{
			m_SandBagHolding = collision.gameObject.GetComponent<SandBag>();

			if (Input.GetKeyDown(m_Interact) && m_SandBagHolding.m_PickedUp == false && m_CurrentlyHolding == false)
			{
				m_SandBagPosition = collision.gameObject.GetComponent<Transform>();
				m_SandBagPosition.parent = transform.parent;
				m_SandBagCollider = m_SandBagPosition.GetComponent<BoxCollider>();
				m_SandBagCollider.isTrigger = false;
				m_SandBagHolding.m_PickedUp = true;
				m_CurrentlyHolding = true;
			}
			else if (Input.GetKeyDown(m_Interact) && m_SandBagHolding.m_PickedUp == true && m_CurrentlyHolding == true)
			{
				m_SandBagHolding.m_PickedUp = false;
				m_CurrentlyHolding = false;
				m_SandBagCollider.isTrigger = true;
				m_SandBagPosition.parent = null;
				m_SandBagPosition = null;
				m_SandBagCollider = null;
				m_SandBagHolding = null;
			}
		}
		else if (collision.gameObject.CompareTag("SpawnerCrate"))
		{
			SpawnerBlock sandBagSpawner = collision.gameObject.GetComponent<SpawnerBlock>();

			if (Input.GetKeyDown(m_Interact) &&  m_CurrentlyHolding == false && sandBagSpawner.m_SandBagsInCrate > 0)
			{
				Transform playerTransform = this.GetComponent<Transform>();
				m_SandBagHolding = sandBagSpawner.TakeFromCrate(playerTransform);
				m_SandBagPosition = m_SandBagHolding.gameObject.GetComponent<Transform>();
				m_SandBagPosition.parent = transform.parent;
				m_SandBagCollider = m_SandBagPosition.GetComponent<BoxCollider>();
				m_SandBagCollider.isTrigger = false;
				m_SandBagHolding.m_PickedUp = true;
				m_CurrentlyHolding = true;
			}
		}
	}
}
