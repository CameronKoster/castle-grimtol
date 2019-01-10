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
      System.Console.WriteLine("Where would you like to do?");
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
        case "takeItem":
          TakeItem(itemName);
          break;
        case "useItem":
          UseItem(itemName);
          break;
        default:
          System.Console.WriteLine("Invalid Command");
          break;
      }
    }


    public void Go(string direction)
    {
      if (CurrentRoom.Exits.ContainsKey(direction))
      {
        CurrentRoom = CurrentRoom.Exits[direction];
        Look();
      };
      System.Console.WriteLine("NOT A VALID DIRECTION");
    }

    public void Help()//need help here
    {
      System.Console.WriteLine($"{CurrentPlayer.commands}");
    }

    public void Inventory()
    {
      System.Console.WriteLine($"{CurrentPlayer.Inventory}");
    }

    public void Look()
    {
      System.Console.WriteLine($"{CurrentRoom.Description}");
    }

    public void Quit()
    {
      playing = false;
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
      breakroom.Exits.Add("west", zach);
      breakroom.Exits.Add("south", jake);
      lecture.Exits.Add("south", breakroom);
      laboratory.Exits.Add("west", breakroom);
      jake.Exits.Add("north", breakroom);
      jake.Exits.Add("east", laboratory);


      lecture.Items.Add(intellisense);

      CurrentRoom = breakroom;
    }

    public void StartGame()
    {


      Setup();

      while (playing)
      {
        if (Exits.ContainsKey(direction))
        {
          System.Console.WriteLine($"{CurrentRoom.Description}");
        }
      }
      GetUserInput();
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