using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[UpdateInGroup(typeof(InitializationSystemGroup))]
[UpdateAfter(typeof(MoveSystem))]
public class LoveSystem : ComponentSystem
{
    protected override void OnUpdate() { }  
}
