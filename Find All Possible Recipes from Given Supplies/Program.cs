namespace Find_All_Possible_Recipes_from_Given_Supplies
{
    /*You have information about n different recipes. You are given a string array recipes and a 2D string array ingredients. 
    The ith recipe has the name recipes[i], and you can create it if you have all the needed ingredients from ingredients[i]. 
     A recipe can also be an ingredient for other recipes, i.e., ingredients[i] may contain a string that is in recipes.
    You are also given a string array supplies containing all the ingredients that you initially have, and 
    you have an infinite supply of all of them.
    Return a list of all the recipes that you can create. You may return the answer in any order.
    Note that two recipes may contain each other in their ingredients.
    
    Constraint:
    n == recipes.length == ingredients.length
    1 <= n <= 100
    1 <= ingredients[i].length, supplies.length <= 100
    1 <= recipes[i].length, ingredients[i][j].length, supplies[k].length <= 10
    recipes[i], ingredients[i][j], and supplies[k] consist only of lowercase English letters.
    All the values of recipes and supplies combined are unique.
    Each ingredients[i] does not contain any duplicate values.
     */
    public class Solution
    {
        public static IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
        {
            var availableSupplies = new HashSet<string>(supplies);
            var recipeToIngredients = new Dictionary<string, List<string>>();
            var visited = new Dictionary<string, int>();
            var result = new List<string>();

            for (int i = 0; i < recipes.Length; i++)
            {
                recipeToIngredients[recipes[i]] = new List<string>(ingredients[i]);
            }

            bool CanMake(string recipe)
            {
                if (visited.ContainsKey(recipe))
                {
                    return visited[recipe] == 1;
                }

                if (availableSupplies.Contains(recipe))
                {
                    return true;
                }

                if (!recipeToIngredients.ContainsKey(recipe))
                {
                    return false;
                }

                visited[recipe] = 0;

                foreach (string ingredient in recipeToIngredients[recipe])
                {
                    if (!CanMake(ingredient))
                    {
                        visited[recipe] = -1;
                        return false;
                    }
                }

                visited[recipe] = 1;
                result.Add(recipe);
                return true;
            }

            foreach (string recipe in recipes)
            {
                CanMake(recipe);
            }

            return result;
        }
    }
}
