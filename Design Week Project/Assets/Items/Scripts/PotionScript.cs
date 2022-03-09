using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PotionScript : MonoBehaviour, IUsable
{
    
    public PlayerSizeData sizeData;

    private SizeControl sizeControl;

    public void Use()
    {
        sizeControl = transform.parent.GetComponent<SizeControl>();
        sizeControl.SetTargetSize(sizeData);
    }
}
