using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damage;
    public int cooldown;
    bool canProc = true;

    private void OnCollisionEnter(Collision collision)
    {
        HealthSystem healthSystem = collision.gameObject.GetComponent<HealthSystem>();

        if (healthSystem != null && canProc)
        {
            canProc = false;

            healthSystem.TakeDamage(damage);

            //Spikes
            foreach (Transform child in transform)
            {
                child.transform.position += new Vector3(0, 1, 0);
            }

            StartCoroutine(Retraction());
        }
    }

    IEnumerator Retraction()
    {
        yield return new WaitForSeconds(cooldown);
        foreach (Transform child in transform)
        {
            child.transform.position -= new Vector3(0, 1, 0);
        }
        canProc = true;
    }
}
