using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SandProgress : MonoBehaviour {
	[SerializeField] private SpawnerBlock m_Spawner;
	[SerializeField] private Slider m_Slider;
	// Use this for initialization
	void Start () {
		m_Slider.maxValue = m_Spawner.m_ValueNeededForSpawn;
		m_Slider.value = m_Spawner.m_RespawnValue;
	}
	
	// Update is called once per frame
	void Update () {
		m_Slider.value = m_Spawner.m_RespawnValue;
	}
}
