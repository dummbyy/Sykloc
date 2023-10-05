
using UnityEngine;

public class Attack : MonoBehaviour
{
    #region Fields
    private Camera mainCam;
    private Vector3 mousePos;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletPos;

    private bool canFire = true;
    private float timer;
    [SerializeField] private float nextTimeForFire;
    [SerializeField] private float bulletLifeTime;
    #endregion

    #region Unity Methods
    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;

        float zRotation = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, zRotation);

        if(!canFire)
        {
            timer += Time.deltaTime;

            if(timer >= nextTimeForFire)
            {
                timer = 0;
                canFire = true;
            }
        }

        if(Input.GetMouseButton(0) && canFire)
        {
            Shoot();
            canFire = false;
        }
    }
    #endregion
    
    #region Methods
    private void Shoot()
    {
        GameObject bulletObject = Instantiate(bulletPrefab, bulletPos.position, Quaternion.identity);
        Destroy(bulletObject, bulletLifeTime);
    }
    #endregion
}