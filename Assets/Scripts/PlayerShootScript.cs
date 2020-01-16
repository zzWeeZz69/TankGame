using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShootScript : MonoBehaviour
{

    Vector3 shootDirection;

    [SerializeField] TankController tkControll;
    public Image Arrowslider;

    public GameObject bullet;
    //public GameObject bulletIndicator;
    [HideInInspector]
    public bool DisableShoot;
    public const float startBulletPower = 500f;
    public const float maxBulletPower = 5000f;
    private float bulletPower;
    public float chargeArrow;
    public float valueToIncreaseEverySec = 3f;

    void Start()
    {
        //    m_MyPosition.Set(m_NewTransform.position.x, m_NewTransform.position.y, 0);
        bulletPower = startBulletPower;
        Arrowslider.fillAmount = 0;
    }

    public void Update()
    {
        if (!DisableShoot)
            Fire();
        //FireIndicator();


    }

    private void Fire()
    {
        if (bulletPower > maxBulletPower)
        {
            bulletPower = maxBulletPower;
        }

        if (Input.GetButton("Shoot_" + tkControll.Player.ToString()))
        {

            bulletPower += valueToIncreaseEverySec * Time.deltaTime;
            float f = Mathf.InverseLerp(startBulletPower, maxBulletPower, bulletPower);
            chargeArrow = f;
            //chargeArrow = Mathf.Lerp(startBulletPower, maxBulletPower, f);
            Debug.Log("bulletPower" + bulletPower);
            Arrowslider.fillAmount = bulletPower / maxBulletPower;
        }

        if (Input.GetButtonUp("Shoot_" + tkControll.Player.ToString()))
        {
            Debug.Log(bulletPower);

            GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject; //I have small pepe
            Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidbody.AddRelativeForce(transform.forward * bulletPower);
            bulletPower = startBulletPower;
            Debug.Log("Max bullet power " + maxBulletPower);
            Arrowslider.fillAmount = 0;
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
