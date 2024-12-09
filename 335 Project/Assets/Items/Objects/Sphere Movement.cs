using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float projectileSpeed;
    public float despawn;
    public int damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.AddForce(transform.forward * projectileSpeed * Time.deltaTime, ForceMode.Impulse);
        StartCoroutine(deleteProjectile());
    }

    private void OnCollisionEnter(Collision collision)
    {
        HealthSystem healthSystem = collision.gameObject.GetComponent<HealthSystem>();

        if (healthSystem != null && healthSystem.myType != HealthSystem.Type.player)
        {
            healthSystem.TakeDamage(damage);
            Destroy(this.gameObject);
        }

        
    }

    IEnumerator deleteProjectile()
    {
        yield return new WaitForSeconds(despawn);
        Destroy(this.gameObject);
    }
}
