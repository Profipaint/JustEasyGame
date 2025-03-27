using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
 public Transform firePoint;
 public int damage = 100;
 public LineRenderer lineRenderer;
 public GameObject ImpactEffect;
 public GameObject Controller;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
            Controller.GetComponent<Animator>().SetTrigger("Attack");
        }
    }

    void Shot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        if (hitInfo)
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Instantiate(ImpactEffect, hitInfo.point, Quaternion.identity);

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }
    }
}
