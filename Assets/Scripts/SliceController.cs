using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class SliceController : MonoBehaviour
{
    public Material SliceMat;
    private List<GameObject> sliceableObjects = new List<GameObject>();
    [HideInInspector]public GameObject sliceableObject;
    void Awake()
    {
        sliceableObjects.AddRange(GameObject.FindGameObjectsWithTag("Wheat"));
    }

    void Update()
    {
        if(GameObject.Find("Upper_Hull") == true)
        {
            Destroy(GameObject.Find("Upper_Hull"));
        }
    }

    public void Slice()
    {
        SliceObject(sliceableObject, SliceMat);
    }

    public GameObject[] SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.SliceInstantiate(transform.position, transform.up, crossSectionMaterial);
    }
}
