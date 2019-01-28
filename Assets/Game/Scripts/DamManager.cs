using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class DamManager : MonoBehaviour {
	[SerializeField] List<DamHealth> m_Dams;
	[SerializeField] private float m_MinDamage;
	[SerializeField] private float m_MaxDamage;
	[SerializeField] private float m_OriginalTimer;
	[SerializeField] private float m_CurrentGameTimer;
	[SerializeField] private TextMeshProUGUI m_TimerText;

	private float m_Timer;
	// Use this for initialization
	void Start () {
		m_Timer = m_OriginalTimer;
	}
	
	// Update is called once per frame
	void Update () {
		m_Timer -= Time.deltaTime;
		m_CurrentGameTimer = m_CurrentGameTimer -Time.deltaTime;
		m_TimerText.text = Mathf.Round(m_CurrentGameTimer).ToString();
		if(m_CurrentGameTimer <= 0)
		{
			SceneManager.LoadScene("VictoryScene");
		}
		if(m_Timer <= 0)
		{
			SomeoneTakeTheDamage(Random.Range(m_MinDamage, m_MaxDamage));
			m_Timer = m_OriginalTimer;
		}
	}

	private void SomeoneTakeTheDamage(float damage)
	{
		int theOneToTakeTheDamage = Random.Range(0, m_Dams.Count);
		m_Dams[theOneToTakeTheDamage].TakeDamage(damage);
	}
}
