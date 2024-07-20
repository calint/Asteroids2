using UnityEngine;
using UnityEngine.Assertions;

public class Game : MonoBehaviour
{
    public static float gameAreaZ = 12;
    public static float gameAreaX = 19;
    public static int asteroidMediumSplitNum = 4;
    public static float asteroidMediumSplitVelocity = 3;
    public static float asteroidMediumSplitRandomRotationScale = 1;
    public static int asteroidLargeSplitNum = 4;
    public static float asteroidLargeSplitVelocity = 2;
    public static float asteroidLargeSplitRandomRotationScale = 0.5f;
    public static float fragmentLifetime = 0.5f;

    public static GameObject prefabAsteroidLarge;
    public static GameObject prefabAsteroidMedium;
    public static GameObject prefabAsteroidSmall;
    public static GameObject prefabShip;
    public static GameObject prefabShipThrust;
    public static GameObject prefabShipBullet;
    public static GameObject prefabFragment;

    public static int asteroidCount;
    public static int level;
    public static int asteroidsLevel = 1;
    public static int score;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initialize()
    {
        Debug.Log("Initialize Game");
        prefabAsteroidLarge = Resources.Load<GameObject>("AsteroidLarge");
        Assert.IsNotNull(prefabAsteroidLarge);

        prefabShipBullet = Resources.Load<GameObject>("ShipBullet");
        Assert.IsNotNull(prefabShipBullet);

        prefabAsteroidMedium = Resources.Load<GameObject>("AsteroidMedium");
        Assert.IsNotNull(prefabAsteroidMedium);

        prefabAsteroidSmall = Resources.Load<GameObject>("AsteroidSmall");
        Assert.IsNotNull(prefabAsteroidSmall);

        prefabFragment = Resources.Load<GameObject>("Fragment");
        Assert.IsNotNull(prefabFragment);
    }

    public void Update()
    {
        if (asteroidCount == 0)
        {
            level++;
            CreateAsteroids(level * asteroidsLevel);
        }
    }

    public static Vector3 RollOver(Vector3 position)
    {
        if (position.z > gameAreaZ)
        {
            position.z -= 2 * gameAreaZ;
        }
        else if (position.z < -gameAreaZ)
        {
            position.z += 2 * gameAreaZ;
        }
        if (position.x > gameAreaX)
        {
            position.x -= 2 * gameAreaX;
        }
        else if (position.x < -gameAreaX)
        {
            position.x += 2 * gameAreaX;
        }
        return position;
    }

    public static bool IsInGameArea(Vector3 position)
    {
        return position.x > -gameAreaX && position.x < gameAreaX && position.z > -gameAreaZ && position.z < gameAreaZ;
    }

    public static void CreateAsteroids(int num)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject o = Instantiate(prefabAsteroidLarge);
            Vector3 pos = Random.insideUnitSphere.normalized * gameAreaX;
            pos.y = 0;
            o.transform.position = pos;
            Rigidbody orb = o.GetComponent<Rigidbody>();
            Vector3 vel = 3.0f * Random.insideUnitSphere.normalized;
            vel.y = 0;
            orb.linearVelocity = vel;
            orb.angularVelocity = 0.5f * Random.insideUnitSphere.normalized;
        }
    }
}