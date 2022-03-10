using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PotionScript : MonoBehaviour, IUsable
{
    
    public PlayerSizeData sizeData;

    private SizeControl sizeControl;
    private ItemHandler owner;
    
    public void Use(ItemHandler _owner)
    {
        owner = _owner;
        sizeControl = owner.GetComponent<SizeControl>();
        sizeControl.SetTargetSize(sizeData);
        Debug.Log("Drink Potion");
    }


}
