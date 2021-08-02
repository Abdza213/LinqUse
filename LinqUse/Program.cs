using LinqUse.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqUse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Categores> categores = new List<Categores>
            {
                new Categores { CategoryId = 1, CategoryName = "Laptob"},
                new Categores { CategoryId = 2, CategoryName = "Mobile"}
            };

            List<Products> products = new List<Products>
            {
                new Products { ProductId = 1, CategoryId = 1, ProductName = "Asus Laptob", Description = "16 Ram, 512 ssd", UnitInPrice = 12000, UnitInStock = 10},
                new Products { ProductId = 2, CategoryId = 1, ProductName = "Acer Laptob", Description = "8 Ram, 512 ssd", UnitInPrice = 9500, UnitInStock = 20},
                new Products { ProductId = 3, CategoryId = 2, ProductName = "Samsung Mobile", Description = "4 Ram, 64gb, 128MP", UnitInPrice = 4560, UnitInStock = 100},
                new Products { ProductId = 4, CategoryId = 2, ProductName = "IPhone Mobile", Description = "4 Ram, 128gb, 64MP", UnitInPrice = 8000, UnitInStock = 80},
                new Products { ProductId = 5, CategoryId = 1, ProductName = "Dell Laptob", Description = "4 Ram, 256 ssd", UnitInPrice = 3000, UnitInStock = 5},
                new Products { ProductId = 6, CategoryId = 1, ProductName = "Hawawi Mobile", Description = "4 Ram, 64gb, 64MP", UnitInPrice = 12000, UnitInStock = 10}
            };

            // AnyLinq(products);

            //SingleOrDefauktLinq(products);

            // WereLinq(products);

            //OrderBy(products);

            //OrderByDescending(products);

            //FromLinq(products);

            //
            //A -> B هنا يتم ايضا ترتيب الاسماء بالترتيب من 
            //ThenBy(P => P.ProductName)
            //------------------
            //Z -> A هنا يتم ايضا ترتيب الاسماء عكسيا
            //من 
            //ThenByDescending(p => p.ProductName)

            //ascending من الصغير الى الكبير
            //descending  من الكبير الى الصغير


            //FromLinqInMethod(products);

            //FromLinqInMethod2(categores, products);

            Console.ReadKey();
        }

        private static void FromLinqInMethod2(List<Categores> categores, List<Products> products)
        {
            var result = from P in products
                         join C in categores
                         on P.CategoryId equals C.CategoryId
                         where P.CategoryId == 1
                         select new PrintProduct
                         {
                             Description = P.Description,
                             ProductName = P.ProductName,
                             UnitInPrice = P.UnitInPrice,
                             CategoryName = C.CategoryName

                         };

            foreach (var P in result)
            {
                Console.WriteLine("Category Name -: {0} \nProduct Name -: {1} \nDescription -: {2} \nPrice -: {3}",
                                P.CategoryName,
                                P.ProductName,
                                P.Description,
                                P.UnitInPrice);
                //select فقط يمكن طباعة الاوامر المحددة داخل ال 
            }
        }

        private static void FromLinqInMethod(List<Products> products)
        {
            var result = from P in products
                         where P.CategoryId == 1
                         select new PrintProduct
                         {
                             Description = P.Description,
                             ProductName = P.ProductName,
                             UnitInPrice = P.UnitInPrice
                         };

            foreach (var P in result)
            {
                Console.WriteLine("Product Name -: {0} \nDescription -: {1} \nPrice -: {2}",
                                    P.ProductName,
                                    P.Description,
                                    P.UnitInPrice);
                //select فقط يمكن طباعة الاوامر المحددة داخل ال 
            }
        }

        private static void FromLinq(List<Products> products)
        {
            var result = from P in products
                         where P.UnitInPrice > 8000
                         orderby P.UnitInPrice descending
                         select P;
            // select P; 
            //select P.ProductName; هنا يمكننا وضع اوامر الطباعة ايضا 
            //P فقط نكتب  for عند وضع اوامر الطباعة داخل ال  
            //ascending من الصغير الى الكبير
            //descending  من الكبير الى الصغير
            foreach (var P in result)
            {
                Console.WriteLine("Product Name -: {0} \nDescription -: {1} \nPrice -: {2}",
                P.ProductName,
                P.Description,
                P.UnitInPrice);

                // select P.ProductName;
                // foreach(var P in result)
                // {
                //  Console.WritLine(P.ProductName);
                // }
                // هنا الان فقط يطبع الاسماء
                //
            }
        }

        private static void OrderBy(List<Products> products)
        {
            var result = products.Where(P => P.ProductName.Contains("Laptob")).OrderBy(P => P.UnitInPrice);
            foreach (var P in result)
            {
                Console.WriteLine("Product Name -: {0} \nDescription -: {1} \nPrice -: {2}",
                P.ProductName,
                P.Description,
                P.UnitInPrice);
            }
            //OrderBy
            // يتم عن طريقها ترتيب الاسعار من الاصغر الى الاكبر

        }

        private static void OrderByDescending(List<Products> products)
        {
            var result = products.Where(P => P.ProductName.Contains("Laptob")).OrderByDescending(P => P.UnitInPrice).ThenByDescending(p => p.ProductName);

            //OrderByDescending 
            // يتم عن طريقها ترتيب الاسعار من الاكبر الى الاصغر

            foreach (var P in result)
            {
                Console.WriteLine("Product Name -: {0} \nDescription -: {1} \nPrice -: {2}",
                P.ProductName,
                P.Description,
                P.UnitInPrice);
            }
        }

        private static void WereLinq(List<Products> products)
        {
            var result = products.Where(P => P.ProductName.Contains("Laptob"));
            foreach (var P in result)
            {
                Console.WriteLine("Product Name -: {0} \nDescription -: {1} \nPrice -: {2}",
                P.ProductName,
                P.Description,
                P.UnitInPrice);
            }
        }

        private static void SingleOrDefauktLinq(List<Products> products)
        {
            var result = products.SingleOrDefault(P => P.ProductId == 3);
            Console.WriteLine("Product Name -: {0} \nDescription -: {1} \nPrice -: {2}",
                result.ProductName,
                result.Description,
                result.UnitInPrice);
            // SingleOrDefault && Find
            // يتم استخدام هذه الدوال للوصول الى معلومات متغيير واحد
            // لذلك يفضل استخدام عنوان المنتج لعدم تكراره في منتجات اخرى 
        }

        private static void AnyLinq(List<Products> products)
        {
            var result = products.Any(P => P.ProductName == "Asus Laptob");
            Console.WriteLine("Result -: " + result); // true or false 
        }
    }
}
