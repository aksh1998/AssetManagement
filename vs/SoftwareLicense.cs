using System.Collections.Concurrent;
using System.Reflection.Emit;
using System.Data;
using System.Runtime.ConstrainedExecution;
using System;
using System.Collections.Generic; 

namespace AssetApplication
{
public class SoftwareLicense : Asset
{
	public string assetType;
	public int totalSoftwareLicense;
	
	public SoftwareLicense()
	{
		assetType = "software license";
		totalSoftwareLicense = 0; 
	}

	struct softwareLicenseStruct
	{
		public string name;
		public double price;
		public string id;
		public string key;
	}

	List<softwareLicenseStruct> softwareLicenseList = new List<softwareLicenseStruct>();


	public void Add()
	{

        
        softwareLicenseStruct newSoftwareLicense = new softwareLicenseStruct();

		Console.WriteLine("\nenter softwareLicense name");
		newSoftwareLicense.name = Console.ReadLine();

		Console.WriteLine("enter Software keys");
		newSoftwareLicense.key = Console.ReadLine();
		L1:
		foreach(var item in softwareLicenseList)
        {
            if (newSoftwareLicense.key == item.key)
            {
                Console.WriteLine("-->\nalready occupied key<--\nenter new key again");
                goto L1;
            }
            
        }

		Console.WriteLine("\nenter softwareLicense price");
		newSoftwareLicense.price = Convert.ToDouble(Console.ReadLine());
		
        L2:
        Console.WriteLine("\nenter softwareLicense id");
		newSoftwareLicense.id = Console.ReadLine();
        foreach(var item in softwareLicenseList)
        {
            if (newSoftwareLicense.id == item.id)
            {
                Console.WriteLine("-->\nalready occupied id<--\nenter new id again");
                goto L2;
            }
            
        }



        softwareLicenseList.Add(newSoftwareLicense);
		totalSoftwareLicense += 1;
		base.totalAssetQuantity += 1;

	}


	public void Del()
    {
		if(softwareLicenseList.Count != 0)
		{
			Console.WriteLine("-->\nAvailable softwareLicense<--");
			int a=1;
			foreach (var item in softwareLicenseList)
			{
				Console.WriteLine("\n{0}: \nSoftwareLicense name: {1}\nSoftwareLicensePrice: {2}\nSoftwareLicense key: {3}\nSoftwareLicense id: {4}",a,item.name,item.price,item.key,item.id);
				a += 1;
			}
			

			Console.WriteLine("\nwhich number do you want to remove");
			int option = Convert.ToInt32(Console.ReadLine());

			if(option>a)
			{
				Console.WriteLine("-->\nNot an option<--");
			}
			else
			{
				softwareLicenseList.RemoveAt(option-1);
				
				totalSoftwareLicense -= 1;
				base.totalAssetQuantity -= 1;

			}
		}
		else
        {
            Console.WriteLine("\n--->--->--->Asset is empty<---<---<---");
        }


    }

    
    public void Search()
    {
		if(softwareLicenseList.Count != 0)
		{
			Console.WriteLine("\nenter SoftwareLicense id");
			bool isSoftwareAvailable = false;
			string option = Console.ReadLine();
			foreach(var item in softwareLicenseList)
			{
				if(option == item.id)
				{
					Console.WriteLine("\n{0}.\nSoftwareLicense: {1}\nSoftwareLicensePrice: {2}\nSoftwareLicense key: {3}\nSoftwareLicense id: {4}",item.name,item.price,item.key,item.id);
					isSoftwareAvailable = true;
				}
				
			}
			if(isSoftwareAvailable)
			{
				Console.WriteLine("\nSoftwareLicense id not found");
			}
		}
		else
        {
            Console.WriteLine("\n--->--->--->Asset is empty<---<---<---");
        }	
       
    }

    public override void Print()
    {
		base.Print();
		if(softwareLicenseList.Count != 0)
		{
			Console.WriteLine("\nAssetType: {0}\navailable softwareLicense: {1}",assetType,totalSoftwareLicense);
			int a=1;
			foreach(var item in softwareLicenseList)
			{
			
				Console.WriteLine("\n{0}:\nSoftwareLicensename: {1}\nSoftwareLicensePrice: {2}\nSoftwareLicense key: {3}\nSoftwareLicense id: {4}",a,item.name,item.price,item.key,item.id);
				a += 1;
			}
		}
		else
        {
            Console.WriteLine("\n--->--->--->Asset is empty<---<---<---");
        }	
    }


	public void Update()
    {
        
        
        Console.WriteLine("\nEnter software Id which to be update");
        
        softwareLicenseStruct updateSoftwareLicense = new softwareLicenseStruct();
        bool isSoftwareLicenseIdAvailable = false;
        string searchId = Console.ReadLine();
        for(int i = 0; i < softwareLicenseList.Count; i++)
        {
            if(searchId== softwareLicenseList[i].id)
            {
                Console.WriteLine("\nenter new book name");
                updateSoftwareLicense.name = Console.ReadLine();
                
				L4:
				Console.WriteLine("\nenter new book key");
                updateSoftwareLicense.key = Console.ReadLine();
				foreach(var item in softwareLicenseList)
                    {
                        if (updateSoftwareLicense.key == item.key)
                        {
                            Console.WriteLine("-->\nalready occupied key<--\nenter new key again");
                            goto L4;
                        }
            
                    }
                
				Console.WriteLine("\nenter new book price");
                updateSoftwareLicense.price = Convert.ToInt32(Console.ReadLine());

                
                L3:
                    Console.WriteLine("enter book id:");
		            updateSoftwareLicense.id = Console.ReadLine();
                    foreach(var item in softwareLicenseList)
                    {
                        if (updateSoftwareLicense.id == item.id)
                        {
                            Console.WriteLine("-->\nalready occupied id<--\nenter new id again");
                            goto L3;
                        }
            
                    }
                
                
                softwareLicenseList[i] = updateSoftwareLicense;
                isSoftwareLicenseIdAvailable = true;
            }
                
        }
        if(isSoftwareLicenseIdAvailable )
        {
            Console.WriteLine("\nId not found");
        }
            
    }

}
}