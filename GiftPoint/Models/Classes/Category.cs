using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiftPoint.Models
{
    public partial class Category
    {
        private GiftPointEntities context = new GiftPointEntities();
        public bool Add()
        {
            try
            {
                using (context = new GiftPointEntities())
                {
                    context.Categories.Add(this);
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
                    var result = context.Categories.FirstOrDefault(x => x.CategoryId.Equals(this.CategoryId));
                    if (result != null)
                    {
                        result.ParentId = this.ParentId;
                        result.CategoryTitle = this.CategoryTitle;
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

        public Category GetById()
        {
            try
            {
                using (var context = new GiftPointEntities())
                {
                    return context.Categories.FirstOrDefault(x => x.CategoryId.Equals(this.CategoryId));
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<vw_Categories> GetAll()
        {
            try
            {
                using (var context = new GiftPointEntities())
                {
                    return context.vw_Categories.OrderBy(x => x.ParentId).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<vw_Categories>();
            }
        }

        public bool Delete()
        {
            try
            {
                using (var context = new GiftPointEntities())
                {
                    var result = context.Categories.FirstOrDefault(x => x.CategoryId.Equals(this.CategoryId));
                    if (result != null)
                    {
                        context.Categories.Remove(result);
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

        public List<usp_ParentCategories_Result> GetParentCategories()
        {
            try
            {
                using(context = new GiftPointEntities())
                {
                    var result = context.usp_ParentCategories().ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return new List<usp_ParentCategories_Result>();
            }
        }
    }
}