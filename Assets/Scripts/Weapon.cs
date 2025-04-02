using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 100;
    public GameObject ImpactEffect;
    public GameObject Controller;

    public GameObject lineEffect;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
            Controller.GetComponent<Animator>().SetTrigger("Attack");
        }
    }

    private void CreateEffect(RaycastHit2D hitinfo)
    {
        Instantiate(lineEffect, transform.position, transform.rotation).TryGetComponent(out LineEffect effect); //сам себя уберет его не надо Destroy()!!!

        if (effect == null)
        {
            print("ERROR LINE EFFECT DOES NOT HAVE ITS SCRIPT!");
            return;
        }

        Vector3 lineEnd;

        if (hitinfo)
        {
            //lineEnd = new(0, 0, hitinfo.point.x);
            lineEnd = new(hitinfo.point.x, firePoint.transform.position.y, -1);
        }
        else
        {
            //lineEnd = new(0, 0, firePoint.transform.position.x + firePoint.transform.right.x * 100);
            lineEnd = new(firePoint.transform.position.x + firePoint.transform.right.x * 100, firePoint.transform.position.y, -1);
        }

        Vector3 lineStart = firePoint.transform.position;
        lineStart.z = -1;

        effect.SetPosition(lineStart, lineEnd);
    }

    void Shot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        if (hitInfo)
        {
            hitInfo.transform.TryGetComponent(out Enemy enemy);
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Instantiate(ImpactEffect, hitInfo.point, Quaternion.identity);
            CreateEffect(hitInfo);
        }
        else
        {
            Instantiate(lineEffect);
            CreateEffect(hitInfo);
        }
    }
}
