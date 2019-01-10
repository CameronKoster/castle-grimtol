using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project.Models
{
  public class Room : IRoom
  {



    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }



    // public void addExitsToDict(string, IRoom)    //needs dictionary here - key = direction, pair = room it exits to
    // {
    // Public void AddPet(string type, Animal pet)
    // {
    //   if (!Pets.ContainsKey(type))
    //   {
    //     Pets.Add(type, new List<Animal>());
    //   }
    //   Pets[type].Add(pet);
    // }
    //  
    // }


    public Room ChangeRoom(string direction) //need to import service. Need access to currentRoom so room can change based on user input
    {
      // bool playing = true;
      // while (playing)
      // {
      //   System.Console.Write("Which direction would you like to go?");
      // string direction = Console.ReadLine();

      if (Exits.ContainsKey(direction))
      {

      }
      // { //don't know what to do in the ^^^^^^^parens? Saying "if readline(N,E,S,W) == key in dictionary(N,E,S,W), I can update current room. 

      // }
      // }
      // return room;
    }

    public Item takeItem(Item item) //need to import service. Need access to currentRoom so if currentRoom == roomWithItem, you can run this method
    {
      if (currentRoom == lecture room)

        return item;
    }



    public Room(string name, string description) //does this need List<Items>, Dictionary<Exits>???
    {
      Name = name;
      Description = description;
      Items = new List<Item>(); //not sure if correct. Get help. YES CORRECT PW
      Exits = new Dictionary<string, IRoom>(); //not sure if correct. Get help.
    }

    // public Dog(string name, int legs, string gender) : base(name, legs, gender)  //I don't understand what a line like this is doing?
    // {
    // }
  }
}