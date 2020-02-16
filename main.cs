using System;
using System.Collections.Generic;
using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

class MainClass {

  public static void Main(string[] args) {
  
    // Prompt user to enter age
    Console.Write("Enter Your Age in Years e.g 24:");

    int age = int.Parse(Console.ReadLine());

    Console.WriteLine();
    // Prompt user to enter Income
    Console.Write("Enter Pre-tax Income:"); // Prompt

    double income = int.Parse(Console.ReadLine());
    
    Console.WriteLine();
    
    // Program initiates calculation using the inputs entered and stores the uotput in netWorth Variable. TARGET NETWORTH
    Double targetNetworth = (age * income) * 0.10;
    
    Console.WriteLine("Your current Networth is = "+targetNetworth);
    
    Console.WriteLine();
    
    // Prompt User to Enter the Number of Assets
    Console.Write("Enter the total number of assets:"); // MaxAssets
    
    int maxAsset = int.Parse(Console.ReadLine());
    
    Console.WriteLine();
    // Prompt User to Enter the Number of liabilities
    Console.Write("Enter the total number of liabilities:"); // Maxliabilities

    int maxLiabilities = int.Parse(Console.ReadLine());
    
    List<double> assets = new List<double>();
    List<double> liabilities = new List<double>();
    /*
    *
    * Assets
    *
    */
    Console.WriteLine("===================================================================");
    int counter = 0;
    
    while (counter < maxAsset) {
      
      Console.WriteLine("Enter assets :");
      double asset = double.Parse(Console.ReadLine()); // Get
      
      assets.Add(asset);
      if (asset.ToString() == "exit") {
        break;
      }
      counter++;
    }
    
    // Sum of assets
    string sumAssets = "The sum of the assets = "+assets.Sum()+"\n";
    Console.WriteLine(sumAssets);
    System.IO.File.WriteAllText("networth.txt", sumAssets);
    
    // Sorting Array
    // assets.Sort();
    assets.Sort((a, b) => a.CompareTo(b));
    
    // printing sorteed array
    string headingOne = "Assets sorted in ascending order\n"; // Create string
    Console.WriteLine(headingOne); // Print string on console
    System.IO.File.AppendAllText("networth.txt", headingOne); // Print string on File with WriteAllText since is the first string to be created.
    
    using (System.IO.StreamWriter file = new System.IO.StreamWriter("networth.txt")) {
      foreach (double asset in assets) {
        Console.WriteLine(asset);
        file.WriteLine(asset); // Print each element on file
      }
    }
    
    // reversing array and orinting which prints the sorted list in descending order
    assets.Reverse();
    string headingTwo = "Assets sorted in Descending Order\n"; // Create string
    Console.WriteLine(headingTwo); // Print string on console
    System.IO.File.AppendAllText("networth.txt", headingTwo); // Print string on File with AppendAllText
    
    using (System.IO.StreamWriter file2 = new System.IO.StreamWriter("networth.txt", true)) {
      foreach (double asset in assets) {
        Console.WriteLine(asset);
        file2.WriteLine(asset); // Print each element on file
      }
    }
    /*
    *
    * Liabilities
    *
    */
    Console.WriteLine("===================================================================");
    int counter2 = 0;
    while (counter2 < maxLiabilities) {
      Console.WriteLine("Enter Liabilities :");
      
      double liab = double.Parse(Console.ReadLine()); // Get
      liabilities.Add(liab);
      if (liab.ToString() == "exit") {
        break;
      }
      counter2++;
    }

    // Sum of liabilities    
    string sumLiabilities = "The sum of the Liabilities = " + liabilities.Sum()+"\n";
    Console.WriteLine(sumLiabilities);
    System.IO.File.AppendAllText("networth.txt", sumLiabilities);

    // Sort liabilities
    liabilities.Sort((a, b) => a.CompareTo(b));
    string headingThird = "Liabilities sorted in ascending order\n"; // Create string
    Console.WriteLine(headingThird); // Print string on console
    System.IO.File.AppendAllText("networth.txt", headingThird); // Print string on File with AppendAllText
    using (System.IO.StreamWriter file3 = new System.IO.StreamWriter("networth.txt", true)) {
      foreach (double liab in liabilities) {
        Console.WriteLine(liab);
        file3.WriteLine(liab); // Print each element on file
      }
    }

    // reverse liabilities array
    liabilities.Reverse();
    string headingFourth = "Liabilities sorted in Descending Order\n"; // Create string
    Console.WriteLine(headingFourth); // Print string on console
    System.IO.File.AppendAllText("networth.txt", headingFourth); // Print string on File with AppendAllText
    using (System.IO.StreamWriter file4 = new System.IO.StreamWriter("networth.txt", true)) {
      foreach (double liab in liabilities) {
        Console.WriteLine(liab);
        file4.WriteLine(liab); // Print each elelment on file
      }
    }

    // Calculate CURRENT NETWORTH
    double actualNetworth = assets.Sum() - liabilities.Sum();
    // Calculate difference of TARGET NETWORTH AND ACTUAL NETWORTH
    double differenceNetworth = actualNetworth - targetNetworth;
    // Calculate the IDEAL NETWORTH to have
    double idealNetworth = 2 * targetNetworth;

    // Create str table to print in both console and on file
    string table = "===================================================================\n=           Actual Networth         | "+actualNetworth+"\t\t\t          =\n=           Difference Networth     | "+differenceNetworth+"\t\t\t\t\t      =\n=           Ideal Networth          | "+idealNetworth+"\t\t\t          =\n===================================================================\n";

    Console.WriteLine(table);

    // Create str text to print in both console and on file
    string text = "Right now, I am $"+ differenceNetworth +" over my target net worth.  Ideally the goal is to reach beyond the $"+ idealNetworth +"\nI intend to research and apply an investment strategy to close the gap, pay off existing loans/liabilities, invest in more appreciative assets. - stay the course.\nAdditionally, by acquiring more assets, and reducing monthly regular bills, we should get closer to the target number.";
    
    Console.WriteLine(text);

    System.IO.File.AppendAllText("networth.txt", table); // Print on file
    System.IO.File.AppendAllText("networth.txt", text); // Print on file

    Console.WriteLine("Press [ENTER] to exit");
    Console.ReadKey();
  }
}