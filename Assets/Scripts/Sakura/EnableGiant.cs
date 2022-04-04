using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using System;

public class EnableGiant : RealtimeComponent<EnableGiantModel>
{

    [SerializeField] GameObject _giant;
    [SerializeField] Realtime _realtime;

  

    protected override void OnRealtimeModelReplaced(EnableGiantModel previousModel, EnableGiantModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.giantOnDidChange -= GiantDidChange;
            
        }
        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
         
                model.giantOn = false;
            }
            currentModel.giantOnDidChange += GiantDidChange;
            
        }
    }

    private void GiantDidChange(EnableGiantModel model, bool value)
    {
        Debug.Log("giant change");
        //_giant.SetActive(value);
        var options = new Realtime.InstantiateOptions
        {
            ownedByClient = true,
            preventOwnershipTakeover = true,
            useInstance = _realtime
        };
        if (_realtime.clientID == 0)
        {
            Realtime.Instantiate(_giant.name, options);
        }
       
    }

    private void OnTriggerEnter(Collider other) //sets trigger zone to enable giant. this is needed so all clients have joined before
                                                //ownership is claimed by client 0. 
    {
        
        if (other.gameObject.tag == "Player")
        {
            model.giantOn = true;
        }
      
    }
}
// prefab of VR Player does not populate player tag because it is a clone. have to figure out how to set each of the three clones as players.
//in the agent chase script (players)