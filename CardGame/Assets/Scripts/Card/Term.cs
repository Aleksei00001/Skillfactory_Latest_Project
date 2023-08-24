using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


    //[SerializeField][Serializable][Flags] public enum qqqqqqq
    //{
    //    Red = 1,
    //    Green = 2,
    //    Blue = 1073741824
    //}
public class Term : MonoBehaviour
{
    [SerializeField] private List<string> m_AllTerms;
    public List<string> allTerms => m_AllTerms;

    //[SerializeField] private qqqqqqq a;



    [SerializeField][Serializable] public class Example : MonoBehaviour
    {
        public Color Color;
    }

    //[Serializable][SerializeField] public class TermForList
    //{
    //    [SerializeField] private string m_TermName;
    //    public string termName => m_TermName;
    //    [SerializeField] private bool m_TermCheck;
    //    public bool termCheck => m_TermCheck;

    //    public void SetTermCheck(bool termCheck)
    //    {
    //        m_TermCheck = termCheck;
    //    }

    //    public TermForList(string termName, bool termCheck)
    //    {
    //        this.m_TermName = termName;
    //        this.m_TermCheck = termCheck;
    //    }

    //}

    public void AddTerm(string termName)
    {
        for (int i = 0; i < m_AllTerms.Count; i++)
        {
            if (m_AllTerms[i] == termName)
            {
                return;
            }
        }
        m_AllTerms.Add(termName);
    }

    public void RemoveTerm(string termName)
    {
        m_AllTerms.Remove(termName);
    }

    private void Awake()
    {
        //TermForList newTermForList = new TermForList("Enemy", false);
        //m_AllTerms.Add(new TermForList("Enemy", false));
        //m_AllTerms.Add(new TermForList("Splash", false));
    }
}
