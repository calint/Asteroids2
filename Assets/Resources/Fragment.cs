using UnityEngine;

public class Fragment : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, Game.fragmentLifetime);
    }

}
