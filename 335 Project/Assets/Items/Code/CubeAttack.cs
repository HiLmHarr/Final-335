using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAttack : MonoBehaviour
{
    public GameObject reference;
    public GameObject projectile;
    public float cooldown;

    private bool canAttack = true;
    

    // Update is called once per frame
    void Update()
    {
        int layerMask = 0;
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            //This RayCast Always fails
            //Raycast should shoot from hand forward and detect hit on default layer but always fails
            if (Physics.Raycast(reference.transform.position, 
                transform.TransformDirection(Vector3.forward), 
                out hit,
                Mathf.Infinity, 
                layerMask))
            {
                //Debug stuff but ray never gets drawn
                Debug.Log("HIT");
                Debug.DrawRay((reference.transform.position + reference.transform.forward * 1),
                transform.TransformDirection(Vector3.forward) * 1000,
                Color.white);
                //Spawns a large cube in the air that then falls to where raycast hit
                Instantiate(projectile, (hit.transform.position + hit.transform.up * 10), reference.transform.rotation);
                StartCoroutine(AttackCooldown());
            }
            else
            {
                Debug.Log("MISS");
                Debug.DrawRay(reference.transform.position,
                transform.TransformDirection(Vector3.forward) * 1000,
                Color.yellow);
            }
            
        }
    }

    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
}
