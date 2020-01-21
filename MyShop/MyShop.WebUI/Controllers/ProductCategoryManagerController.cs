using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;

namespace MyShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        ProductCategoryRepository context;

        public ProductCategoryManagerController()
        {
            this.context = new ProductCategoryRepository();
        }

        public ActionResult _ProductCategoryPreValidation(String id)
        {
            ProductCategory productCategory = this.context.Find(id);

            if (productCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategory);
            }
        }

        public ActionResult Index()
        {
            List<ProductCategory> productCategories = this.context.Collection().ToList();
            return View(productCategories);
        }

        public ActionResult Create()
        {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }

        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }
            else
            {
                this.context.Insert(productCategory);
                this.context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(String id)
        {
            return this._ProductCategoryPreValidation(id);
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory, String id)
        {
            ProductCategory productCategoryToEdit = this.context.Find(id);

            if (productCategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCategory);
                }

                productCategoryToEdit.Category = productCategory.Category;

                this.context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(String id)
        {
            return this._ProductCategoryPreValidation(id);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(String id)
        {
            ProductCategory productCategoryToDelete = this.context.Find(id);

            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                this.context.Delete(id);
                this.context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}