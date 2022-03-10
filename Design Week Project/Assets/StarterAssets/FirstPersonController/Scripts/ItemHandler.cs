using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemHandler : MonoBehaviour
{
    public Transform itemAnchor;
    public float itemTransformSpeed = 5f;
    public float grabRange = 10f;

    private StarterAssetsInputs _input;
    private GameObject targetItem;
    private RaycastHit hit;
    private Ray ray;
    private int nullItemIndex = 4396;
    [SerializeField]
    private int itemIndex;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _input = GetComponent<StarterAssetsInputs>();
    }
    void Start()
    {
        itemIndex = nullItemIndex;
        _input.pickup.AddListener(PickUp);
        _input.use.AddListener(UseItem);
        _input.drop.AddListener(Drop);
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        Physics.Raycast(ray, out hit, grabRange);
        //Debug.Log(hit.collider.gameObject);
        //Debug.Log(hit.collider.gameObject.GetComponent<IUsable>() != null);
        if (hit.collider != null)
        {
            targetItem = hit.collider.gameObject;
        }

        if (transform.childCount >= itemIndex)
        {
            if (transform.GetChild(itemIndex).transform != itemAnchor)
            {
                transform.GetChild(itemIndex).transform.position = Vector3.Lerp(transform.GetChild(itemIndex).transform.position, itemAnchor.position, itemTransformSpeed * Time.deltaTime);
            }
        }
        else
        {
            itemIndex = nullItemIndex;
        }
    }

    void UseItem()
    {
        if (transform.childCount >= itemIndex)
        {
            transform.GetChild(itemIndex).GetComponent<IUsable>().Use();
        }
    }

    void PickUp()
    {
        if (targetItem == null)
        {
            return;
        }

        if (targetItem.GetComponent<IUsable>() == null)
        {
            return;
        }

        if (itemIndex != nullItemIndex)
        {
            Drop();
        }

        targetItem.transform.SetParent(gameObject.transform);
        itemIndex = targetItem.transform.GetSiblingIndex();
        targetItem.GetComponent<Rigidbody>().isKinematic = true;
        targetItem = null;
    }

    void Drop()
    {
        if (transform.childCount >= itemIndex)
        {
            transform.GetChild(itemIndex).GetComponent<Rigidbody>().isKinematic = false;
            transform.GetChild(itemIndex).parent = null;
            itemIndex = nullItemIndex;
        }
    }
}
