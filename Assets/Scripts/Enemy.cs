using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int health;
    public GameObject SpriteEnemy;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //������ ����� ������ ������ ����� ��������� �������� ������
            print("���� ����");
            SpriteEnemy.GetComponent<Animator>().SetTrigger("Dead");
            Destroy(gameObject, 5f);
        } else {
            //������ ����� ������ ������ ����� ��������� �������� ��������� �����
            print("���� ������� " + damage.ToString() + " �����");
            SpriteEnemy.GetComponent<Animator>().SetTrigger("Hurt");
        }
    }
}
