using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;
using System.Text;
using System.Collections;

namespace Products
{
	public class ProductCollection: IEnumerable
	{
		Dictionary<int, Product> ProductsById
			= new Dictionary<int, Product>(10000);

		OrderedDictionary<float, OrderedDictionary<int, Product>> ProductsByPrice
			= new OrderedDictionary<float, OrderedDictionary<int, Product>>();

		Dictionary<string, OrderedDictionary<int, Product>> ProductsByTitle
			= new Dictionary<string, OrderedDictionary<int, Product>>();

		Dictionary<string, OrderedDictionary<float, OrderedDictionary<int, Product>>> ProductsByTitlePrice
			= new Dictionary<string, OrderedDictionary<float, OrderedDictionary<int, Product>>>();

		Dictionary<string, OrderedDictionary<float, OrderedDictionary<int, Product>>> ProductsBySupplierPrice
			= new Dictionary<string, OrderedDictionary<float, OrderedDictionary<int, Product>>>();

		public void Add(Product product)
		{
			if (ProductsById.ContainsKey (product.Id)) {
				var oldProduct = ProductsById [product.Id];
				ProductsById [oldProduct.Id] = product;
				ProductsByTitle [oldProduct.Title][oldProduct.Id] = product;
				ProductsByPrice [oldProduct.Price][oldProduct.Id] = product;
				ProductsByTitlePrice [oldProduct.Title][oldProduct.Price] [oldProduct.Id] = product;
				ProductsBySupplierPrice [oldProduct.Supplier][oldProduct.Price] [oldProduct.Id] = product;
				return;
			}

			if( !ProductsByPrice.ContainsKey(product.Price)) {
				ProductsByPrice [product.Price] = new OrderedDictionary<int, Product> ();
			}
			if (!ProductsByTitlePrice.ContainsKey (product.Title)) {
				ProductsByTitle [product.Title] = new OrderedDictionary<int, Product> ();
				ProductsByTitlePrice [product.Title] = new OrderedDictionary<float, OrderedDictionary<int, Product>> ();
			}
			if( !ProductsByTitlePrice [product.Title].ContainsKey(product.Price) ){
				ProductsByTitlePrice [product.Title] [product.Price] = new OrderedDictionary<int, Product> ();
			}
			if (!ProductsBySupplierPrice.ContainsKey (product.Supplier)) {
				ProductsBySupplierPrice [product.Supplier] = new OrderedDictionary<float, OrderedDictionary<int, Product>> ();
			}
			if( !ProductsBySupplierPrice [product.Supplier].ContainsKey(product.Price) ){
				ProductsBySupplierPrice [product.Supplier] [product.Price] = new OrderedDictionary<int, Product> ();
			}


			ProductsById [product.Id] = product;
			ProductsByTitle [product.Title] [product.Id] = product;
			ProductsByPrice [product.Price] [product.Id] = product;
			ProductsByTitlePrice [product.Title] [product.Price][product.Id] = product;
			ProductsBySupplierPrice [product.Supplier] [product.Price][product.Id] = product;
		}

		public void Remove(Product product)
		{
			ProductsById.Remove (product.Id);

			ProductsByTitle [product.Title].Remove(product.Id);
			if (0 == ProductsByTitle [product.Title].Count) {
				ProductsByTitle.Remove(product.Title);
			}

			ProductsByPrice [product.Price].Remove(product.Id);
			if (0 == ProductsByPrice [product.Price].Count) {
				ProductsByPrice.Remove(product.Price);
			}

			ProductsByTitlePrice [product.Title][product.Price].Remove(product.Id);
			if (0 == ProductsByTitlePrice [product.Title][product.Price].Count) {
				ProductsByTitlePrice[product.Title].Remove(product.Price);
			}
			if (0 == ProductsByTitlePrice [product.Title].Count) {
				ProductsByTitlePrice.Remove(product.Title);
			}

			ProductsBySupplierPrice [product.Supplier][product.Price].Remove(product.Id);
			if (0 == ProductsBySupplierPrice [product.Supplier][product.Price].Count) {
				ProductsBySupplierPrice[product.Supplier].Remove(product.Price);
			}
			if (0 == ProductsBySupplierPrice [product.Supplier].Count) {
				ProductsBySupplierPrice.Remove(product.Supplier);
			}

		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return (IEnumerator) GetEnumerator();
		}

		public IEnumerator GetEnumerator()
		{
			return ProductsById.GetEnumerator ();
		}


		public IEnumerator FindByPrice(float from, float to)
		{
			return ProductsByPrice.Range (from, true, to, true).GetEnumerator();
		}

		public IEnumerator FindByTitle(string title)
		{
			return ProductsByTitle[title].GetEnumerator();
		}

		public IEnumerator FindByTitlePrice(string title, float price)
		{
			return ProductsByTitlePrice[title][price].GetEnumerator();
		}

		public IEnumerator FindByTitlePrice(string title, float from, float to)
		{
			return ProductsByTitlePrice[title].Range(from, true, to, true).GetEnumerator();
		}

		public IEnumerator FindBySupplierPrice(string supplier, float price)
		{
			return ProductsBySupplierPrice[supplier][price].GetEnumerator();
		}

		public IEnumerator FindBySupplierPrice(string supplier, float from, float to)
		{
			return ProductsBySupplierPrice[supplier].Range(from, true, to, true).GetEnumerator();
		}

	}
}

