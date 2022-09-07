using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class SpawnerWorld : MonoBehaviour
{
    public GameObject Prefab;
    public int CountX = 10;
    public int CountY = 10;
    // Start is called before the first frame update
    void Start()
    {
        var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
        var entityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(Prefab, settings);
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        for (var i = 0; i < CountX; i++)
        {
            for (var j = 0; j < CountY; j++)
            {
                var instance = entityManager.Instantiate(entityPrefab);
                var position = transform.TransformPoint(new float3(i * 1.3F,noise.cnoise(new float2(i,j)*0.21f),j*1.3F));
                entityManager.SetComponentData(instance,new Translation()
                {
                    Value = position
                });
            }
        }
    }
}
