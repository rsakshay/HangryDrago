using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour {

    private void OnTriggerEnter(Collider collision)
    {
        var player = collision.GetComponent<TakeDamage>();

        if (player != null)
        {
            player.PlayerTakeDamage(transform);
        }
    }

}
