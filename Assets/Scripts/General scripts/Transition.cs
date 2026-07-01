using UnityEngine;
using System.Collections;
public class Transition : MonoBehaviour
{
    [SerializeField]private GameObject[] transition;
    void Start()
    {
        StartCoroutine(TransitionCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator TransitionCoroutine()
    {
        int i=Random.Range(0,3);
        if(i==0)
        {
            transition[0].SetActive(true);
            yield return new WaitForSeconds(1);
            transition[0].SetActive(false);
        }
        if(i==1)
        {
            transition[1].SetActive(true);
            yield return new WaitForSeconds(1);
            transition[1].SetActive(false);
        }
        if(i==2)
        {
            transition[2].SetActive(true);
            yield return new WaitForSeconds(1);
            transition[2].SetActive(false);
        }
    }
}
