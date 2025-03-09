using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Wormhole : MonoBehaviour
{
    public Transform wormholeEntrance;
    public Transform wormholeExit;
    
    public Transform WormholeEntrance => wormholeEntrance;
    public Transform WormholeExit => wormholeExit;
}
