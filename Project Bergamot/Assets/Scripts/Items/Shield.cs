using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Item
{
    [SerializeField] ParticleSystem partSys;

    public override void Use(GameObject car)
    {
        GameObject shield = Instantiate(gameObject, car.transform);
        shield.GetComponent<Animator>().enabled = true;
        FindObjectOfType<AudioManager>().Play("ShieldActivate");
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Projectile"))
            return;

        FindObjectOfType<AudioManager>().Play("ShieldBreak");
        Destroy(other.gameObject);
        StartCoroutine(DestroyShield());
    }

    IEnumerator DestroyShield()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
        partSys.Play();
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
