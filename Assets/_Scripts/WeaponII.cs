using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponII : MonoBehaviour
{
    public int Ammo = 30;
    public GameObject ProjPrefab;
    public Transform muzPoint;
    public Transform[] beamBlast;
    public bool bigBlast;
    public float beamSpread = 5.55f;
    public float projScale = 0.04f;

    // Start is called before the first frame update
    void Start()
    {
        bigBlast = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Ammo > 0)
        {
            //Randomizes beam spread
            beamBlast[0].Rotate(muzPoint.localRotation.x + (beamSpread*Random.value), muzPoint.localRotation.y, muzPoint.localRotation.z);
            beamBlast[1].Rotate(muzPoint.localRotation.x - (beamSpread * Random.value), muzPoint.localRotation.y, muzPoint.localRotation.z);
            beamBlast[2].Rotate(muzPoint.localRotation.x, muzPoint.localRotation.y + (beamSpread * Random.value), muzPoint.localRotation.z);
            beamBlast[3].Rotate(muzPoint.localRotation.x, muzPoint.localRotation.y - (beamSpread * Random.value), muzPoint.localRotation.z);
            beamBlast[4].Rotate(muzPoint.localRotation.x + (beamSpread * Random.value), muzPoint.localRotation.y + (beamSpread * Random.value), muzPoint.localRotation.z);
            beamBlast[5].Rotate(muzPoint.localRotation.x - (beamSpread * Random.value), muzPoint.localRotation.y + (beamSpread * Random.value), muzPoint.localRotation.z);
            beamBlast[6].Rotate(muzPoint.localRotation.x + (beamSpread * Random.value), muzPoint.localRotation.y - (beamSpread * Random.value), muzPoint.localRotation.z);
            beamBlast[7].Rotate(muzPoint.localRotation.x - (beamSpread * Random.value), muzPoint.localRotation.y - (beamSpread * Random.value), muzPoint.localRotation.z);

            //Shoots a beam right along the cursor
            Ammo--;
            GameObject proj = Instantiate(ProjPrefab, muzPoint.position, muzPoint.rotation);
            proj.transform.localScale = new Vector3(projScale, projScale, projScale);

            //Loops through each beam blast transform and launches beams in previously randomized directions
            for (int i = 0; i < 8; i++)
            {
                GameObject projS = Instantiate(ProjPrefab, beamBlast[i].position, beamBlast[i].rotation);
                projS.transform.localScale = new Vector3(projScale, projScale, projScale);
                
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            //Resets beam spread array
            for (int i = 0; i < 8; i++)
            {
                beamBlast[i].localRotation = Quaternion.identity;
            }

            if (!bigBlast)
            {
                //About quadruples beam spread
                beamSpread += 15.0f;
                bigBlast = true;
            }

            else
            {
                //Resets beam spread to default
                beamSpread -= 15.0f;
                bigBlast = false;
            }
               
        }

    }

    //eof
}
