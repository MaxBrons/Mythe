using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public static DontDestroyOnLoad Instance;
    private void Awake() {
        Instance = Instance ? Instance : this;
        if (Instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
