using System.Collections.Generic;
using HarryPorter.Project.Models;

namespace HarryPorter.Project.Interfaces
{
  public interface IPlayer
  {
    string PlayerName { get; set; }
    List<Item> Inventory { get; set; }
  }
}
