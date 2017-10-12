using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIbar : MonoBehaviour
{

    [SerializeField] Image healthBar;
    [SerializeField] Image manaBar;

    // Use this for initialization
    void Start()
    {
        CharacterStats.instance.onCharacterStatsChanged += UpdateUIBar;
        PlayerStats.instance_player.onPlayerStatsChanged += UpdateUIBar;
        Combat.instance.onCombat += UpdateUIBar;
    }

    private void UpdateUIBar()
    {
        float _health = (float)PlayerStats.instance.currentHealth / PlayerStats.instance.maxHealth;
        healthBar.fillAmount = _health;
        manaBar.fillAmount = _health;
    }
}
