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
    public GameObject currentItem;

    private StarterAssetsInputs _input;
    private GameObject targetItem;
    private RaycastHit hit;
    private Ray ray;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _input = GetComponent<StarterAssetsInputs>();
    }
    void Start()
    {
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

        if (currentItem != null)
        {
            if (currentItem)
            {
                currentItem.transform.position = Vector3.Lerp(currentItem.transform.position, itemAnchor.position, itemTransformSpeed * Time.deltaTime);
            }
        }
    }

    void UseItem()
    {
        if (currentItem != null)
        {
            currentItem.GetComponent<IUsable>().Use(this);
            //Drop();
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

        if (currentItem != null)
        {
            Drop();
        }

        currentItem = targetItem;
        targetItem.GetComponent<Rigidbody>().isKinematic = true;
        targetItem = null;
    }

    void Drop()
    {
        if (currentItem != null)
        {
            currentItem.GetComponent<Rigidbody>().isKinematic = false;
            currentItem = null;
        }
    }
}
