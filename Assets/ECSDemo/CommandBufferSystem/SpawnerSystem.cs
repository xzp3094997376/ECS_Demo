using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;


public class SpawnerSystem : JobComponentSystem
{
    private BeginInitializationEntityCommandBufferSystem m_EntityCommandBufferSystem;

    protected override void OnCreate()
    {
        m_EntityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer().ToConcurrent();
        var jobHandle = Entities.ForEach((Entity entity, int entityInQueryIndex, in SpawnFrom_Entity spwarEntity) =>
        {
            var instance = commandBuffer.Instantiate(entityInQueryIndex,spwarEntity.Prefab);
            commandBuffer.DestroyEntity(entityInQueryIndex,entity);
        }).Schedule(inputDeps);
        m_EntityCommandBufferSystem.AddJobHandleForProducer(jobHandle);
        return jobHandle;
    }
}
