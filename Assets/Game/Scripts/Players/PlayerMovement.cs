using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField] private float m_Speed;
	[SerializeField] private float m_TurnSpeed;
	[SerializeField] private KeyCode m_TopKey;
	[SerializeField] private KeyCode m_Leftkey;
	[SerializeField] private KeyCode m_RightKey;
	[SerializeField] private KeyCode m_BottomKey;

	private Quaternion StartRotation;
	private Vector3 m_NewPosition;
	private Transform m_PlayerTransform;
	private Rigidbody m_PlayerRigidBody;


	private Vector3 direction;

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
			m_NewPosition.z  = m_PlayerTransform.position.z + (m_Speed * Time.deltaTime);
		}
		else if (Input.GetKey(m_BottomKey))
		{
			m_NewPosition.z  = m_PlayerTransform.position.z - (m_Speed * Time.deltaTime);
		}
		if (Input.GetKey(m_RightKey))
		{
			m_NewPosition.x = m_PlayerTransform.position.x + (m_Speed * Time.deltaTime);
		}
		else if (Input.GetKey(m_Leftkey))
		{
			m_NewPosition.x = m_PlayerTransform.position.x - (m_Speed * Time.deltaTime);
		}

		if(Input.GetKey(m_TopKey) || Input.GetKey(m_BottomKey) || Input.GetKey(m_RightKey) || Input.GetKey(m_Leftkey))
		{
			direction = m_NewPosition - transform.position ;
			Vector3 newDir = Vector3.RotateTowards(m_PlayerTransform.forward, direction, m_TurnSpeed * Time.deltaTime, 0.0f);
			m_PlayerTransform.rotation = Quaternion.LookRotation(newDir);
		}


		m_NewPosition.y = m_PlayerTransform.position.y;
		//StartRotation = m_PlayerTransform.rotation;
		//transform. =  Vector3.Slerp(m_PlayerTransform.forward, m_NewPosition.normalized, m_TurnSpeed * Time.deltaTime);
		//Debug.Log(transform.forward);
		m_PlayerRigidBody.MovePosition(m_NewPosition);
	}
}
