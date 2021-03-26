using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BaseCanon : MonoBehaviour
{
    public virtual void CreateBullet() { }
    public virtual void StartShooting() { }
    public virtual void StopShooting() { }
}
