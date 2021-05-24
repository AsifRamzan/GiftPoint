using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiftPoint.Models
{
    public partial class Product
    {
        private GiftPointEntities context = new GiftPointEntities();

        public IEnumerable<HttpPostedFileBase> File { get; set; }
        public List<string> EditFilePath { get; set; }
        public IEnumerable<ImageInfo> pathFile { get; set; }

        public bool Add()
        {
            try
            {
                using (context = new GiftPointEntities())
                {
                    context.Products.Add(this);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                using (context = new GiftPointEntities())
                {
                    var result = context.Products.FirstOrDefault(x => x.ProductId.Equals(this.ProductId));
                    if (result != null)
                    {
                        result.ProductTitle = this.ProductTitle;
                        result.Barcode = this.Barcode;
                        result.ProductDescription = this.ProductDescription;
                        result.ProductUsage = this.ProductUsage;
                        result.PurchasePrice = this.PurchasePrice;
                        result.RegularPrice = this.RegularPrice;
                        result.SalePrice = this.SalePrice;
                        result.SaleStartDate = this.SaleStartDate;
                        result.SaleEndDate = this.SaleEndDate;
                        result.DiscountPercent = this.DiscountPercent;
                        result.DiscountValue = this.DiscountValue;
                        result.StockLimitMin = this.StockLimitMin;
                        result.StockLimitMax = this.StockLimitMax;
                        result.ComapnyId = this.ComapnyId;
                        result.BrandId = this.BrandId;
                        result.CategoryId1 = this.CategoryId1;
                        result.CategoryId2 = this.CategoryId2;
                        result.CategoryId3 = this.CategoryId3;
                        result.IsActive = this.IsActive;
                        result.LastUpdatedBy = this.LastUpdatedBy;
                        result.LastUpdatedOn = this.LastUpdatedOn;
                    }

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Product GetById()
        {
            try
            {
                using (var context = new GiftPointEntities())
                {
                    return context.Products.FirstOrDefault(x => x.ProductId.Equals(this.ProductId));
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Product> GetAll()
        {
            try
            {
                using (var context = new GiftPointEntities())
                {
                    return context.Products.ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<Product>();
            }
        }

        public bool Delete()
        {
            try
            {
                using (var context = new GiftPointEntities())
                {
                    var result = context.Products.FirstOrDefault(x => x.ProductId.Equals(this.ProductId));
                    if (result != null)
                    {
                        context.Products.Remove(result);
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return false;
        }

        public List<Category> GetParentCategories()
        {
            try
            {
                using (context = new GiftPointEntities())
                {
                    var result = context.Categories.Where(x => x.ParentId == 0).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return new List<Category>();
            }
        }

        public List<Category> GetCategoriesByParent(int ParentId)
        {
            try
            {
                using (context = new GiftPointEntities())
                {
                    var result = context.Categories.Where(x => x.ParentId == ParentId).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return new List<Category>();
            }
        }

        public List<Company> GetCompanies()
        {
            try
            {
                using (context = new GiftPointEntities())
                {
                    var result = context.Companies.ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return new List<Company>();
            }
        }

        public List<Brand> GetBrands()
        {
            try
            {
                using (context = new GiftPointEntities())
                {
                    var result = context.Brands.ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return new List<Brand>();
            }
        }
    }

    public class ImageInfo
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string FullName
        {
            get { return (this.Path + this.Name); }
        }
    }
}