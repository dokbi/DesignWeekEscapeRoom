using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PotionScript : MonoBehaviour, IUsable
{
    
    public PlayerSizeData sizeData;

    public SizeControl sizeControl;

    public void Use()
    {
        sizeControl.SetTargetSize(sizeData);
    }
}
