using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMultiplayerManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<Sprite> playersprites;
    public List<PlayerInput> Players;
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
               
                
            Debug.Log("Player " + attackPlayer.playerIndex + " hit player " + Players[i].playerIndex);
        }
    }
}
    


}


