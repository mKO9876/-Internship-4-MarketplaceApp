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


    }
}
