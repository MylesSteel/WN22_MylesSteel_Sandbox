using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class SyncAnimation : RealtimeComponent<SyncAnimationModel>
{
    public Realtime _realtime;
    public RealtimeTransform _ownAnimation;
    public void GetClient()
    {
        
        if(realtime.clientID == 0)
        {
            _ownAnimation.RequestOwnership();
        }
    }
}
