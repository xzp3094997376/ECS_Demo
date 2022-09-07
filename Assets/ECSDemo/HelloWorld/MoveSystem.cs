using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Scenes;
using UnityEngine;

[UpdateInGroup(typeof(InitializationSystemGroup))]
[UpdateBefore(typeof(SceneSystem))]
public class MoveSystem : ComponentSystem
{
    protected override void OnUpdate() { }
}