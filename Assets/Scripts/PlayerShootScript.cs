using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{

    Vector3 shootDirection;

    public GameObject bullet;
    public GameObject arrow;
    //public GameObject bulletIndicator;

    public const float startBulletPower = 500f;
    public const float maxBulletPower = 5000f;
    private float bulletPower;
    public float chargeArrow;
    public float valueToIncreaseEverySec = 3f;

    void Start()
    {
        //    m_MyPosition.Set(m_NewTransform.position.x, m_NewTransform.position.y, 0);
        bulletPower = startBulletPower;
        shootDirection.Set(0, 0.1f, 1);
    }

    public void Update()
    {
        Fire();
        //FireIndicator();
    }

    private void Fire()
    {
        if (bulletPower > maxBulletPower)
        {
            bulletPower = maxBulletPower;
        }

        if (Input.GetKey(KeyCode.P))
        {

            bulletPower += valueToIncreaseEverySec * Time.deltaTime;
            float f = Mathf.InverseLerp(startBulletPower, maxBulletPower, bulletPower);
            chargeArrow = f;
            //chargeArrow = Mathf.Lerp(startBulletPower, maxBulletPower, f);
            Debug.Log("bulletPower" + bulletPower);
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            Debug.Log(bulletPower);

            GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidbody.AddForce(shootDirection * bulletPower);
            bulletPower = startBulletPower;
            Debug.Log("Max bullet power " + maxBulletPower);
        }
    }

    //private void FireIndicator()
    //{
    //    if (Input.GetKey(KeyCode.P))
    //    {
    //        GameObject instBulletIndicator = Instantiate(bulletIndicator, transform.position, Quaternion.identity) as GameObject;
    //        Rigidbody instBulletRigidbodyIndicator = instBulletIndicator.GetComponent<Rigidbody>();
    //        instBulletRigidbodyIndicator.AddForce(shootDirection * bulletPower);
    //    }
    //}
}
