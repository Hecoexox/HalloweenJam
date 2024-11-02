using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezerscript : MonoBehaviour
{
    public GameObject KaramelCandy;
    public GameObject ChocolatteCandy;
    public GameObject GummyCandy;
    public GameObject LollipopCandy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KaramelCandy"))
        {
            Destroy(other.gameObject);
            GameObject CaramelInstance = Instantiate(KaramelCandy, transform.position + Vector3.up * 3, transform.rotation);
            CaramelInstance.tag = "KaramelCandy";
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
            GummyCandy.tag = "GummyCandy";
        }
        else if (other.CompareTag("ChocolatteCandy"))
        {
            Destroy(other.gameObject);
            GameObject ChocolatteInstance = Instantiate(ChocolatteCandy, transform.position + Vector3.up * 3, transform.rotation);
            ChocolatteInstance.tag = "ChocolatteCandy";
        }
    }
}

