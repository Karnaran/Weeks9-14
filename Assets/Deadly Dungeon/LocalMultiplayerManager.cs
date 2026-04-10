using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;
using TMPro;

public class LocalMultiplayerManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<Sprite> playersprites;
    public List<PlayerInput> Players;
    public bool isDead;
    public CinemachineImpulseSource impulseSource;
    LocalMultiplayercontrol LocalMultiplayercontrol;
    public void onPlayerJoined(PlayerInput player)

    {
        Players.Add(player);
        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        sr.sprite = playersprites[player.playerIndex];

        LocalMultiplayercontrol controller = player.GetComponent<LocalMultiplayercontrol>();
        controller.manager = this;
    }

    public void PlayerAttacking(PlayerInput attackPlayer)
    {
        for (int i = 0; i < Players.Count; i++)
        {

            if (attackPlayer == Players[i]) continue;

            if (Vector2.Distance(attackPlayer.transform.position, Players[i].transform.position) < 0.5f)
                {

                Players[i].GetComponent<LocalMultiplayercontrol>().playerStriked();
                isDead = true;
            Debug.Log("Player " + attackPlayer.playerIndex + " hit player " + Players[i].playerIndex);
        }
    }

        
}



}


