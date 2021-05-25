using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiftPoint.Models
{
    public partial class ProductPhoto
    {
        private GiftPointEntities context = new GiftPointEntities();

        public List<ProductPhoto> Detail { get; set; }

        public bool Add()
        {
            try
            {
                using (context = new GiftPointEntities())
                {
                    context.ProductPhotos.Add(this);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<ProductPhoto> GetById()
        {
            try
            {
                using (var context = new GiftPointEntities())
                {
                    return context.ProductPhotos.Where(x => x.ProductId.Equals(this.ProductId)).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<ProductPhoto>();
            }
        }
    }
}