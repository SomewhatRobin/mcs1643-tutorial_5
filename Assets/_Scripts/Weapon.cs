using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int Ammo = 100;
    public GameObject ProjPrefab;
    public Transform muzPoint;
    public float projScale = 0.04f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Ammo > 0)
        {
            Ammo--;
           GameObject proj = Instantiate(ProjPrefab, muzPoint.position, muzPoint.rotation);
            proj.transform.localScale = new Vector3(projScale, projScale, projScale);
        }
    }

//eof
}
