using System;
using System.Threading;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class CubesManager : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    private const int dimenstion=10;
    private JobHandle _jobHandle;
    private TransformAccessArray _transforms;
    private void Start()
    {
        _transforms = new TransformAccessArray(dimenstion*dimenstion*dimenstion);

        for (var x = 0f; x < dimenstion; ++x)
        {
            for (var y = 0f; y < dimenstion; ++y)
            {
                for (var z = 0f; z < dimenstion; ++z)
                {
                    var position = new Vector3(x,y,z);
                    var cube = Instantiate(_prefab, position, Quaternion.identity);
                    _transforms.Add(cube.transform);
                }
            }
        }
    }

    private void Update()
    {
        
        _jobHandle.Complete();
        if (_jobHandle.IsCompleted)
        {
            var rotatorJob = new Rotator();
            _jobHandle = rotatorJob.Schedule(_transforms);
            JobHandle.ScheduleBatchedJobs();
        }
    }
}