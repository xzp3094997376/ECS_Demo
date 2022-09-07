using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[Serializable]
public struct RotationSpeed_IJobChunk : IComponentData
{
    public float RadiansPerSecond;
}
