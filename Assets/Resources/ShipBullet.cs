using UnityEngine;

public class BulletScript : MonoBehaviour
{
    void Update()
    {
        if (!Game.IsInGameArea(transform.position))
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject frg = Instantiate(Game.prefabFragment, transform.position, Random.rotation);
        frg.GetComponent<Rigidbody>().angularVelocity = 5.0f * Random.insideUnitSphere.normalized;
        Destroy(gameObject);
    }
}
