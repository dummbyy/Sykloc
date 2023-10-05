using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Fields
    [SerializeField] private float m_Speed;
    public int m_Health;

    private float horizontalMove;
    private float verticalMove;

    private new Rigidbody2D rigidbody;
    #endregion

    #region Unity Methods
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove   = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
    }   
    #endregion

    #region Methods

    /// <summary>
    /// Player movement method
    /// </summary>
    private void Move()
    {
        rigidbody.velocity = new Vector2(horizontalMove, verticalMove).normalized * m_Speed;
    }
    #endregion
}
