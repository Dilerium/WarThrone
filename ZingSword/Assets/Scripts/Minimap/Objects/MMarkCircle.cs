using UnityEngine;
using System.Collections;

/// <summary>
/// The circlur mark object in the minimap 
/// </summary>
public class MMarkCircle : MonoBehaviour 
{
    /// <summary>
    /// Reference to the MObject associated with this class
    /// </summary>
    private MObject _mObj;

    public MObject MObj { get { return _mObj; } set { _mObj = value; } }

    void Awake()
    {
        if (_mObj == null) _mObj = transform.GetComponentInParentRecursively<MObject>();
    }

    void Start () 
    {
        animation.PlayQueued(animation.clip.name);
    }
    
    void Update () 
    {
        //TODO animation event instead
        if (!animation.isPlaying)
            _mObj.SelfDestruct();
    }
}
