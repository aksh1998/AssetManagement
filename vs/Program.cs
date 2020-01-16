using System.Diagnostics;
using System.Reflection;
using System;

namespace AssetApplication
{
	public class Asset 
	{	
		public int totalAssetQuantity;//total number of Assest
		public virtual void Print()
		{
			Console.WriteLine("\n-->TotalAsset: {0}<--",totalAssetQuantity);
		}
		
	}

	public class Program 
	{
		public static void Main()
		{
			int choice = 1;
			bool isContinue = true;
			Book bookObject = new Book();
			SoftwareLicense softwareLicenseObject = new SoftwareLicense();
			Hardware hardwareObject = new Hardware();
			Console.WriteLine("available assests\n 1.book \n 2.softwarelicense \n 3.hardware");

			

			
			while(isContinue)
			{	
				Console.WriteLine("\n-->enter operation to perform<--");
				Console.WriteLine("1. Adding an Asset");
				Console.WriteLine("2.Searching an Asset");
				Console.WriteLine("3.Updating an Asset");
				Console.WriteLine("4.Deleting an Asset");
				Console.WriteLine("5.List of available Assets");
				Console.WriteLine("6. exit \n");
				choice = Convert.ToInt32(Console.ReadLine());
				string assetName ;
				switch(choice)
				{
					case 1:
						Console.WriteLine("\nType Asset name: ");
						assetName = (Console.ReadLine()).ToLower();
						if(assetName == ("book"))
						{
							bookObject.Add();
						}
						else if (assetName == ("softwarelicense"))
						{
							softwareLicenseObject.Add();
						}
						else if (assetName == "hardware")
						{
							hardwareObject.Add();
						}
						else
						{
							Console.WriteLine("Not a correct option choose from \n book \n softwarelicense \n hardware\n enter again");
						}
						break;
				
					case 2:
						Console.WriteLine("Type Asset name \n");
						assetName = (Console.ReadLine()).ToLower();
						if(assetName == "book" )
						{
							bookObject.Search();
						}
						else if (assetName == "softwarelicense")
						{
							softwareLicenseObject.Search();
						}
						else if (assetName == "hardware")
						{
							hardwareObject.Search();
						}
						else
						{
							Console.WriteLine("Not a correct option choose from \n book \n softwarelicense \n hardware\n enter again");
						}
						break;
				
					case 3:
						Console.WriteLine("Type Asset name  \n");
						assetName = (Console.ReadLine()).ToLower();
						if(assetName == "book" )
						{
							bookObject.Update();
						}
						else if (assetName == "softwarelicense")
						{
							softwareLicenseObject.Update();
						}
						else if (assetName == "hardware")
						{
							hardwareObject.Update();
						}
						else
						{
							Console.WriteLine("Not a correct option choose from \n book \n softwarelicense \n hardware\n enter again");
						}

						break;
					
					case 4:
						Console.WriteLine("Type Asset name\n");
						assetName = (Console.ReadLine()).ToLower();
						if(assetName == "book" )
						{
							bookObject.Del();
						}
						else if (assetName == "softwarelicense" )
						{
							softwareLicenseObject.Del();
						}
						else if (assetName == "hardware")
						{
							hardwareObject.Del();
						}
						else
						{
							Console.WriteLine("Not a correct option choose from \n book \n softwarelicense \n hardware\n enter again");
						}
						break;

					case 5:
						Console.WriteLine("Type Asset name  \n");
						assetName = (Console.ReadLine()).ToLower();
						if(assetName == "book" )
						{
							bookObject.Print();
						}
						else if (assetName == "softwarelicense" )
						{
							softwareLicenseObject.Print();
						}
						else if (assetName == "hardware")
						{
							hardwareObject.Print();
						}
						else
						{
							Console.WriteLine("Not a correct option choose from \n book \n softwarelicense \n hardware\n enter again");
						}
						break;

					case 6:
						isContinue = false;
						break;
					
					
					default :
						Console.WriteLine("Not a corret option, choose form 1 to 6");
						break;

				}

			}

		} 
	}
}