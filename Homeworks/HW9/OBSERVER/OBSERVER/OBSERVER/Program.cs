using System;
using System.Collections.Generic;

interface IStudent
{
    void Update(Object something);
}

interface ITest
{
    void RegisterFlunkey(IStudent someStudent);
    void RemoveFlunkey(IStudent someStudent);
    void NotifyFlunkey();
}

class Session : ITest
{
    Rating retest; // информация о пересдаче

    List<IStudent> flunkeys;
    public Session()
    {
        flunkeys = new List<IStudent>();
        retest = new Rating();
    }
    public void RegisterFlunkey(IStudent someStudent)
    {
        flunkeys.Add(someStudent);
    }

    public void RemoveFlunkey(IStudent someStudent)
    {
        flunkeys.Remove(someStudent);
    }

    public void NotifyFlunkey()
    {
        foreach (IStudent someStudent in flunkeys)
        {
            someStudent.Update(retest);
        }
    }

    public void Result()
    {
        Random rnd = new Random();
        retest.points = rnd.Next(1, 100);
        NotifyFlunkey();
    }
}

class Rating
{
    public int points { get; set; }
}

class Flunkey : IStudent
{
    public string Name { get; set; }
    ITest situation;
    public Flunkey(string name, ITest obs)
    {
        this.Name = name;
        situation = obs;
        situation.RegisterFlunkey(this);
    }
    public void Update(object ob)
    {
        Rating retest = (Rating)ob;

        if (retest.points > 50)
            Console.WriteLine("Студент {0} сдал экзамен на {1}. Можно дальше ничего не делать", this.Name, retest.points);
        else
            Console.WriteLine("Студент {0} не сдал экзамен на {1}. Придется работать...", this.Name, retest.points);
    }
    public void StopEducation()
    {
        situation.RemoveFlunkey(this);
        situation = null;
    }
}

class ExcellentStudent : IStudent
{
    public string Name { get; set; }
    ITest situation;
    public ExcellentStudent(string name, ITest obs)
    {
        this.Name = name;
        situation = obs;
        situation.RegisterFlunkey(this);
    }
    public void Update(object ob)
    {
        Rating retest = (Rating)ob;

        if (retest.points > 75)
            Console.WriteLine("Студент {0} сдал экзамен на хорошую оценку {1}. Все ОК;", this.Name, retest.points);
        else if (retest.points > 50)
            Console.WriteLine("Студент {0} сдал экзамен на {1}. Но недоволен;", this.Name, retest.points);
        else
            Console.WriteLine("Студент {0} недоволен результатом {1}. Плачет;", this.Name, retest.points);
    }
}

namespace OBSERVER
{
    class Program
    {
        static void Main(string[] args)
        {
            Session session = new Session();
            ExcellentStudent excellentStudent = new ExcellentStudent("Vasya", session);
            Flunkey flunkey = new Flunkey("Petya", session);
            session.Result();
            session.Result();
            session.Result();
        }
    }
}
