using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    private SliceController sliceController;
    private PlayerController playerController;
    private void Awake()
    {
        sliceController = GameObject.Find("Slice").GetComponent<SliceController>();
        playerController = GameObject.Find("Character").GetComponent<PlayerController>();
    }
    public void OnTriggerEnter(Collider other)
    {
        sliceController.sliceableObject = this.gameObject;
        sliceController.Slice();
        playerController.isHit = true;
        Invoke("DeactivateObject", 1.8f);
        Invoke("ActivateObject", 11.8f);
    }

    private void DeactivateObject()
    {
        playerController.isHit = false;
        gameObject.SetActive(false);
    }
    private void ActivateObject()
    {
        gameObject.SetActive(true);
    }
}
