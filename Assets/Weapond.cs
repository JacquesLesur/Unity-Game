using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapond : MonoBehaviour {

    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask whatToHit;

    public Transform BulletTrailPrefab;
    float timeToSpawnEffect = 0;
    public float effectSpawnRate = 10;

    float timeToFire = 0;
    Transform firePoint;

    // Use this for initialization
    void Awake()
    {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No firePoint? WHAT?!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }

    //void Shoot()
    //{
    //    Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
    //    Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
    //    RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);
    //    if (Time.time >= timeToSpawnEffect)
    //    {
    //        Effect();
    //        timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
    //    }
    //    Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.cyan);
    //    if (hit.collider != null)
    //    {
    //        Debug.DrawLine(firePointPosition, hit.point, Color.red);
    //        Debug.Log("We hit " + hit.collider.name + " and did " + Damage + " damage.");
    //    }
    //}

    void Effect()
    {
        Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation);
    }

    void Shoot()
    {
        var mouse = Input.mousePosition;
        var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        Vector2 mousePosition = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);
        if (Time.time >= timeToSpawnEffect)
        {
            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }
       // Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.cyan);

        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
            Debug.Log("We hit " + hit.collider.name + " and did " + Damage + " damage.");
        }
    }
}
