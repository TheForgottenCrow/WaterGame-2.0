using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBagHealth : MonoBehaviour {
	private float m_OriginalSandBagHealth = 5;
	[SerializeField] private float m_SandBagHealth;
	private float m_FirstBreak = 3;
	private float m_SecondBreak = 1;
	private Renderer m_Material;
	private Color m_Orange;
	// Use this for initialization
	void Start () {
		m_Material = GetComponent<Renderer>();
		m_SandBagHealth = m_OriginalSandBagHealth;
		m_Orange = new Color(254, 157, 0);
	}
	
	// Update is called once per frame
	void Update () {
		TakeDamage(0);
	}

	public void TakeDamage(float Damage)
	{
		m_SandBagHealth -= Damage;
		
		if (m_SandBagHealth <= 0)
		{
			transform.position = new Vector3(20000, 20000, 20000);
		}
	}

	public float WhatsMyHealth()
	{
		return m_SandBagHealth;
	}
}
