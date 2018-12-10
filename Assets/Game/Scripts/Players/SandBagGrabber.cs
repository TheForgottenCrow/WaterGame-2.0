using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBagGrabber : MonoBehaviour {
	[SerializeField] private KeyCode m_Interact;
	public bool m_CurrentlyHolding;
	private Transform m_SandBagPosition;

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
			SandBag sandBag = collision.gameObject.GetComponent<SandBag>();

			if (Input.GetKeyDown(m_Interact) && sandBag.m_PickedUp == false && m_CurrentlyHolding == false)
			{
				Debug.Log("hi");
				Debug.Log(m_SandBagPosition);	
				m_SandBagPosition = collision.gameObject.GetComponent<Transform>();
				Debug.Log(m_SandBagPosition);
				sandBag.m_PickedUp = true;
				m_CurrentlyHolding = true;
			}
			else if (Input.GetKeyDown(m_Interact) && sandBag.m_PickedUp == true && m_CurrentlyHolding == true)
			{ 
				sandBag.m_PickedUp = false;
				m_CurrentlyHolding = false;
			}
		}
	}
}
