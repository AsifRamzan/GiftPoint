using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiftPoint.Models
{
    public partial class Company
    {
        private GiftPointEntities context = new GiftPointEntities();
        public bool Add()
        {
            try
            {
                using (context = new GiftPointEntities())
                {
                    context.Companies.Add(this);
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
                    var result = context.Companies.FirstOrDefault(x => x.CompanyId.Equals(this.CompanyId));
                    if (result != null)
                    {                        
                        result.CompanyName = this.CompanyName;
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

        public Company GetById()
        {
            try
            {
                using (var context = new GiftPointEntities())
                {
                    return context.Companies.FirstOrDefault(x => x.CompanyId.Equals(this.CompanyId));
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Company> GetAll()
        {
            try
            {
                using (var context = new GiftPointEntities())
                {
                    return context.Companies.ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<Company>();
            }
        }

        public bool Delete()
        {
            try
            {
                using (var context = new GiftPointEntities())
                {
                    var result = context.Companies.FirstOrDefault(x => x.CompanyId.Equals(this.CompanyId));
                    if (result != null)
                    {
                        context.Companies.Remove(result);
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