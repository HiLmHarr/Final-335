using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereAttack : MonoBehaviour
{
    public GameObject reference;
    public GameObject projectile;
    public float cooldown;

    private bool canAttack = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            //Spawns sphere
            //Movement for sphere shoots it forward on start
            Instantiate(projectile, reference.transform.position, reference.transform.rotation);
            StartCoroutine(AttackCooldown());
        }
    }
    
    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
}
