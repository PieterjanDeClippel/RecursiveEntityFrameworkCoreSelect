using System;
using System.Collections.Generic;
using System.Text;

namespace RecursiveTest.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public Category ParentCategory { get; set; }
        public List<Category> Categories { get; set; }
    }
}
