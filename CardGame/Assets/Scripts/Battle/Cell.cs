using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private int m_NumberX;
    public int numberX => m_NumberX;
    private int m_NumberY;
    public int numberY => m_NumberY;

    [SerializeField] private Enemy m_Enemy;
    public Enemy enamy => m_Enemy;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Term m_TermsOfUse;
    public Term termsOfUse => m_TermsOfUse;

    public void SpriteRendererOn()
    {
        spriteRenderer.enabled = true;
    }
    public void SpriteRendererOff()
    {
        spriteRenderer.enabled = false;
    }

    private void Start()
    {
        m_TermsOfUse.AddTerm("Cell");
    }

    public void SetNumber(int x, int y)
    {
        m_NumberX = x;
        m_NumberY = y;
    }

    public void SetPosition(float x, float y)
    {
        transform.position = new Vector3(x, y, 10);
    }

    public void AddEnemy(Enemy enemy)
    {
        m_Enemy = enemy;
        m_Enemy.transform.SetParent(this.transform);
        m_TermsOfUse.AddTerm("Enemy");
    }
    public void RemoveEnemy(Enemy enemy)
    {
        m_Enemy = null;

        m_TermsOfUse.RemoveTerm("Enemy");
    }

    private void Update()
    {
        if (m_Enemy != null)
        {
            m_Enemy.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 5);
        }
        else
        {
            RemoveEnemy(null);
        }
    }
}