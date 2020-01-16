using System.Collections.Concurrent;
using System.Reflection.Emit;
using System.Data;
using System.Runtime.ConstrainedExecution;
using System;
using System.Collections.Generic; 


namespace AssetApplication
{
public class Book : Asset
{
	public string assetType ;
	public int totalBook;
	public Book()
	{
		assetType = "book";//type of assest
        totalBook = 0;
	}	

	public struct bookStruct
	{
		public string name;
		public string genre;
        public string id;

		public double price;
	}

	List<bookStruct> bookList = new List<bookStruct>();

	public void Add()
	{

        
        bookStruct newBook = new bookStruct();

		Console.WriteLine("\nenter book name:");
		newBook.name = Console.ReadLine();

		Console.WriteLine("enter book genre:");
		newBook.genre = Console.ReadLine();

		Console.WriteLine("enter book price:");
		newBook.price = Convert.ToDouble(Console.ReadLine());
		
        L2:
        Console.WriteLine("enter book id:");
		newBook.id = Console.ReadLine();
        foreach(var item in bookList)
        {
            if (newBook.id == item.id)
            {
                Console.WriteLine("-->\nalready occupied id<--\nenter new id again");
                goto L2;
            }
            
        }



        bookList.Add(newBook);
		totalBook += 1;
		base.totalAssetQuantity += 1;

        Console.WriteLine("\nSuccessfully Added");

	}

    public void Del()
    {
        if(bookList.Count != 0)
        {
            Console.WriteLine("\nAvailable books: ");
            int a=1;
            foreach (var item in bookList)
            {
                Console.WriteLine("\n{0}.\nbookname: {1}\nbookprice: {2}\nbook genre: {3}\nbook Id: {4}",a,item.name,item.price,item.genre,item.id);
                a += 1;
            }
            

            Console.WriteLine("\nwhich number do you want to remove: ");
            int option = Convert.ToInt32(Console.ReadLine());

            if(option>a)
            {
                Console.WriteLine("not an option");
            }
            else
            {
                bookList.RemoveAt(option-1);
                
                totalBook -= 1;
                base.totalAssetQuantity-= 1;

            }
        }
        else
        {
            Console.WriteLine("--->--->--->Asset is empty<---<---<---");
        }


    }

    
    public void Search()
    {
        if(bookList.Count != 0)
        {
            Console.WriteLine("\n enter book id");
            bool isbookAvailable = false;
            string option = Console.ReadLine();
            foreach(var item in bookList)
            {
                if(option == item.id)
                {
                    Console.WriteLine("\n{0}.bookname: {1}\nbookprice: {2}\nbook genre: {3}\nbook Id: {4}",item.name,item.price,item.genre,item.id);
                    isbookAvailable = true;
                }
                
            }
            if(isbookAvailable)
            {
                Console.WriteLine("\nBook id not found");
            }
        }
        else
        {
            Console.WriteLine("--->--->--->Asset is empty<---<---<---");
        }


       
    }

    public override void Print()
    {
        base.Print();
        if(bookList.Count != 0)
        {
            Console.WriteLine("AssetType; {0}\nAvailable books: {1}",assetType,totalBook);
            int a=1;
            foreach(var item in bookList)
            {
            
                Console.WriteLine("\n{0}:\nbookname: {1}\nbookprice: {2}\nbook genre: {3}\nbook Id: {4}",a,item.name,item.price,item.genre,item.id);
                a += 1;
            }
        }
        else
        {
            Console.WriteLine("--->--->--->Asset is empty<---<---<---");
        }    
    }

    public void Update()
    {
        
        
        Console.WriteLine("\nEnter book Id which to be update");
        
        bookStruct updateBook = new bookStruct();
        bool isBookIdAvailable = false;
        string searchId = Console.ReadLine();
        for(int i = 0; i < bookList.Count; i++)
        {
            if(searchId== bookList[i].id)
            {
                Console.WriteLine("\nenter new book name");
                updateBook.name = Console.ReadLine();
                Console.WriteLine("\nenter new book genre");
                updateBook.genre = Console.ReadLine();
                Console.WriteLine("\nenter new book price");
                updateBook.price = Convert.ToInt32(Console.ReadLine());

                
                L3:
                    Console.WriteLine("enter book id:");
		            updateBook.id = Console.ReadLine();
                    foreach(var item in bookList)
                    {
                        if (updateBook.id == item.id)
                        {
                            Console.WriteLine("-->\nalready occupied id<--\nenter new id again");
                            goto L3;
                        }
            
                    }
                
                
                bookList[i] = updateBook;
                isBookIdAvailable = true;
            }
                
        }
        if(isBookIdAvailable )
        {
            Console.WriteLine("\nId not found");
        }
            
    }

}
}