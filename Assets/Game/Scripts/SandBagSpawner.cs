using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBagSpawner : MonoBehaviour {
	[SerializeField] private GameObject m_SandBag;
	[SerializeField] private float m_ValueNeededForSpawn;
	[SerializeField] private float m_RespawnValue;
	private float m_SandInput;
	private bool m_Interupted;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		while(m_Interupted == true)
		{
			m_RespawnValue += m_SandInput;
		}
	}
}
