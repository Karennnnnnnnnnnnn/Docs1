using System;
using System.Net.Http.Headers;

class Parent
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Salary { get; set; }

    public Parent(string name, int age, int salary)
    {
        Name = name;
        Age = age;
        Salary = salary;
    }

}
class Child
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Parent Mother { get; set; }
    public Parent Father { get; set; }

    public Child(string name, int age, Parent mother, Parent father)
    {
        Name = name;
        Age = age;
        Mother = mother;
        Father = father;
    }

    public void Print()
    {
        Console.WriteLine($"Name: {Name}\nAge: {Age}");
        Console.WriteLine($"Mother: [Name: {Mother.Name}, Age: {Mother.Age}, Salary: {Mother.Salary} ]");
        Console.WriteLine($"Father: [Name: {Father.Name}, Age: {Father.Age}, Salary: {Father.Salary} ]");

    }
}
class Program
{
    static void Main()
    {
        //  Child c1 = new Child("Tigran", 13, new Parent("Anna", 40, 270000), new Parent("Edik", 45, 500000)); //test
        //  c1.Print();
        Child[] children = new Child[]
        {
            new Child("Araqsik", 13, new Parent("Manush", 31, 180000), new Parent("Exo", 32, 250000)),
            new Child("Tigran", 11, new Parent("Anna", 30, 270000), new Parent("Edik", 33, 200000)),
            new Child("Hamo", 14, new Parent("Emi", 55, 800000), new Parent("Musho", 53, 1200000)),
            new Child("Naro", 16, new Parent("Lara", 43, 350000), new Parent("Mxo", 50, 700000)),
            new Child("Nare", 10, new Parent("Shushan", 32, 180000), new Parent("Samvel", 41, 250000)),
            new Child("Mane", 12, new Parent("Zara", 33, 190000), new Parent("Davit", 35, 950000)),
            new Child("Sasun", 16, new Parent("Gohar", 34, 700000), new Parent("Rafo", 37, 650000)),
            new Child("Babken", 15, new Parent("Sveta", 38, 150000), new Parent("Erik", 38, 150000)),
            new Child("Marine", 17, new Parent("Laura", 45, 130000), new Parent("Miro", 52, 450000)),

        };



        //1. Տպել այն երեխաների ցուցակը, որոնց հոր և մոր տարիքը միասին չի գերազանցում 70-ը
        /*    foreach(Child child in children)   
            {
                int sum = child.Mother.Age + child.Father.Age;
                if(sum <= 70)
                {
                    child.Print();
                }
            }
        */



        //2. Գտնել տարիքով ամենամեծ երեխայի հոր աշխատավարձը
        /*  Child oldestChild = children[0];   

          foreach (Child child in children)  

          {
              if(child.Age > oldestChild.Age)
              {
                  oldestChild = child;
              }
          }
          Console.WriteLine($"Oldest child's father salary is: {oldestChild.Father.Salary}");
        */



        //3. Գտնել ամենամեծ ընտանեկան եկամուտ ունեցող երեխայի տվյալները
        /* Child c1 = children[0]; 
         foreach(Child child in children)
         {
             if(c1.Father.Salary + c1.Mother.Salary < child.Mother.Salary + child.Father.Salary)
             {
                 c1 = child;
             }
         }
         Console.WriteLine($"Child with higest family income:");
         c1.Print();
        */


        //4. Զանգվածում տեղերով փոխել ամենաերիտասարդ և ամենամեծ երեխաների դիրքերը` տպելով ընդհանուր զանգվածը:
        /*  foreach(Child child in children)
          {
              child.Print();
          }
        */
        int youngInd = 0;
        int oldInd = 0;

        for (int i = 0; i < children.Length; i++)
        {
            if (children[oldInd].Age < children[i].Age)
            {
                oldInd = i;
            }
            if (children[youngInd].Age > children[i].Age)
            {
                youngInd = i;
            }
        }
        Child tmp = children[oldInd];
        children[oldInd] = children[youngInd];
        children[youngInd] = tmp;

        Console.WriteLine("After swapping:");
        foreach (Child child in children)
        {
            child.Print();
        }
    }
}