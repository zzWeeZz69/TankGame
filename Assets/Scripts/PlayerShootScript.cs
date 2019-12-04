using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{
    public Rigidbody bullet;
    public Rigidbody playerRigidBody;

    public Vector3 offset;

    public float bulletPower = 2;
    public float valueToIncreaseEverySec = 100;

    public void Update()
    {
        StartCoroutine(ShootBullet());
    }

    public IEnumerator ShootBullet()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("charging!");
            bulletPower += valueToIncreaseEverySec * Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.P))
        {
            Debug.Log(bulletPower);

            Quaternion targetIns = Quaternion.Euler(transform.localRotation.x + offset.x, transform.rotation.y + offset.y, transform.position.z + offset.z);

            playerRigidBody = Instantiate(bullet, transform.position, targetIns);


            playerRigidBody.velocity = transform.TransformDirection(Vector3.forward * bulletPower);
        }
        else
        {
            yield return new WaitForSeconds(10);
            bulletPower = 1;
        }
    }
}
