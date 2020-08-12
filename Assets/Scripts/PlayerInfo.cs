using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public bool guiEnable = false;
    public int goldAmount = 100;
    public int woodAmount = 0;
    public int stoneAmount = 0;
    public int level = 0;
    public HealthBar healthBar;
    public Transform boss;
    public bool canTakeDamage = false;

    public Text goldAmountText;
    public Text woodAmountText;
    public Text stoneAmountText;

    public int whichTimeAttack = 0;

    public BossStates b;


    private void OnGUI()
    {
        if(guiEnable)
        {
            goldAmountText.text = GlobalPlayerControl.instance.goldAmount.ToString();
            woodAmountText.text = GlobalPlayerControl.instance.stoneAmount.ToString();
            stoneAmountText.text = GlobalPlayerControl.instance.woodAmount.ToString();
        }
    }
    // Update is called once per frame
    void Update()
    {
        healthBar.setHealth(GlobalPlayerControl.instance.health);
    }

    public void TakeDamage()
    {
        if (canTakeDamage)
        {
            int damage = UnityEngine.Random.Range(20,30);

            GlobalPlayerControl.instance.health -= damage;
            healthBar.setHealth(GlobalPlayerControl.instance.health);
        }
    }

}
