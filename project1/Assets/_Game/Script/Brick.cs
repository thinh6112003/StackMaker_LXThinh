using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private ColorBrick colorOfBrick;
    public bool isCollect = false;
    public ColorBrick ColorOfBrick { get => colorOfBrick; set => colorOfBrick = value; }
}
