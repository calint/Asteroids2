using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AsteroidMedium : MonoBehaviour
{
    void Start()
    {
        Game.asteroidCount++;
    }

    void Update()
    {
        transform.position = Game.RollOver(transform.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        Game.score += 30;
        Rigidbody rb = GetComponent<Rigidbody>();
        for (int i = 0; i < Game.asteroidMediumSplitNum; i++)
        {
            Vector3 rnd = Random.insideUnitSphere.normalized;
            rnd.y = 0;
            Vector3 pos = transform.position + 0.5f * transform.localScale.x * rnd;
            GameObject o = Instantiate(Game.prefabAsteroidSmall, pos, Random.rotation);
            Rigidbody orb = o.GetComponent<Rigidbody>();
            orb.linearVelocity = rb.linearVelocity + Game.asteroidMediumSplitVelocity * rnd;
            orb.angularVelocity = Game.asteroidMediumSplitRandomRotationScale * rnd;
        }
        Destroy(gameObject);
        Game.asteroidCount--;
    }
}
