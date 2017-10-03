using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Intertactable {

    PlayerManager playerManager;
    CharacterStats selfStats;
    private void Start()
    {
        playerManager = PlayerManager.instance; // nhan player vao
        selfStats = GetComponent<EnermyStats>();//lay gia tri cua chinh minh
    }

    public override void Interact()
    {
        base.Interact();
        Combat playerCombat = playerManager.player.GetComponent<Combat>();
        if (playerCombat!=null)
        {
            playerCombat.Attack(selfStats);// bi nguoi choi tan cong
        }
        
    }
}
