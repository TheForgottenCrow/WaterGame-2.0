using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBagSpawner : MonoBehaviour {
	[SerializeField] private GameObject m_SandBag;
	[SerializeField] private float m_ValueNeededForSpawn;
	[SerializeField] private float m_RespawnValue;
	[SerializeField] private List<Transform> m_SpawnLocations;
	[SerializeField] private int m_SandbagsOnStart;
	private int m_SandbagsSpawned = 0;
	private float m_SandInput;
	private bool m_Interupted;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < m_SandbagsOnStart; i++)
		{
			GameObject sandBag = Instantiate(m_SandBag);
			Transform sandBagTransform = sandBag.GetComponent<Transform>();
			sandBagTransform.transform.position = m_SpawnLocations[m_SandbagsSpawned].transform.position;
			m_SandbagsSpawned++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(m_Interupted == true)
		{
			m_RespawnValue += m_SandInput;
		}

		if(m_RespawnValue >= m_ValueNeededForSpawn)
		{
			Instantiate(m_SandBag, m_SpawnLocations[m_SandbagsSpawned]);
			m_SandbagsSpawned++;
		}
	}
}
