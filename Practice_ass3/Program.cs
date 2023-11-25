using System;
using System.Collections.Generic;

class InventoryManagement
{
    //List formation for storing temporary data
    static List<Item> inventory = new List<Item>();

    static void Main()
    {
        //display lines(No loop here)
        Console.WriteLine("Welcome to Sahil's Inventory Management System! ");
        Console.WriteLine("Here's the things I can do:- ");
        do
        {
            //choices
            Console.WriteLine("1.Add Item");
            Console.WriteLine("2.Display All Items");
            Console.WriteLine("3.Find Item by ID");
            Console.WriteLine("4.Update Item");
            Console.WriteLine("5.Delete Item");
            Console.WriteLine("6.Exit");

            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice))       //integer validation
            {
                switch (choice)         
                {
                    case 1:
                        AddItem();
                        Console.WriteLine("Item added successfully! You can press 2 to view your items ");
                        break;
                    case 2:
                        DisplayAllItems();
                        break;
                    case 3:
                        FindItemById();
                        break;
                    case 4:
                        UpdateItem();
                        break;
                    case 5:
                        DeleteItem();
                        break;
                    case 6:
                        Environment.Exit(0);    //helps to get out from the console
                        break;
                    default:
                        Console.WriteLine("Invalid choice, Please try in between 1 to 6 numbers! ");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number. ");
            }
        } while (true);
    }

    class Item
    {
        //Id field is auto generated according to the index value so I didn't included that in this
        public string Name;
        public double Price;
        public int Quantity;

        public Item(string name, double price, int quantity)
        {
            //Constructor. As we create an new item from add menu we provide this fields and thus the constructor gets initializes
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public void Display(int count)
        {
            Console.WriteLine($"Item {count}: Name: {Name}, Price: {Price}, Quantity: {Quantity}");
            Console.WriteLine("----------------------------------------------------------------");
        }
    }

    static void AddItem()   //Function to add things
    {
        Console.Write("Enter item name: ");
        string itemName = Console.ReadLine();

        Console.Write("Enter item price: ");
        if (double.TryParse(Console.ReadLine(), out double price) && price >= 0)
        {
            Console.Write("Enter item quantity: ");
            if (int.TryParse(Console.ReadLine(), out int quantity) && quantity >= 0)
            {
                inventory.Add(new Item(itemName, price, quantity));
            }
            else
            {
                Console.WriteLine("Invalid input for quantity. ");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for price. ");
        }
    }

    static void DisplayAllItems()     //Function to display all items present in the List
    {
        int count = 1;
        foreach (Item i in inventory)
        {
            i.Display(count);
            count++;
        }
    }

    static void UpdateItem()       //Function to update parameters of an item
    {
        Console.Write("Enter the number of the item to update: ");
        int updateIndex = Convert.ToInt32(Console.ReadLine()) - 1;  //-1 because the List begins from 0

        if (updateIndex >= 0 && updateIndex < inventory.Count)
        {
            Console.Write("Enter updated name: ");
            string newName = Console.ReadLine();
            Console.Write("Enter updated price: ");
            double newPrice = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter updated quantity: ");
            int updatedQuantity = Convert.ToInt32(Console.ReadLine());

            inventory[updateIndex] = new Item(newName, newPrice, updatedQuantity);  //storing newly inserted values in List
            Console.WriteLine("Item updated successfully");
        }
        else
        {
            Console.WriteLine("Invalid item number. Try again");
        }
    }

    static void DeleteItem()    //Function for deleting an item from the List
    {
        Console.Write("Enter the number of the item to delete: ");
        int deleteIndex = Convert.ToInt32(Console.ReadLine()) - 1;

        if (deleteIndex >= 0 && deleteIndex < inventory.Count)
        {
            inventory.RemoveAt(deleteIndex);
            Console.WriteLine("Item deleted successfully");
        }
        else
        {
            Console.WriteLine("Invalid item number. Try again");
        }
    }

    static void FindItemById()      //Function to call an item by its ID
    {
        Console.Write("Enter the number of the item to find: ");
        int findIndex = Convert.ToInt32(Console.ReadLine()) - 1;

        if (findIndex >= 0 && findIndex < inventory.Count)
        {
            var item = inventory[findIndex];
            Console.WriteLine($"Item found: Name: {item.Name}, Price: {item.Price}, Quantity: {item.Quantity}");
        }
        else
        {
            Console.WriteLine("Invalid item number. Try again");
        }
    }
}