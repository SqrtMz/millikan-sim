using UnityEngine;

public class OilDrop
{
    public float mass;
    public float oilDensity = 910f;
    public Rigidbody rB;
    public GameObject oilDropObj;
    public OilController oilController;
    public MeshRenderer shadow;

    public OilDrop(float rndRad)
    {
        float offsetX = Random.Range(10, 61);
        float offsetY = Random.Range(0, 41);

        oilDropObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        oilDropObj.name = "OilDropplet";
        oilDropObj.transform.position = new Vector3(50f + offsetX, 5f + offsetY, 95f);
        oilDropObj.transform.localScale = new Vector3(rndRad, rndRad, rndRad);
        oilDropObj.GetComponent<MeshRenderer>().material.color = Color.yellow;
        oilDropObj.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        rB = oilDropObj.AddComponent<Rigidbody>();

        mass = oilDensity * (4 * Mathf.PI * Mathf.Pow(rndRad, 3) / 3);
        rB.mass = mass;
        
        rB.useGravity = false;
        rB.velocity = new Vector3(-Random.Range(800f / Mathf.Pow(rndRad, 2), 851f / Mathf.Pow(rndRad, 2)), 0, 0);

        oilController = oilDropObj.AddComponent<OilController>();
    }
}