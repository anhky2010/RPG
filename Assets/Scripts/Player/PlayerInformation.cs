using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInformation : MonoBehaviour
{

    public enum ValueType { MaxHealth, CurrentHealth, Damage, Range, Armor };
    public ValueType valueType;
    private int[] AllValue;
    // Use this for initialization
    void Start()
    {
        int orderIndex = System.Enum.GetNames(typeof(ValueType)).Length;
        AllValue = new int[orderIndex];
        ShowValue();
        CharacterStats.instance.onCharacterStatsChanged += onPlayerStatsChanged;
        PlayerStats.instance_player.onPlayerStatsChanged += onPlayerStatsChanged;
        Combat.instance.onCombat += onPlayerStatsChanged;
    }

    private void onPlayerStatsChanged()
    {
        Text text = GetComponent<Text>();
        text.text = ShowValue().ToString();
    }

    private int ShowValue()
    {
        AllValue[0] = PlayerStats.instance_player.maxHealth;
        AllValue[1] = PlayerStats.instance_player.currentHealth;
        AllValue[2] = PlayerStats.instance_player.damage.GetFinalValue();
        AllValue[3] = PlayerStats.instance_player.attackRange.GetFinalValue();
        AllValue[4] = PlayerStats.instance_player.armor.GetFinalValue();
        int temp = (int)valueType;
        return AllValue[temp];
    }


}
