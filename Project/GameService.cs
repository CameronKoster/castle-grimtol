using System.Collections.Generic;
using HairyPorter.Project.Interfaces;
using HairyPorter.Project.Models;

namespace HairyPorter.Project
{
  public class GameService : IGameService
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

    public void GetUserInput()
    {

    }

    public void Go(string direction)
    {

    }

    public void Help()
    {

    }

    public void Inventory()
    {

    }

    public void Look()
    {

    }

    public void Quit()
    {

    }

    public void Reset()
    {

    }

    public void Setup()
    {
      Room breakroom = new Room("Breakroom", "The Breakroom");
      Room lecture = new Room("Lecture", "The Lecture Room");
      Room laboratory = new Room("Laboratory", "The Laboratory");
      Room jake = new Room("Jake's Office", "Jake's Office");
      Room zach = new Room("Zach's Office", "Zach's Office");

      Item intellisense = new Item("Intellisense", "The Developer's Intellisense")
    }

    public void StartGame()
    {

    }

    public void TakeItem(string itemName)
    {

    }

    public void UseItem(string itemName)
    {

    }
    public GameService()
    {

    }
  }
}