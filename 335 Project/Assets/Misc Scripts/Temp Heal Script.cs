using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempHealScript : MonoBehaviour
{
    public int heal;

    private void OnCollisionEnter(Collision collision)
    {
        HealthSystem healthSystem = collision.gameObject.GetComponent<HealthSystem>();

        if (healthSystem != null)
        {
            healthSystem.Heal(heal);
            Destroy(this.gameObject);
        }
    }
}