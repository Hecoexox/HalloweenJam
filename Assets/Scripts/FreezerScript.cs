using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezerscript : MonoBehaviour
{
    public GameObject KaramelCandy;
    public GameObject ChocolatteCandy;
    public GameObject GummyCandy;
    public GameObject LollipopCandy;
    public float itemSpeed = 1f;
    private Vector3 CandyStartPosition = new Vector3(-56.14f, 42.26f, 3.82f);
    private Vector3 CandyEndPosition = new Vector3(-53.66f, 42.26f, 3.82f);
    private Vector3 CandyLastPosition = new Vector3(-51f, 42.26f, 3.82f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KaramelCandy"))
        {
            StartCoroutine(MoveCandy(other));
        }
        else if (other.CompareTag("LollipopCandy"))
        {
            Destroy(other.gameObject);
            GameObject LollipopInstance = Instantiate(LollipopCandy, transform.position + Vector3.up * 3, transform.rotation);
            LollipopInstance.tag = "LollipopCandy";
        }
        else if (other.CompareTag("GummyCandy"))
        {
            Destroy(other.gameObject);
            GameObject GummyInstance = Instantiate(GummyCandy, transform.position + Vector3.up * 3, transform.rotation);
            GummyInstance.tag = "GummyCandy";
        }
        else if (other.CompareTag("ChocolatteCandy"))
        {
            Destroy(other.gameObject);
            GameObject ChocolatteInstance = Instantiate(ChocolatteCandy, transform.position + Vector3.up * 3, transform.rotation);
            ChocolatteInstance.tag = "ChocolatteCandy";
        }
    }

    private IEnumerator MoveCandy(Collider candyCollider)
    {
        Transform candyTransform = candyCollider.transform;
        Rigidbody candyRigidbody = candyCollider.GetComponent<Rigidbody>();

        // Eðer Rigidbody yoksa iþlemi durdur
        if (candyRigidbody == null)
        {
            Debug.LogWarning("Rigidbody bulunamadý.");
            yield break;
        }

        candyTransform.position = CandyStartPosition;

        // Rotation sýfýrla, Collider ve isKinematic kapat
        candyTransform.rotation = Quaternion.identity;
        candyCollider.enabled = false;
        candyRigidbody.isKinematic = true;

        // Ýlk hedefe doðru hareket et
        while (Vector3.Distance(candyTransform.position, CandyEndPosition) > 0.01f)
        {
            candyTransform.position = Vector3.MoveTowards(candyTransform.position, CandyEndPosition, itemSpeed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(3);

        // Son hedefe doðru hareket et
        while (Vector3.Distance(candyTransform.position, CandyLastPosition) > 0.01f)
        {
            candyTransform.position = Vector3.MoveTowards(candyTransform.position, CandyLastPosition, itemSpeed * Time.deltaTime);
            yield return null;
        }

        // Collider ve isKinematic yeniden etkinleþtir
        candyCollider.enabled = true;
        candyRigidbody.isKinematic = false;

        Instantiate(KaramelCandy, transform.position + Vector3.up * 3, Quaternion.identity).tag = "KaramelCandy";
    }
}
