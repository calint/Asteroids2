using UnityEngine;

public class AsteroidLarge : MonoBehaviour
{
    void Start()
    {
        Game.asteroidCount++;
    }

    void Update()
    {
        transform.position = Game.GameAreaRoll(transform.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        Game.score += 10;
        Rigidbody rb = GetComponent<Rigidbody>();
        for (int i = 0; i < Game.asteroidLargeSplitNum; i++)
        {
            Vector3 rnd = Random.insideUnitSphere.normalized;
            rnd.y = 0;
            GameObject o = Instantiate(Game.prefabAsteroidMedium, transform.position + transform.localScale.x * rnd, Random.rotation);
            Rigidbody orb = o.GetComponent<Rigidbody>();
            orb.linearVelocity = rb.linearVelocity + Game.asteroidLargeSplitVelocity * rnd;
            orb.angularVelocity = Game.asteroidLargeSplitRandomRotationScale * rnd;
        }
        Destroy(gameObject);
        Game.asteroidCount--;
    }
}
