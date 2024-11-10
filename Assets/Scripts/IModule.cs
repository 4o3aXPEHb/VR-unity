using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModule 
{
    bool isCompleted { get; set; }
    void ModuleIsComplete();
    void ModuleIsError();
}
