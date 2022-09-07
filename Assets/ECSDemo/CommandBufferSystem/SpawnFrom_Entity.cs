using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

public struct SpawnFrom_Entity : IComponentData
{
    public Entity Prefab;
}
