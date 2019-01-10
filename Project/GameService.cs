using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;


namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    public IRoom CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }
    bool playing = true;

    public void GetUserInput()
    {
      System.Console.WriteLine("What would you like to do?");
      string where = Console.ReadLine();
      string[] whereArr = where.Split(" ");
      string command = whereArr[0];
      string value = "";
      if (whereArr.Length > 1)
      {
        value = whereArr[1];
      }
      switch (command)
      {
        case "look":
          Look();
          break;
        case "go":
          Go(value);
          break;
        case "help":
          Help();
          break;
        case "quit":
          Quit();
          break;
        case "inventory":
          Inventory();
          break;
        case "reset":
          Reset();
          break;
        case "take":
          TakeItem(value);
          break;
        case "use":
          UseItem(value);
          break;
        default:
          System.Console.WriteLine("Invalid Command");
          break;
      }
    }


    public void Go(string key)
    {
      if (CurrentRoom.Exits.ContainsKey(key))
      {
        CurrentRoom = CurrentRoom.Exits[key];
        Look();
      }
      else
      {
        System.Console.WriteLine("NOT A VALID DIRECTION");
      }
    }

    public void Help()
    {
      System.Console.WriteLine("For a description of your current location, type 'look'");
      System.Console.WriteLine("To move into another room, type 'go', followed by a direction, such as 'north'");
      System.Console.WriteLine("For a list of useable commands, type 'help'");
      System.Console.WriteLine("To quit the game, type 'quit'");
      System.Console.WriteLine("To see current items in your inventory, type 'inventory'");
      System.Console.WriteLine("To return to the start of the game, type 'reset'");
      System.Console.WriteLine("To take an item from a room, type 'take item'");
      System.Console.WriteLine("To use an item from your inventory, type 'use item'");
    }

    public void Inventory()
    {
      foreach (var item in CurrentPlayer.Inventory)
      {
        System.Console.WriteLine($"{CurrentPlayer.Inventory}");
      }
    }

    public void Look()
    {
      foreach (var room in CurrentRoom.Description)
      {
        System.Console.WriteLine($"{CurrentRoom.Description}");
      }
    }

    public void Quit()
    {
      playing = false;
    }

    public void Reset()
    {
      Setup();
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
      breakroom.Exits.Add("west", zach);
      breakroom.Exits.Add("south", jake);
      lecture.Exits.Add("south", breakroom);
      laboratory.Exits.Add("west", breakroom);
      jake.Exits.Add("north", breakroom);
      jake.Exits.Add("east", laboratory);


      lecture.Items.Add(intellisense);

      CurrentRoom = breakroom;
      System.Console.Write("Please enter name:");
      string playerName = Console.ReadLine();
      CurrentPlayer = new Player(playerName);
    }

    public void StartGame()
    {
      Setup();
      GetUserInput();
    }

    public void TakeItem(string itemName)
    {
      Item foundItem = CurrentRoom.Items.Find(item => item.Name == itemName);
      if (foundItem == null)
      {
        System.Console.WriteLine("No item found");
      }
      else
      {
        CurrentRoom.Items.Remove(foundItem);
        CurrentPlayer.Inventory.Add(foundItem);
        Inventory();
      }
    }

    public void UseItem(string Item)
    {

    }

    public void Play()
    {
      Setup();
      while (playing)
      {

      }
    }
    public GameService()
    {

    }
  }
}