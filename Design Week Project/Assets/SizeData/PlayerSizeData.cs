using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Size Data")]
public class PlayerSizeData : ScriptableObject
{
    [Header("Mesh Scale")]
    public float scale;
    [Header("Camera Parameter")]
    public float FOV;
    [Header("First Person Controller Parameter")]
    public float speed;
    public float sprintSpeed;
    public float jumpHeight;
    public float groundedOffSet;
    public float groundedRadius;
    [Header("Character Controller Parameter")]
    public float slopeLimit;
    public float stepOffset;
}
