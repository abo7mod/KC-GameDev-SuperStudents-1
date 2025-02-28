using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource src;
    public GameObject crosshairs;
    public GameObject Player;
    public GameObject bulletPrefab;
    public float bulletSpeed = 60.0f;
    public GameObject bulletStart;

    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - Player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //Player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Input.GetMouseButtonDown(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBullet(direction, rotationZ);
            src.Play();
        }



    }

    void fireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

    }


}
