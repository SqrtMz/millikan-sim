using UnityEngine;

public class OilController : MonoBehaviour
{
    private float stokes;
    private Vector3 stokesForce;
    private Rigidbody rB;
    public float weight, apparentWeight, elecForce, termV1, charge, vSus;
    private readonly float oilDensity = 910f;
    private readonly float airDensity = 1.19f;
    private readonly float airViscosity = 1.849e-5f;
    private readonly float plateDist = 6e-3f;
    public VoltageTimeController vtgTC;
    private int chargeMul;

    private void Start()
    {
        vtgTC = GameObject.FindWithTag("VTGBox").GetComponent<VoltageTimeController>();
        rB = this.GetComponent<Rigidbody>();

        termV1 = 2 * Mathf.Pow(rB.transform.localScale.x, 2) * Physics.gravity.y * (oilDensity - airDensity) / (9 * airViscosity);

        chargeMul = Random.Range(10, 31);

        charge = chargeMul * 1.602e-1f;

        vSus = rB.mass * Physics.gravity.magnitude * plateDist / charge;

        weight = 4 * Mathf.PI * Mathf.Pow(this.transform.localScale.x, 3) * Physics.gravity.y * oilDensity / 3;
        apparentWeight = 4 * Mathf.PI * Mathf.Pow(this.transform.localScale.x, 3) * Physics.gravity.y * (oilDensity - airDensity) / 3;

    }

    private void Update()
    {
        elecForce = charge * vtgTC.voltage / plateDist;

        stokes = 6 * Mathf.PI * this.transform.localScale.x * airViscosity * 1e8f;
        stokesForce = new Vector3(stokes * -rB.velocity.x, stokes * -rB.velocity.y, stokes * -rB.velocity.z);

        OilDeletor();
    }

    void FixedUpdate()
    {
        StokesForce();
        ApparentWeight();

        if(vtgTC.VtgOn)
        {
            EField();
        }
    }

    public void OilDeletor()
    {
        if(this.transform.position.y < -50 || this.transform.position.y > 50)
        {
            Destroy(this.gameObject);
        }
    }

    public void ApparentWeight()
    {
        rB.AddForce(0, apparentWeight, 0);
    }

    public void StokesForce()
    {
        rB.AddForce(stokesForce);
    }

    public void EField()
    {
        if(vtgTC.voltage != 0)
        {
            rB.AddForce(0, elecForce, 0);
        }
    }
}