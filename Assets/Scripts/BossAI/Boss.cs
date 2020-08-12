using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Animator animator;
    public int  maxHealth;
    public int health;
    public bool meleeAttack;
    public float meleeDamage;
    public HealthBar bossHPBar;

    public PlayerInfo target;

    public Text actualHP;

    public GameObject hpBarManager;

    private void Start()
    {
        health = maxHealth;
        actualHP.text = health.ToString() + "/" + maxHealth.ToString();
    }

    public void meleeAttackhit(int damage)
    {
        health -= damage;
        actualHP.text = health.ToString() + "/" + maxHealth.ToString();
        bossHPBar.setHealth(health);
        if (health <= 0)
        {
            this.hpBarManager.SetActive(false);
            this.bossHPBar.enabled = false;
            Destroy(this.gameObject);
        }
        Debug.Log(damage);

    }
    void isDeath()
    {
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {

    }
    void Attack()
    {
        target.TakeDamage();
    }
}
