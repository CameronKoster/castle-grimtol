using System.Collections.Generic;
using HairyPorter.Project.Models;

namespace HairyPorter.Project.Interfaces
{
  public interface IPlayer
  {
    string PlayerName { get; set; }
    List<Item> Inventory { get; set; }
  }
}
