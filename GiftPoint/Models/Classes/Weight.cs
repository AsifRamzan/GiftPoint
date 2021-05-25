using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiftPoint.Models
{
    public partial class Weight
    {
        private GiftPointEntities context = new GiftPointEntities();
        public bool Add()
        {
            try
            {
                using (context = new GiftPointEntities())
                {
                    context.Weights.Add(this);
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
                    var result = context.Weights.FirstOrDefault(x => x.WeightId.Equals(this.WeightId));
                    if (result != null)
                    {
                        result.WeightTitle = this.WeightTitle;
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

        public Weight GetById()
        {
            try
            {
                using (var context = new GiftPointEntities())
                {
                    return context.Weights.FirstOrDefault(x => x.WeightId.Equals(this.WeightId));
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Weight> GetAll()
        {
            try
            {
                using (var context = new GiftPointEntities())
                {
                    return context.Weights.ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<Weight>();
            }
        }

        public bool Delete()
        {
            try
            {
                using (var context = new GiftPointEntities())
                {
                    var result = context.Weights.FirstOrDefault(x => x.WeightId.Equals(this.WeightId));
                    if (result != null)
                    {
                        context.Weights.Remove(result);
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