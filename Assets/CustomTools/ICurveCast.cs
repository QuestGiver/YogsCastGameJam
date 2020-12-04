using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICurveCast<T>
{
    Vector3[] BendRay(Ray T);

}

