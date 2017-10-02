using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{

    public static PlayerStats instance_player;
    public delegate void OnPlayerStatsChanged();
    public OnPlayerStatsChanged onPlayerStatsChanged;
    bool isInitial = false;
    public override void Awake()
    {
        base.Awake();
        if (instance_player != null)
        {
            return;
        }
        instance_player = this;
    }


    // Use this for initialization
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += onEquipmentChanged;
    }
    public override void Update()
    {
        base.Update();
        if (isInitial == false)
        {
            onEquipmentChanged(null, null);
            isInitial = true;
        }
    }
    private void onEquipmentChanged(Equipment oldItem, Equipment newItem)
    {
        //ke thua tu thang cha
        if (newItem != null)
        {
            armor.AddCurrentStat(newItem.Defence);
            damage.AddCurrentStat(newItem.Damage);
        }

        if (oldItem != null)
        {
            armor.RemoveCurrentStat(oldItem.Defence);
            damage.RemoveCurrentStat(oldItem.Damage);
        }
        if (onPlayerStatsChanged != null)
        {
            onPlayerStatsChanged.Invoke();
        }
    }
}
