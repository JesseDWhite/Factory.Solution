using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      this.JoinEntities = new HashSet<MachineEngineer>();
    }

    public int MachineId { get; set; }
    public string Name { get; set; }
    public string MachineType { get; set; }
    public float AverageRepairTime { get; set; }
    public string RepairsNeeded { get; set; }

    public virtual ICollection<MachineEngineer> JoinEntities { get; set; }
  }
}