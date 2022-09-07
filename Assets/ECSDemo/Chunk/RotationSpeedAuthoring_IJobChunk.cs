using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[RequiresEntityConversion]
public class RotationSpeedAuthoring_IJobChunk : MonoBehaviour, IConvertGameObjectToEntity
{
    public float DegreesPerSecond = 360.0f;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var  data=new RotationSpeed_IJobChunk()
        {
            RadiansPerSecond =math.radians(DegreesPerSecond)
        };
        dstManager.AddComponentData(entity, data);
    }
}
