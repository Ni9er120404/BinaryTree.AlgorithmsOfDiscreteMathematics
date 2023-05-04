using System.Collections;

namespace BinaryTree.AlgorithmsOfDiscreteMathematics
{
	public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
	{
		private Node<T>? _root;

		public BinaryTree()
		{
			_root = null;
		}

		public BinaryTree(IEnumerable<T> values)
		{
			_root = null;

			foreach (T value in values)
			{
				Insert(value);
			}
		}

		public void Insert(T data)
		{
			Console.WriteLine($"Вставляем {data} в дерево...");

			Node<T> node = new(data);

			if (_root is null)
			{
				_root = node;

				Console.WriteLine($"Узел {data} становится корневым");
			}
			else
			{
				InsertNode(_root, node);
			}
		}

		private void InsertNode(Node<T> currentNode, Node<T> node)
		{
			if (node.Data.CompareTo(currentNode.Data) < 0)
			{
				if (currentNode.Left is null)
				{
					currentNode.Left = node;

					Console.WriteLine($"Узел {node.Data} вставлен слева от {currentNode.Data}");
				}
				else
				{
					InsertNode(currentNode.Left, node);
				}
			}
			else if (node.Data.CompareTo(currentNode.Data) > 0)
			{
				if (currentNode.Right is null)
				{
					currentNode.Right = node;

					Console.WriteLine($"Узел {node.Data} вставлен справа от {currentNode.Data}");
				}
				else
				{
					InsertNode(currentNode.Right, node);
				}
			}
			else
			{
				Console.WriteLine($"Элемент {node.Data} уже существует в дереве");
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			return TraverseInOrder(_root!).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private IEnumerable<T> TraverseInOrder(Node<T> node)
		{
			if (node.Left is not null)
			{
				foreach (T value in TraverseInOrder(node.Left))
				{
					yield return value;
				}
			}

			yield return node.Data;

			if (node.Right is not null)
			{
				foreach (T value in TraverseInOrder(node.Right))
				{
					yield return value;
				}
			}
		}
		public void Print()
		{
			PrintNode(_root!, string.Empty);
		}

		private void PrintNode(Node<T> node, string indent)
		{
			if (node != null)
			{
				Console.WriteLine(indent + node.Data);

				if (node.Left != null)
				{
					Console.WriteLine(indent + "|--");
					PrintNode(node.Left, indent + "|\t");
				}

				if (node.Right != null)
				{
					Console.WriteLine(indent + "|--");
					PrintNode(node.Right, indent + "\t");
				}
			}
		}
	}
}