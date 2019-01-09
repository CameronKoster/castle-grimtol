using System.Collections.Generic;
using HarryPorter.Project.Interfaces;

namespace HarryPorter.Project.Models
{
  public class Player : IPlayer
  {
    public string PlayerName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public List<Item> Inventory { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
  }
}