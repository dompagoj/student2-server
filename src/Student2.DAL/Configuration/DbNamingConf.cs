using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace Student2.DAL.Configuration
{
    public static class NamingConv
    {
        static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            var startUnderscores = Regex.Match(input, @"^_+");

            return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }

        public static void UseSnakeCase(this ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                // Replace table names
                entity.SetTableName(entity.GetTableName().ToSnakeCase());

                // Replace column names
                foreach (var property in entity.GetProperties())
                    property.SetColumnName(property.GetColumnName().ToSnakeCase());

                foreach (var key in entity.GetKeys()) key.SetName(key.GetName().ToSnakeCase());

                foreach (var key in entity.GetForeignKeys())
                    key.SetConstraintName(key.GetConstraintName().ToSnakeCase());

                foreach (var index in entity.GetIndexes()) index.SetName(index.GetName().ToSnakeCase());
            }
        }
    }
}