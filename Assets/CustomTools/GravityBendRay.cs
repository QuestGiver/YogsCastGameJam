using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBendRay : MonoBehaviour, ICurveCast<Ray>
{
    //Implamentation Example:
    /*
    ICurveCast<Ray> curve;

    private void Start()
    {
        Ray ray;
        ray.origin = Vector3.zero;
        ray.direction = Vector3.one;
        curve.BendRay(ray);
    }
    */

    public float radius;
    public float maxDistance;
    public LayerMask mask;
    public int minimumCastDistance;



    /// <summary>
    /// Bends an input ray based on an objects position, detected via a spherecast. Returns an array of positions representing the turning points the ray took to facilitate the bend
    /// </summary>
    /// <param name="T"></param>
    /// <returns></returns>
    Vector3[] ICurveCast<Ray>.BendRay(Ray T)
    {
        for (float i = 0; i < maxDistance; i++)
        {
            Physics.SphereCast(T, radius, out RaycastHit hit, minimumCastDistance, mask);



            if ((i += minimumCastDistance) > maxDistance)
            {
                i = maxDistance - i;
            }
            else
            {
                i += minimumCastDistance;
            }

        }


        



        
        throw new System.Exception("Not Implamented. Yet.");
    }

  
}
