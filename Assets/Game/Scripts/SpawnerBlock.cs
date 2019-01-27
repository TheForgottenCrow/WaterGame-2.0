using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBlock : MonoBehaviour {
	public int m_SandBagsInCrate;

	[SerializeField] private GameObject m_SandBag;
	[SerializeField] private float m_SandInput;
	public float m_ValueNeededForSpawn;
	public float m_RespawnValue;
	

	
	public bool m_Interupted;

	void Update()
	{
        m_Interupted = ThreadWork.interrupted;
		if (m_Interupted == true)
		{
			m_RespawnValue += m_SandInput;
		}

		if (m_RespawnValue >= m_ValueNeededForSpawn)
		{
			m_SandBagsInCrate++;
			m_RespawnValue = 0;	
		}
	}

	public SandBag TakeFromCrate(Transform playerTransform)
	{
		if(m_SandBagsInCrate > 0)
		{
			m_SandBagsInCrate--;
			SandBag sandBag = Instantiate(m_SandBag, playerTransform).GetComponent<SandBag>();
			return sandBag;
		}
		return null;
	}
}
