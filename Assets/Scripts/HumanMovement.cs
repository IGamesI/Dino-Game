using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HumanMovement : MonoBehaviour
{
	#region Variables
	float _speed = 0f;
	[SerializeField] float _jumpForce;
	[SerializeField] LayerMask _groundLayer;
	[SerializeField] ScoreHandler _scoreHandler;
	Rigidbody2D _rigidBody;
	BoxCollider2D _boxCollider;
	bool _isGrounded;

	bool _isDead;
	#endregion

	#region UnityFunctions
	void Start()
	{
		_rigidBody = GetComponent<Rigidbody2D>();
		_boxCollider = GetComponent<BoxCollider2D>();
	}

	void Update()
	{
		_rigidBody.velocity = new Vector2(_speed, _rigidBody.velocity.y);
		_isGrounded = Physics2D.IsTouchingLayers(_boxCollider, _groundLayer);
		if (Input.GetKeyDown(KeyCode.UpArrow) && _isGrounded)
		{
			_rigidBody.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Tree")
		{
			_scoreHandler.HandleDeathUI();
			Time.timeScale = 0;
		}
	}
	#endregion

	#region CustomFunctions
	#endregion
}
