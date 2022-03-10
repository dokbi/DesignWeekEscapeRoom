using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PotionScript : MonoBehaviour, IUsable
{
    
    public PlayerSizeData sizeData;

    private SizeControl sizeControl;
    private ItemHandler owner;
    private bool used;
    private Renderer potionRenderer;

    private void Awake()
    {
        potionRenderer = transform.GetChild(0).GetComponent<Renderer>();
    }

    private void Update()
    {
        if (used)
        {
            potionRenderer.material.color = Color.Lerp(potionRenderer.material.color, Color.clear, 1.5f * Time.deltaTime);
        }
    }

    public void Use(ItemHandler _owner)
    {
        owner = _owner;
        sizeControl = owner.GetComponent<SizeControl>();
        sizeControl.SetTargetSize(sizeData);
        Destroy(gameObject, 3);
        used = true;
    }


}
