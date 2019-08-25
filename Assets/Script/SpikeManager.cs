using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeManager : MonoBehaviour
{
    public GameObject spike;
    // Start is called before the first frame update
    void Start()
    {
        CreateSpike();
        StartCoroutine(CreateSpikeRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CreateSpikeRoutine()
    {
        while (true)
        {
            CreateSpike();
            yield return new WaitForSeconds(0.4f);

        }
    }
    private void CreateSpike()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.2f, 0.8f), 1.1f, 0));
        pos.z = 0.0f;
        Instantiate(spike, pos, Quaternion.identity);
    }
}
