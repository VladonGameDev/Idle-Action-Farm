using UnityEngine;
using EzySlice;
using DG.Tweening;
public class SliceController : MonoBehaviour
{
    [SerializeField]
    private Settings settings;
    private Transform playerTransform;

    public Material SliceMat;

    [HideInInspector]public GameObject sliceableObject;
    [HideInInspector]public GameObject dropBlock;
    [HideInInspector] public bool isDrop = false;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        if(GameObject.Find("Upper_Hull") == true)
        {
            Destroy(GameObject.Find("Upper_Hull"));
        }
        if (GameObject.Find("Lower_Hull") == true)
        {
            if (isDrop == true)
            {
                var LowerHull = GameObject.Find("Lower_Hull").transform;
                RandomName(LowerHull);
                Drop(LowerHull);
                Destroy(LowerHull.gameObject, settings.WheatRipeningTime);
            }
        }
    }
    private void RandomName(Transform LowerHull)
    {
        char[] letters = "QWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray();
        string word = "LH_";
        for(int i = 0; i < 7; i++)
        {
            int letter_num = Random.Range(0, letters.Length - 1);
            word += letters[letter_num];
        }
        LowerHull.name = word;
    }

    private void Drop(Transform LowerHull)
    {
        var Block = Instantiate(dropBlock, new Vector3(LowerHull.position.x, LowerHull.position.y + 0.4f, LowerHull.position.z), Quaternion.identity, LowerHull);
        Block.transform.DOJump(new Vector3(playerTransform.position.x, playerTransform.position.y + 0.8f, playerTransform.position.z), 1.5f, 1, 0.5f, false);
        Destroy(Block, 0.5f);
        isDrop = false;
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
