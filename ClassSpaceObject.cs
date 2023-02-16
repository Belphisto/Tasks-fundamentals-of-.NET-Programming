using System;
using static System.Console;

namespace Space
{
    public interface ISpaceObject
    {
        public string _type {get;}
        public string _name {get;}
    }
    public abstract class SpaceObject : ISpaceObject
    {
        public string _type {get;set;} = "SpaceObject";
        public string _name {get;set;} = "NoName";
        public SpaceObject(){}
        public SpaceObject (string type, string name) {_type = type; _name = name;}
       public abstract ulong GetDistance();
       public abstract double GetSpeed();
       public virtual string GetName() => this._name;
       public abstract void PrintObject();
        /*{
        WriteLine($"The  {_type} {_name} has flown a distance of {this.GetDistance()} km since launch. ");
        WriteLine($"Speed is {this.GetSpeed()} km/s");
        }*/
    }

    public interface ISpaceObjects<out T> where T : SpaceObject
    {
        T SpaceObject {get;}
        T GetSpaceObject();
    }

    public interface IPushable<in T> where T : SpaceObject
    {
        void Push(T obj);
    }

}

