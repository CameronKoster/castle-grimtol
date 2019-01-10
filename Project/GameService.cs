using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;


namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    public IRoom CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

    public void GetUserInput()
    {
      //ask what do you want to do?
      //get userinput and split()
      //switch statement based on first word of userinput
      //case "go"
      //Go(second word)
    }

    public void Go(string direction)
    {
      //CurrentRoom.ChangeRoom(direction)
    }

    public void Help()
    {

    }

    public void Inventory()
    {

    }

    public void Look()
    {
      System.Console.WriteLine($"{CurrentRoom.Description}");
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

      Item intellisense = new Item("Intellisense", "The Developer's Intellisense");

      breakroom.Exits.Add("north", lecture);
      breakroom.Exits.Add("west", "zach");
      breakroom.Exits.Add("south", "jake");
      lecture.Exits.Add("south", "breakroom");
      laboratory.Exits.Add("west", "breakroom");
      jake.Exits.Add("north", "breakroom");
      jake.Exits.Add("east", "laboratory");

      // intellisense.Items.Add("Intellisense", "The Developer's Intellisense");
      lecture.Items.Add(intellisense);

      CurrentRoom = breakroom;
    }

    public void StartGame()
    {
      Setup();
      //while(playing)
      //print room description
      //GetUserInput()
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