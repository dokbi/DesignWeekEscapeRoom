using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemHandler : MonoBehaviour
{
    public Transform itemAnchor;
    public float itemTransformSpeed = 5f;


    private StarterAssetsInputs _input;
    private IUsable currentUsable;
    private GameObject currentItem;
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

    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        Physics.Raycast(ray, out hit, 100f);
        //Debug.Log(hit.collider.gameObject);
        //Debug.Log(hit.collider.gameObject.GetComponent<IUsable>() != null);
        if (hit.collider != null)
        {
            targetItem = hit.collider.gameObject;
            if (_input.pickup && targetItem.GetComponent<IUsable>() != null)
            {
                PickUp();
                
            }
        }
        _input.pickup = false;
        if (currentItem != null)
        {
            if (currentItem.transform != itemAnchor)
            {
                currentItem.transform.position = Vector3.Lerp(currentItem.transform.position, itemAnchor.position, itemTransformSpeed * Time.deltaTime);
                //currentItem.transform.rotation = Quaternion.Lerp(currentItem.transform.rotation, itemAnchor.rotation, itemTransformSpeed * Time.deltaTime);
                //maybe scale as well?
            }


            if (_input.use)
            {
                currentUsable = currentItem.GetComponent<IUsable>();
                currentUsable.Use();
                
            }
        }
        _input.use = false;
    }

    void PickUp()
    {
        currentItem = targetItem;
        targetItem = null;
        currentItem.transform.SetParent(gameObject.transform);
        currentItem.GetComponent<Rigidbody>().isKinematic = true;
    }
}
