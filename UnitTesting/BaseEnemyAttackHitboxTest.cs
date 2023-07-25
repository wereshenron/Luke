using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class BaseEnemyAttackHitboxTests
{
    private GameObject testEnemyObject;
    private BaseEnemyAttackHitbox testBaseEnemyAttackHitbox;
    private GameObject testPlayerObject;
    private PlayerHealth testPlayerHealth;
    private LeapForward testLeapForward;

    [SetUp]
    public void Setup()
    {
        testEnemyObject = new GameObject("TestEnemy");
        testBaseEnemyAttackHitbox = testEnemyObject.AddComponent<BaseEnemyAttackHitbox>();

        testPlayerObject = new GameObject("TestPlayer");
        testPlayerHealth = testPlayerObject.AddComponent<PlayerHealth>();
        testLeapForward = testPlayerObject.AddComponent<LeapForward>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(testEnemyObject);
        Object.DestroyImmediate(testPlayerObject);
    }

    [Test]
    public void BaseEnemyAttackHitbox_DamagePlayer_PhysicalAttack()
    {
        testEnemyObject.tag = "Enemy";
        testPlayerObject.tag = "Player";
        testBaseEnemyAttackHitbox.attackDamage = 5f;
        testLeapForward.isLeaping = false;

        float initialPlayerHealth = testPlayerHealth.Health;

        testBaseEnemyAttackHitbox.OnCollisionEnter2D(new Collision2D
        {
            collider = testPlayerObject.GetComponent<Collider2D>()
        });

        Assert.AreEqual(initialPlayerHealth - testBaseEnemyAttackHitbox.attackDamage, testPlayerHealth.Health);
    }

    [Test]
    public void BaseEnemyAttackHitbox_DamagePlayer_ProjectileAttack()
    {
        testEnemyObject.tag = "Projectile";
        testPlayerObject.tag = "Player";
        testBaseEnemyAttackHitbox.projectileDamage = 5f;

        float initialPlayerHealth = testPlayerHealth.Health;

        testBaseEnemyAttackHitbox.OnCollisionEnter2D(new Collision2D
        {
            collider = testPlayerObject.GetComponent<Collider2D>()
        });

        Assert.AreEqual(initialPlayerHealth - testBaseEnemyAttackHitbox.projectileDamage, testPlayerHealth.Health);
    }

    // You can add more tests to cover additional scenarios.
}
