using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class AttackHitboxTests
{
    private GameObject testPlayerObject;
    private AttackHitbox testAttackHitbox;
    private GameObject testEnemyObject;
    private BasicEnemy testBasicEnemy;

    [SetUp]
    public void Setup()
    {
        testPlayerObject = new GameObject("TestPlayer");
        testAttackHitbox = testPlayerObject.AddComponent<AttackHitbox>();

        testEnemyObject = new GameObject("TestEnemy");
        testBasicEnemy = testEnemyObject.AddComponent<BasicEnemy>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(testPlayerObject);
        Object.DestroyImmediate(testEnemyObject);
    }

    [Test]
    public void AttackHitbox_DamageEnemy_PhysicalAttack()
    {
        testPlayerObject.tag = "Player";
        testEnemyObject.tag = "Enemy";
        testAttackHitbox.attackDamage = 5f;

        float initialEnemyHealth = testBasicEnemy.Health;

        testAttackHitbox.OnCollisionEnter2D(new Collision2D
        {
            collider = testEnemyObject.GetComponent<Collider2D>()
        });

        Assert.AreEqual(initialEnemyHealth - testAttackHitbox.attackDamage, testBasicEnemy.Health);
    }

    [Test]
    public void AttackHitbox_DamageEnemy_ThrowAttack()
    {
        testPlayerObject.tag = "Throw";
        testEnemyObject.tag = "Enemy";
        testAttackHitbox.attackDamage = 5f;

        float initialEnemyHealth = testBasicEnemy.Health;

        testAttackHitbox.OnCollisionEnter2D(new Collision2D
        {
            collider = testEnemyObject.GetComponent<Collider2D>()
        });

        Assert.AreEqual(initialEnemyHealth - testAttackHitbox.attackDamage, testBasicEnemy.Health);
    }

    // You can add more tests to cover additional scenarios.
}
