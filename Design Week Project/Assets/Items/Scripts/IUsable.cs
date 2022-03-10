using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUsable
{
    public abstract void Use(ItemHandler _owner);
    //public abstract void OnPickUp();
    //public abstract void OnDrop();
}
