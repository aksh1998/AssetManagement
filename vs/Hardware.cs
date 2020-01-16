using System.Collections.Concurrent;
using System.Reflection.Emit;
using System.Data;
using System.Runtime.ConstrainedExecution;
using System;
using System.Collections.Generic; 



namespace AssetApplication
{
public class Hardware : Asset
{
	
	public string assetType;
	public int totalHardware;
	public Hardware()
	{
		assetType = "Hardware";
        totalHardware = 0; 
	}
	struct hardwareStruct
	{
		public string name;
        public string id;
		public double price;
        public string company;
	}

    List<hardwareStruct> hardwareList = new List<hardwareStruct>();

    public void Add()
	{

        
        hardwareStruct newHardware = new hardwareStruct();

		Console.WriteLine("\nenter Hardware name");
		newHardware.name = Console.ReadLine();

		Console.WriteLine("enter Hardware companys");
		newHardware.company = Console.ReadLine();
		

		Console.WriteLine("enter Hardware price");
		newHardware.price = Convert.ToDouble(Console.ReadLine());
		
        L2:
        Console.WriteLine("enter Hardware id");
		newHardware.id = Console.ReadLine();
        foreach(var item in hardwareList)
        {
            if (newHardware.id == item.id)
            {
                Console.WriteLine("-->\nalready occupied id<--\nenter new id again");
                goto L2;
            }
            
        }

        hardwareList.Add(newHardware);
		totalHardware += 1;
		base.totalAssetQuantity += 1;

	}


	public void Del()
    {
        if(hardwareList.Count != 0)
        {
            Console.WriteLine("-->\nAvailable softwareLicense<--");
            int a=1;
            foreach (var item in hardwareList)
            {
                Console.WriteLine("\n{0}:\nhardware name: {1}\nhardwarePrice: {2}\nhardware company: {3}\nhardware id: {4}",a,item.name,item.price,item.company,item.id);
                a += 1;
            }
            

            Console.WriteLine("-->\nwhich number do you want to remove<--");
            int option = Convert.ToInt32(Console.ReadLine());

            if(option>a)
            {
                Console.WriteLine("\nNot an option");
            }
            else
            {
                hardwareList.RemoveAt(option-1);
                
                totalHardware -= 1;
                base.totalAssetQuantity -= 1;

            }
        }
        else
        {
            Console.WriteLine("--->--->--->Asset is empty<---<---<---");
        }


    }

    
    public void Search()
    {
        if(hardwareList.Count != 0)
        {
            Console.WriteLine("\nenter hardware id");
            bool isHardwareAvailable = false;
            string option = Console.ReadLine();
            foreach(var item in hardwareList)
            {
                if(option == item.id)
                {
                    Console.WriteLine("\n{0}.\nhardware: {1}\nhardwarePrice: {2}\nhardware company: {3}\nhardware id: {4}",item.name,item.price,item.company,item.id);
                    isHardwareAvailable = true;
                }
                
            }
            if(isHardwareAvailable )
            {
                Console.WriteLine("-->\nhardware id not found<--");
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
        if(hardwareList.Count != 0)
        {    
            Console.WriteLine("\nAssetType: {0}\nAvailable hardware: {1}",assetType,totalHardware);
            int a=1;
            foreach(var item in hardwareList)
            {
            
                Console.WriteLine("\n{0}:\nhardwarename: {1}\nhardwarePrice: {2}\nhardware company: {3}\nhardware id: {4}",a,item.name,item.price,item.company,item.id);
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
        
        
        Console.WriteLine("\nEnter hardware Id which to be update");
        
        hardwareStruct updateHardware = new hardwareStruct();
        bool isHardwareIdAvailable = false;
        string searchId = Console.ReadLine();
        for(int i = 0; i < hardwareList.Count; i++)
        {
            if(searchId== hardwareList[i].id)
            {
                Console.WriteLine("\nenter new hardware name");
                updateHardware.name = Console.ReadLine();
                Console.WriteLine("\nenter new hardware company");
                updateHardware.company = Console.ReadLine();
                Console.WriteLine("\nenter new hardware price");
                updateHardware.price = Convert.ToInt32(Console.ReadLine());

                
                L3:
                    Console.WriteLine("enter hardware id:");
		            updateHardware.id = Console.ReadLine();
                    foreach(var item in hardwareList)
                    {
                        if (updateHardware.id == item.id)
                        {
                            Console.WriteLine("-->\nalready occupied id<--\nenter new id again");
                            goto L3;
                        }
            
                    }
                
                
                hardwareList[i] = updateHardware;
                isHardwareIdAvailable = true;
            }
                
        }
        if(isHardwareIdAvailable )
        {
            Console.WriteLine("\nId not found");
        }
            
    }


}
}