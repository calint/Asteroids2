using UnityEngine;

public class AsteroidSmall : MonoBehaviour
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
        Game.score += 50;
        Destroy(gameObject);
        Game.asteroidCount--;
    }
}
