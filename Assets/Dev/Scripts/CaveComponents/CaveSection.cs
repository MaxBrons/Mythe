using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CaveSection : MonoBehaviour
{
    private enum CaveSectionType { Long, LongDoor, Closed, ClosedDoor, CornerL, CornerR, Intersection }

    [SerializeField] private CaveSectionType _type;

    private void Start() => Invoke(Constants._caveSectionFunctionName, 2f);
    private void Save() {
        CaveGenerator.Instance.AddCaveData(new CaveSectionData(
            new float[3] { transform.position.x, transform.position.y, transform.position.z },
            new float[3] { transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z },
            (int)_type));
    }
}

[System.Serializable]
public class CaveSectionData
{
    public float[] _position { get; }
    public float[] _rotation { get; }
    public int _caveSectionType { get; }
    public CaveSectionData(float[] postition, float[] rotation, int caveSectionType) {
        _position = postition;
        _rotation = rotation;
        _caveSectionType = caveSectionType;
    }
}
