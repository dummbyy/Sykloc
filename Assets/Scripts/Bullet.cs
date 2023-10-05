using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Fields
    private Camera mainCam;
    private Vector3 mousePos;
    private new Rigidbody2D rigidbody;

    [SerializeField] private float m_BulletForce;
    #endregion
    #region Unity Methods
    private void Start()
    {
        mainCam    = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rigidbody  = this.GetComponent<Rigidbody2D>();  
        mousePos   = mainCam.ScreenToWorldPoint(Input.mousePosition);
        

        Vector3 direction  = mousePos - transform.position;
        Vector3 rotation   = transform.position - mousePos;
        rigidbody.velocity = new Vector2(direction.x, direction.y).normalized * m_BulletForce;
        float zRotation    = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, zRotation + 90);
    }

    private void Awake() {}

    private void Update() { }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Hitable"))
        {
            Enemy enemyRef = col.GetComponent<Enemy>();
            
            enemyRef.m_Health -= Random.Range(20, 100);
            enemyRef.Die(enemyRef);

            Destroy(this.gameObject);
        }
    }
    #endregion
}