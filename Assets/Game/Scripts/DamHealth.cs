using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamHealth : MonoBehaviour {
	[SerializeField] private List<SandBagArea> m_SandBagAreas;
	[SerializeField] private float m_OriginalDamHealth = 20;
	private float m_DamHealth;
	private Renderer m_Material;

	// Use this for initialization
	void Start () {
		m_DamHealth = m_OriginalDamHealth;
		m_Material = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (m_DamHealth < m_OriginalDamHealth && m_DamHealth >= 5)
		{
			m_Material.material.color = Color.blue;
		}
		else if (m_DamHealth <= 5)
		{
			m_Material.material.color = Color.red;
		}
	}

	public void TakeDamage(float damage)
	{
		for (int i = 0; i < m_SandBagAreas.Count; i++)
		{
			if (m_SandBagAreas[i].m_Full == true)
			{
				m_SandBagAreas[i].m_SandBagHealth.TakeDamage(damage);
				damage = 0;
			}
		}
		m_DamHealth -= damage;
	}
}
