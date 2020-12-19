using System;
using System.Diagnostics.CodeAnalysis;

namespace Medusa.WebUI.Models
{
    public class CategoryListModel : IEquatable<CategoryListModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Equals([AllowNull] CategoryListModel other)
        {
            return Id == other.Id && Name == other.Name;
        }
    }
}
