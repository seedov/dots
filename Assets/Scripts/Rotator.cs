using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public struct Rotator:IJobParallelForTransform
{
  //  public NativeArray<float> Speeds;
  //  public float DeltaTime;
    public void Execute(int index, TransformAccess transform)
    {
        var currentRotation = transform.rotation.eulerAngles;
        ++currentRotation.y ;//+= DeltaTime * Speeds[index];
        transform.rotation = Quaternion.Euler(currentRotation);
    }

}
