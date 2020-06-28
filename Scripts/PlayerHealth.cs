using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float startingHealth = 100;
    public float currentHealth;
    public Image healthBar;

    Animator anim;
    HeroMotion heroMotion;

    bool isDead;
    bool damaged;

    void Awake()
    {
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
    }

    public void TakeDamage (float amount)
    {
        damaged = true;
        currentHealth -= amount;
        SoundManager.PlaySound("Hurt");
        healthBar.fillAmount = currentHealth / startingHealth;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        anim.SetTrigger("isDead");
        heroMotion.enabled = false;
        SoundManager.PlaySound("Dead");
    }
}
