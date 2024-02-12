namespace CreateSemesterFoldersV2.Interfaces.Implementation
{
    public class CheckIfInt : ICheckIfInt
    {
        public int Validate(string input)
        {
            int inputValue;
            bool success = int.TryParse(input, out inputValue);
            while (!success)
            {
                Console.WriteLine("Ugyldigt input. Prøv igen...");
                Console.Write("Indtast ugenummer: ");
                input = Console.ReadLine();
                success = int.TryParse(input, out inputValue);
            }

            return inputValue;
        }

        public string ValidatePath(string input)
        {
            bool success = Directory.Exists(input);
            while (!success)
            {
                Console.WriteLine("Ugyldigt input. Prøv igen...");
                Console.Write("Indtast hele stien til den ønskede placering for mapperne: ");
                input = Console.ReadLine();
                success = Directory.Exists(input);
            }

            return input;
        }
    }
}
