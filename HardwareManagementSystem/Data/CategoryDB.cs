using HardwareManagementSystem.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareManagementSystem.Data
{
    internal class CategoryDB : DB
    {
        private readonly string connectionString;

        public CategoryDB(string connStr)
        {
            connectionString = connStr;
        }

        public void AddCategory(Categories category)
        {
            // Logic to add category to the database
        }

        public List<Categories> GetCategories()
        {
            // Logic to fetch categories from the database
            return new List<Categories>();
        }
    }
}
