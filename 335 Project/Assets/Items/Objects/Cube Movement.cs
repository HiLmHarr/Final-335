using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float projectileSpeed;
    public float despawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.AddForce(-transform.up * projectileSpeed * Time.deltaTime, ForceMode.Impulse);
        StartCoroutine(deleteProjectile());
    }

    IEnumerator deleteProjectile()
    {
        yield return new WaitForSeconds(despawn);
        Destroy(this.gameObject);
    }
}
