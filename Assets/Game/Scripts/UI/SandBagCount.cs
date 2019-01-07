using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SandBagCount : MonoBehaviour {
	[SerializeField] private SpawnerBlock m_Spawner;
	[SerializeField] private TextMeshProUGUI m_Text;
	// Use this for initialization
	void Start()
	{
		m_Text.text = m_Spawner.m_SandBagsInCrate.ToString();
	}
	
	void Update()
	{
		m_Text.text = m_Spawner.m_SandBagsInCrate.ToString();
	}
}
