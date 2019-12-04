using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{
    public GameObject bullet;
    public float startBulletPower = 1000f;
    private float bulletPower;
    public float valueToIncreaseEverySec = 3f;

    void Start()
    {
        bulletPower = startBulletPower;
    }

    public void Update()
    {


        if (Input.GetKey(KeyCode.P))
        {
            bulletPower += valueToIncreaseEverySec * Time.deltaTime;
            Debug.Log("bulletPower" + bulletPower);
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            Debug.Log(bulletPower);

            GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidbody.AddForce(Vector3.forward * bulletPower);
            bulletPower = startBulletPower;
        }

        //public Rigidbody bullet;
        //public Rigidbody playerRigidBody;

        //public Vector3 offset;

        //public float bulletPower = 2;
        //public float valueToIncreaseEverySec = 100;

        //public IEnumerator ShootBullet()
        //{
        //    if (Input.GetKeyDown(KeyCode.P))
        //    {
        //        Debug.Log("charging!");
        //        bulletPower += valueToIncreaseEverySec * Time.deltaTime;
        //    }
        //    else if (Input.GetKeyUp(KeyCode.P))
        //    {
        //        Debug.Log(bulletPower);

        //        Quaternion targetIns = Quaternion.Euler(transform.localRotation.x + offset.x, transform.rotation.y + offset.y, transform.position.z + offset.z);

        //        bullet = Instantiate(bullet, transform.position, targetIns);
        //        Instantiate(bullet);

        //        bullet.velocity = transform.TransformDirection(Vector3.forward * bulletPower);
        //    }
        //    else
        //    {
        //        yield return new WaitForSeconds(10);
        //        bulletPower = 1;
        //    }
        //}
    }
}
