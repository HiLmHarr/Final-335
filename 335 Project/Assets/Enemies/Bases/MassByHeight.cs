using UnityEngine;

public class MassByHeight : MonoBehaviour
{
    //This will adjust the mass of objects the higher they are
    //This stops building from collapsing on themselves
    public float baseMass;
    public float heightFactor;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        AdjustMass();
    }

    private void AdjustMass()
    {
        float height = transform.position.y;

        if (height > 0)
        {

            //Calculates new mass based on how high it is
            float newMass = baseMass - height * heightFactor;

            //ensure that the mass doesn't go blow .1
            newMass = Mathf.Max(newMass, 0.1f);

            //updates mass
            rb.mass = newMass;
        }
        else
        {
            rb.mass = baseMass;
        }
    }
}
