using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class SlicePlane : MonoBehaviour
{
    public SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        // slice the provided object using the transforms of this object
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }
}
