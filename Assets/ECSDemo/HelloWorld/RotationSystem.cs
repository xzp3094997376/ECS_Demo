
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

// This system updates all entities in the scene with both a RotationSpeed_ForEach and Rotation component.

public class RotationSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        float deltaTime = Time.DeltaTime;
        var jobHandle = Entities.ForEach((ref Rotation rotation, in RotationCubeComponent rotationSpeed) =>
        {
            /* 旋转Cube，代码逻辑不用管，这里可以是其他任何逻辑 */
            rotation.Value = math.mul(math.normalize(rotation.Value),
                quaternion.AxisAngle(math.up(), rotationSpeed.RadiansPerSecond * deltaTime));
        }).Schedule(inputDependencies);
        return jobHandle;
    }
}
