using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("主要统计")]
    public Stat strength;
    public Stat vitality;

    public Stat damage;
    public Stat maxHealth;

    public int currentHealth;

    public System.Action onHealthChange;

    public bool isDead {  get; private set; }
    protected virtual void Start()
    {
        currentHealth = GetMaxHealthValue();
    }
    public virtual void DoDamage(CharacterStats _targetStats)
    {
        int totalDamage = damage.GetValue() + strength.GetValue();

        _targetStats.TakeDamage(totalDamage);
    }
    public virtual  void TakeDamage(int _damage)
    { 
        DecreaseHealthBy(_damage);

        Debug.Log(_damage);
        if (currentHealth < 0 && !isDead)
            Die();
    }
    protected virtual void DecreaseHealthBy(int _damage)
    {
        currentHealth -= _damage;

        if(onHealthChange != null)
            onHealthChange();
    }
    protected virtual void Die()
    {    
        isDead = true;
    }

    public void KillEntity() => Die();
    public int GetMaxHealthValue()
    {
        return maxHealth.GetValue()+ vitality.GetValue() * 5;
    }
}
