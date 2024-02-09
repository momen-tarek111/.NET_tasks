using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using project2.Models;
using System.Globalization;
using System.IO.Pipes;
using System.Reflection.Metadata;
using static System.Reflection.Metadata.BlobBuilder;

namespace project2.Controllers
{
    public class DashBoardController : Controller
    {
        private static List<Product> products=new List<Product>();
        private static List<Blog> blogs = new List<Blog>();
        public IActionResult Index()
        {
            return View();
        }
        #region AddProduct
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            int Id;
            if (products.Count == 0)
            {
                Id = 1;
            }
            else
                Id = products.Max(p => p.Id) + 1;
            product.Id = Id;
            if (product.company.Id == 1)
            {
                product.company.Name = "nike";
            }
            else if (product.company.Id == 2)
            {
                product.company.Name = "adidas";
            }
            products.Add(product);
            return RedirectToAction("index");
        }
        #endregion
        #region PrintAllData
        public IActionResult ViewAllData()
        {
            return View(products);
        }
        #endregion
        #region Delete
        public IActionResult Delete(int id)
        {
            Product product = products.FirstOrDefault(x => x.Id == id);
            products.Remove(product);
            return RedirectToAction("ViewAllData");
        }
        #endregion
        #region EditProduct
        public IActionResult Edit(int id)

        {
            Product product = products.FirstOrDefault(p => p.Id == id);

            return View(product);

        }
        [HttpPost]
        public IActionResult Edit(Product product)

        {
            Product pd = products.FirstOrDefault(p => p.Id == product.Id);

            pd.Name= product.Name;
            pd.Description= product.Description;
            pd.Price= product.Price;
            pd.Quantity= product.Quantity;
            pd.EnableSize= product.EnableSize;
            pd.company.Id = product.company.Id;


            return RedirectToAction("index");
        }
        #endregion
        #region AddBlog
        public IActionResult AddBlog(int id =-1)
        {
            Blog blog=new Blog();
            if (id == -1) { 
                blog.category=new Category();
                return View(blog);
            }
            else
            {
                blog = blogs.FirstOrDefault(p => p.Id == id);
                return View(blog);
            }
        }
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            Blog bl = blogs.FirstOrDefault(p => p.Id == blog.Id);
            if (bl!=null) {
                bl.Title = blog.Title;
                bl.Content = blog.Content;
                bl.AuthorName = blog.AuthorName;
                bl.available = blog.available;
                if (bl.category.Id != blog.category.Id)
                {

                    if (blog.category.Id == 1)
                    {
                        bl.category.Name = "Tutorial";

                    }
                    else if (blog.category.Id == 2)
                    {
                        bl.category.Name = "News";
                    }
                    else if (blog.category.Id == 3)
                    {
                        bl.category.Name = "Business";

                    }
                    else if (blog.category.Id == 4)
                    {
                        bl.category.Name = "Fitness";

                    }
                    else if (blog.category.Id == 5)
                    {
                        bl.category.Name = "Sports";

                    }
                }
                bl.category.Id = blog.category.Id;
            }
            else { 
                int Id;
                if (blogs.Count == 0)
                {
                    Id = 1;
                }
                else
                    Id = blogs.Max(p => p.Id) + 1;
                blog.Id = Id;
                if (blog.category.Id == 1)
                {
                    blog.category.Name = "Tutorial";
                }
                else if (blog.category.Id == 2)
                {
                    blog.category.Name = "News";
                }
                else if (blog.category.Id == 3)
                {
                    blog.category.Name = "Business";
                }
                else if (blog.category.Id == 4)
                {
                    blog.category.Name = "Fitness";
                }
                else if (blog.category.Id == 5)
                {
                    blog.category.Name = "Sports";
                }
                blogs.Add(blog);
            }
            return RedirectToAction("index");
        }
        #endregion
        #region PrintAllBlogs
        public IActionResult ViewAllBlogs()
        {
            return View(blogs);
        }
        #endregion
        #region DeleteBlog
            public IActionResult DeleteBlog(int id)
            {
                Blog blog = blogs.FirstOrDefault(x => x.Id == id);
                blogs.Remove(blog);
                return RedirectToAction("ViewAllData");
            }
        #endregion
       /* #region EditBlog
            public IActionResult EditBlog(int id)

            {
                Blog blog = blogs.FirstOrDefault(p => p.Id == id);

                return View(blog);

            }
            [HttpPost]
            public IActionResult EditBlog(Blog blog)

            {
                Blog bl = blogs.FirstOrDefault(p => p.Id == blog.Id);

                bl.Title = blog.Title;
                bl.Content = blog.Content;
                bl.AuthorName = blog.AuthorName;
                bl.available = blog.available;
            if (bl.category.Id != blog.category.Id)
            {
               
                if (blog.category.Id == 1)
                {
                    bl.category.Name = "Tutorial";

                }
                else if (blog.category.Id == 2)
                {
                    bl.category.Name = "News";
                }
                else if (blog.category.Id == 3)
                {
                    bl.category.Name = "Business";

                }
                else if (blog.category.Id == 4)
                {
                    bl.category.Name = "Fitness";

                }
                else if (blog.category.Id == 5)
                {
                    bl.category.Name = "Sports";

                }
            }
            bl.category.Id = blog.category.Id;
            return RedirectToAction("index");
            }
        #endregion*/
    }
}
