namespace Cosmetics.Products
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Toothpaste : Product, IToothpaste
    {
        private const int MinIngredientNameLenght = 4;
        private const int MaxIngredientNameLenght = 12;
        private const string IngredientsListSeparator = ", ";
        private const string IngredientsString = "  * Ingredients: {0}";
        private string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            this.Ingredients = this.ValidateIngredients(ingredients);
        }

        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }

            private set
            {
                this.ingredients = value;
            }
        }

        public override string Print()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.Print());
            result.AppendLine(string.Format(IngredientsString, this.Ingredients));

            return result.ToString().Trim();
        }

        private string ValidateIngredients(IList<string> ingredients)
        {
            IList<string> correctIngredients = new List<string>();
            foreach (string ingredient in ingredients)
            {
                string errorMessage = string.Format(GlobalErrorMessages.InvalidStringLength, ingredient, MinIngredientNameLenght, MaxIngredientNameLenght);
                Validator.CheckIfStringLengthIsValid(ingredient, MaxIngredientNameLenght + 1, MinIngredientNameLenght, errorMessage);
                correctIngredients.Add(ingredient);
            }

            string result = string.Join(IngredientsListSeparator, correctIngredients);
            return result;
        }
    }
}
