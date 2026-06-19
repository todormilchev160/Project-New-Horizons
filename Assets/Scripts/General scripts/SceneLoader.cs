using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    private Animator animator;
    [SerializeField]private float transitiontime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator=GetComponent<Animator>();
    }
    public void LoadScene(string sceneName)
    {
      StartCoroutine(SceneCoroutine(sceneName));
    }
    public IEnumerator SceneCoroutine(string sceneName)
    {
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(transitiontime);
        yield return SceneManager.LoadSceneAsync(sceneName);
        animator.SetTrigger("FadeIn");
    }
}
