using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class PartyMenschen : MonoBehaviour
{
    private PartyMensch[] _menschen;

    private void Awake()
    {
        _menschen = Enumerable.Range(0, transform.childCount).Select(transform.GetChild).Select(c => c.GetComponent<PartyMensch>()).Where(p => p != null).ToArray();
    }

    public Transform GetRandomTransform()
    {
        var rnd = Random.Range(0, _menschen.Length);
        return _menschen[rnd].TalkingPoint;
    }
}
