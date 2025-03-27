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
            //Вместо этого принта можешь потом поставить анимацию смерти
            print("Враг умер");
            SpriteEnemy.GetComponent<Animator>().SetTrigger("Dead");
            Destroy(gameObject, 5f);
        } else {
            //Вместо этого принта можешь потом поставить анимацию получения урона
            print("Враг получил " + damage.ToString() + " урона");
            SpriteEnemy.GetComponent<Animator>().SetTrigger("Hurt");
        }
    }
}
