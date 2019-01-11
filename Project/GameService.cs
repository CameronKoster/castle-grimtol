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
    private bool Playing = true;

    public void GetUserInput()
    {
      System.Console.WriteLine("What would you like to do?");
      string where = Console.ReadLine().ToLower();
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
        System.Console.WriteLine($"{item.Name}");
      }
    }

    public void Look()
    {
      System.Console.WriteLine($"{CurrentRoom.Description}");
    }

    public void Quit()
    {
      Playing = false;
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

      Item intellisense = new Item("intellisense", "The Developer's Intellisense");

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
      Look();
      while (Playing)
      {
        if (CurrentRoom.Name == "Zach's Office")
        {
          System.Console.WriteLine("You lose");
          break;
        }
        //check if the CurrentRoom.winnable is true and if so implement you won logic
        GetUserInput();
      }
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

    public void UseItem(string itemName)
    {
      Item itemToUse = CurrentPlayer.Inventory.Find(item => item.Name == itemName);
      if (itemToUse == null)
      {
        System.Console.WriteLine("Must use item");
      }
      else if (CurrentRoom.Name == "Laboratory" && itemToUse.Name == "intellisense")
      {
        CurrentRoom.Winnable = true;
        System.Console.WriteLine("CodeWorksdor wins the house cup!!!");
      }
      //find the item in the players inventory with the itemName
      //null check
      //if using intellisense and in the lab then switch the bool winnable to true

    }

    public GameService()
    {

    }
  }
}