using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IArtifact
{
    void Use();
}

public abstract class Artifacts : Item, IArtifact
{
    public uint Power = 500;
    public float Distance = 5.0f;
    public bool isRenewable;
    

    public override void Use()
    {
        base.Use();
    }
}
