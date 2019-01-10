using System.Collections.Generic;
using HairyPorter.Project.Interfaces;

namespace HairyPorter.Project.Models
{
  public class Player : IPlayer
  {
    public string PlayerName { get; set; }
    public List<Item> Inventory { get; set; }
  }
}