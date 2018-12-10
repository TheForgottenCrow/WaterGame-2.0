using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField] private float m_speed;
	[SerializeField] private KeyCode m_TopKey;
	[SerializeField] private KeyCode m_Leftkey;
	[SerializeField] private KeyCode m_RightKey;
	[SerializeField] private KeyCode m_BottomKey;

	private Vector3 m_NewPosition;
	private Transform m_PlayerTransform;
	private Rigidbody m_PlayerRigidBody;
	// Use this for initialization
	void Start () {
		m_PlayerTransform = GetComponent<Transform>();
		m_PlayerRigidBody = GetComponent<Rigidbody>();
		m_NewPosition = m_PlayerTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(m_TopKey))
		{
			m_NewPosition.z  = m_PlayerTransform.position.z + (m_speed * Time.deltaTime);
		}
		else if (Input.GetKey(m_BottomKey))
		{
			m_NewPosition.z  = m_PlayerTransform.position.z - (m_speed * Time.deltaTime);
		}
		if (Input.GetKey(m_RightKey))
		{
			m_NewPosition.x = m_PlayerTransform.position.x + (m_speed * Time.deltaTime);
		}
		else if (Input.GetKey(m_Leftkey))
		{
			m_NewPosition.x = m_PlayerTransform.position.x - (m_speed * Time.deltaTime);
		}
		m_NewPosition.y = m_PlayerTransform.position.y;
		m_PlayerTransform.LookAt(m_NewPosition);
		m_PlayerRigidBody.MovePosition(m_NewPosition);
	}
}
