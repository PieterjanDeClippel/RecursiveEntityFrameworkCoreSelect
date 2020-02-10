using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;

namespace RecursiveTest.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var context = new RecursiveContext();
            var categories = context.Categories
                .Include(cat => cat.Categories)
                .AsEnumerable()
                .Where(cat => cat.ParentCategory == null)
                .ToList()
                .Select(cat => ToDto(cat))
                .ToList();

            Debugger.Break();
        }

        static Dtos.Category ToDto(Entities.Category category)
        {
            return new Dtos.Category
            {
                Id = category.Id,
                Description = category.Description,
                Categories = category.Categories == null ? null : category.Categories.Select(c => ToDto(c)).ToList()
            };
        }
    }
}
