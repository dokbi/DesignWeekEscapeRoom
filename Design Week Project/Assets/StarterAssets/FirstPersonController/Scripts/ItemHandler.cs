using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemHandler : MonoBehaviour
{
    public Transform itemAnchor;
    public float itemTransformSpeed = 10f;
    public float grabRange = 10f;
    public GameObject currentItem;

    private StarterAssetsInputs _input;
    private SizeControl _sizeControl;
    private GameObject targetItem;
    private RaycastHit hit;
    private Ray ray;
    private Vector3 itemNominalScale;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _sizeControl = GetComponent<SizeControl>();
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
            if (currentItem.transform.position != itemAnchor.position)
            {
                currentItem.transform.position = Vector3.Lerp(currentItem.transform.position, itemAnchor.position, itemTransformSpeed * Time.deltaTime);
            }
            Debug.Log(transform.localScale * (currentItem.transform.localScale.x));
            if (currentItem.transform.localScale != itemNominalScale*_sizeControl.currentScale)
            {
                currentItem.transform.localScale = Vector3.Lerp(currentItem.transform.localScale, itemNominalScale * _sizeControl.currentScale, itemTransformSpeed * Time.deltaTime);
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
        itemNominalScale = targetItem.transform.localScale;
        targetItem.GetComponent<Rigidbody>().isKinematic = true;
        targetItem = null;
    }

    public void Drop()
    {
        if (currentItem != null)
        {
            currentItem.GetComponent<Rigidbody>().isKinematic = false;
            currentItem.transform.localScale = itemNominalScale;
            currentItem = null;
        }
    }
}
