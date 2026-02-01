namespace Exercise1;
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please Enter the N number:");
        int n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < 10; i++)
        {
        Console.Write((i)*(i+1)*(i+2)+ " ");
        }
    }
}
