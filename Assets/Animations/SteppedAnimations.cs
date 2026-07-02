using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SteppedAnimations : MonoBehaviour
{
    [SerializeField]
    private float m_animationFps = 8f;

    private Animator m_animator;
    private float m_accumulator;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_animator.enabled = false;
    }

    private void Update()
    {
        float step = 1f / m_animationFps;
        m_accumulator += Time.deltaTime;

        while (m_accumulator >= step)
        {
            m_animator.Update(step);
            m_accumulator -= step;
        }
    }
}
