using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      this.JoinEntities = new HashSet<MachineEngineer>();
    }
    public int EngineerId { get; set; }
    public string Name { get; set; }
    public DateTime DateHired { get; set; }
    public string Level { get; set; }

    public virtual ICollection<MachineEngineer> JoinEntities { get; }
  }
}