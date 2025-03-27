using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
 Image HealthBar;
 public float maxHealth = 100f;
 public float HP;
    void Start()
    {
        HealthBar = GetComponent<Image>();
        HP = maxHealth;
    }

    void Update()
    {
        HealthBar.fillAmount = HP / maxHealth;
    }
}
