using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBagArea : MonoBehaviour {
	public bool m_Full;
	public SandBag m_InSandBag;
	public SandBagHealth m_SandBagHealth;

	private void Update()
	{
		if (m_Full == true && m_InSandBag.m_PickedUp == false)
		{
			m_InSandBag.gameObject.transform.position = transform.position;
		}
		if (m_Full)
		{
			if (m_SandBagHealth.WhatsMyHealth() <= 0)
			{
				Destroy(m_InSandBag.gameObject);
				m_InSandBag = null;
				m_Full = false;
			}
		}
	}

	private void OnTriggerStay(Collider collision)
	{
		if (collision.gameObject.CompareTag("SandBag"))
		{
			if(m_Full == false) {
				m_InSandBag = collision.gameObject.GetComponent<SandBag>();
				m_SandBagHealth = collision.gameObject.GetComponent<SandBagHealth>();
				if (m_InSandBag.m_PickedUp == false)
				{
					m_Full = true;
				}
			}
		}
	}
	private void OnTriggerExit(Collider collision)
	{
		if (collision.gameObject.CompareTag("SandBag"))
		{
			if (m_Full == true)
			{
				m_InSandBag = null;
				m_SandBagHealth = null;
				m_Full = false;
			}
		}
	}
}
