using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Spine.Unity;
using Spine;
using System.Collections;

public class Level : MonoBehaviour
{
   /// public static Level ins;
    [SerializeField] public GameObject[] level;

    public void Awake()
    {
       // Level.ins = this;
    }
    private void Start()
    {
        
    }
}
