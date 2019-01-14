using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamHealth : MonoBehaviour {
	[SerializeField] private List<SandBagArea> m_SandBagAreas;
	[SerializeField] private float m_OriginalDamHealth = 20;
	[SerializeField] private GameObject m_LeakS;
	[SerializeField] private GameObject m_LeakM;
	[SerializeField] private GameObject m_LeakL;
	public float m_DamHealth;
	private Renderer m_Material;

	// Use this for initialization
	void Start () {
		m_DamHealth = m_OriginalDamHealth;
		m_Material = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if (m_DamHealth < m_OriginalDamHealth - 5 && m_DamHealth >= m_OriginalDamHealth - 10)
		{
			m_LeakS.SetActive(true);
			m_LeakM.SetActive(false);
			m_LeakL.SetActive(false);
		}
		else if (m_DamHealth < m_OriginalDamHealth - 10 && m_DamHealth >= m_OriginalDamHealth - 15)
		{
			m_LeakS.SetActive(false);
			m_LeakM.SetActive(true);
			m_LeakL.SetActive(false);
		}
		else if (m_DamHealth < m_OriginalDamHealth - 15 && m_DamHealth >= m_OriginalDamHealth - 20)
		{
			m_LeakS.SetActive(false);
			m_LeakM.SetActive(false);
			m_LeakL.SetActive(true);
		}
		//if (m_DamHealth <= 0)
		//{
		//	for (int i = 0; i < m_SandBagAreas.Count; i++)
		//	{
		//		Destroy(m_SandBagAreas[i].gameObject);
		//	}
		//	Destroy(gameObject);
		//}
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
