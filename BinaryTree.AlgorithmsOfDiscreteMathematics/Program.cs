namespace BinaryTree.AlgorithmsOfDiscreteMathematics
{
	public class Program
	{
		private static void Main()
		{
			BinaryTree<double> tree = new();

			Random random = new();

			double k = double.Parse(Console.ReadLine()!);
			double lambda = double.Parse(Console.ReadLine()!);

			for (int i = 0; i < 12; i++)
			{
				double erlangValue = double.Round(0, 2);

				for (int j = 0; j < k; j++)
				{
					erlangValue += double.Round(-1 / lambda * Math.Log(1 - random.NextDouble()), 2);
				}

				tree.Insert(erlangValue);
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