using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiftPoint.Models
{
    public partial class Brand
    {
        private GiftPointEntities context = new GiftPointEntities();
        public bool Add()
        {
            try
            {
                using(context = new GiftPointEntities())
                {
                    context.Brands.Add(this);
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
                    var result = context.Brands.FirstOrDefault(x => x.BrandId.Equals(this.BrandId));
                    if (result != null)
                    {
                        result.BrandTitle = this.BrandTitle;
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

        public Brand GetById()
        {
            try
            {
                using (var context = new GiftPointEntities())
                {
                    return context.Brands.FirstOrDefault(x => x.BrandId.Equals(this.BrandId));
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Brand> GetAll()
        {
            try
            {
                using (var context = new GiftPointEntities())
                {
                    return context.Brands.ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<Brand>();
            }
        }

        public bool Delete()
        {
            try
            {
                using (var context = new GiftPointEntities())
                {
                    var result = context.Brands.FirstOrDefault(x => x.BrandId.Equals(this.BrandId));
                    if(result != null)
                    {
                        context.Brands.Remove(result);
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
    }
}