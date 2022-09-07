using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class RotationSpeedSystem_IJobChunk : JobComponentSystem
{
    private EntityQuery m_Group;
    protected override void OnCreate()
    {
        m_Group = GetEntityQuery(typeof(Rotation), ComponentType.ReadOnly<RotationSpeed_IJobChunk>());
    }

    [BurstCompile]
    struct RotationSpeedJob:IJobChunk
    {
        public float DeltaTime;
        public ArchetypeChunkComponentType<Rotation> RotationType;
        [ReadOnly]
        public ArchetypeChunkComponentType<RotationSpeed_IJobChunk> RotationSpeedType;

        public void Execute(ArchetypeChunk chunk,int chunkIndex,int firstEntityIndex)
        {
            var chunkRotations = chunk.GetNativeArray(RotationType);
            var chunkRotationSpeed = chunk.GetNativeArray(RotationSpeedType);
            for (int i = 0; i < chunk.Count; i++)
            {
                var rotation = chunkRotations[i];
                var rotationSpeed = chunkRotationSpeed[i];
                chunkRotations[i]=new Rotation()
                {
                    Value = math.mul(math.normalize(rotation.Value),quaternion.AxisAngle(math.up(),rotationSpeed.RadiansPerSecond*DeltaTime))
                };
            }
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDenpencies)
    {
        var rotationType = GetArchetypeChunkComponentType<Rotation>();
        var rotationSpeedType = GetArchetypeChunkComponentType<RotationSpeed_IJobChunk>();
        var job = new RotationSpeedJob()
        {
            RotationType = rotationType,
            RotationSpeedType = rotationSpeedType,
            DeltaTime = Time.DeltaTime
        };
        return job.Schedule(m_Group,inputDenpencies);
    }

}
