namespace BinaryTree.AlgorithmsOfDiscreteMathematics
{
	public class Program
	{
		private static void Main()
		{
			BinaryTree<double> tree = new();

			Random random = new();

			Console.WriteLine("Введите коэффициент k");

			double k = double.Parse(Console.ReadLine()!);

			Console.WriteLine("Введите коэффициент lambda");

			double lambda = double.Parse(Console.ReadLine()!);

			Console.Clear();

			for (int i = 0; i < 12; i++)
			{
				double erlangValue = double.Round(0, 2);

				for (int j = 0; j < k; j++)
				{
					erlangValue += -1 / lambda * Math.Log(1 - random.NextDouble());
				}

				tree.Insert(double.Round(erlangValue, 2));
			}

			tree.Print();

			while (true)
			{
				Console.WriteLine("Введите новый элемент или 'q' для выхода:");

				string input = Console.ReadLine()!;

				if (input is "q")
				{
					break;
				}

				if (double.TryParse(input, out double newValue))
				{
					tree.Insert(newValue);

					Console.WriteLine($"Элемент {newValue} добавлен в дерево. Обновленный обход дерева в порядке возрастания:");

					tree.Print();
				}
				else
				{
					Console.WriteLine("Неверный формат ввода. Пожалуйста, введите число или 'q' для выхода.");
				}
			}
		}
	}
}