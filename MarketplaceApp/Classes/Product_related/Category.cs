using MarketplaceApp.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp
{
    public enum Category
    {
        Electronics,
        Clothing,
        Books,
        Dairy_products,
        Meat,
        Fruits_and_vegetables,
        Toys,
        Snacks,
        Baked_goods,
        Household

    }

    public static class ShowCategory
    {
        public static string ReturnString(this Category c)
        {
            switch (c)
            {
                case Category.Electronics:
                    return "Electronics";
                case Category.Clothing:
                    return "Clothing";
                case Category.Books:
                    return "Books";
                case Category.Dairy_products:
                    return "Dairy products";
                case Category.Meat:
                    return "Meat";
                case Category.Fruits_and_vegetables:
                    return "Fruits and vegetables";
                case Category.Toys:
                    return "Toys";
                case Category.Snacks:
                    return "Snacks";
                case Category.Baked_goods:
                    return "Baked goods";
                case Category.Household:
                    return "Household";
                default:
                    return "No such category";
            }

        }
        public static bool CheckCategoryEqual(this Category c, string input)
        {
            if (c.ReturnString().ToLower() == input.ToLower()) return true;
            return false;
        }

        public static string CheckCategoryExists(string text)
        {
            Console.Clear();
            string input;
            List<string> categoryList = new List<string> { "electronics", "clothing", "books", "dairy products", "meat", "fruits and vegetables", "snacks", "baked goods", "household" };
            do
            {
                Console.WriteLine("Categories:\n- electronics, \n- clothing, \n- books, \n- dairy products, \n- meat, \n- fruits and vegetables, \n- snacks, \n- baked goods, \n- household");
                input = InputHelper.CheckUserInput(text).ToLower();
                if (!categoryList.Contains(input)) Console.WriteLine("Category does not exist, try again.");
            } while (!categoryList.Contains(input));
            return input;
        }

        public static Category ReturnCategory(string text)
        {

            string chosenCategory = CheckCategoryExists(text);
            switch (chosenCategory)
            {
                case "electronics":
                    return Category.Electronics;

                case "clothing":
                    return Category.Clothing;

                case "books":
                    return Category.Books;

                case "dairy products":
                    return Category.Dairy_products;

                case "meat":
                    return Category.Meat;

                case "fruits and vegetables":
                    return Category.Fruits_and_vegetables;

                case "snacks":
                    return Category.Snacks;

                case "baked goods":
                    return Category.Baked_goods;

                default:
                    return Category.Household;

            }

        }
    }
}
