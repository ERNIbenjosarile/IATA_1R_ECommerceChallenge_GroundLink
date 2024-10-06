using Microsoft.EntityFrameworkCore;
using X_Hackathon.Domain;

namespace X_Hackathon.Business
{
    public class ProductCalculator
    {
        private readonly DatabaseContext dbContext;
        public ProductCalculator(DatabaseContext DbContext)
        {
            dbContext = DbContext;
        }

        public void Calculate()
        {
            var awbs = dbContext.AirwayBills.ToList();
            var pls = dbContext.PackingLists.ToList();
            var cis = dbContext.CommercialInvoices.ToList();

            HashSet<string> HS = new HashSet<string>();
            HS.UnionWith(awbs.Select(a => a.ExternalReference).ToList());
            HS.UnionWith(pls.Select(a => a.ReferenceNumber).ToList());
            HS.UnionWith(cis.Select(a => a.AWBNumber).ToList());

            foreach (var reference in HS)
            {
                if (dbContext.Products.Any(p => p.ReferenceNumber == reference))
                {
                    continue;
                }
                var awb = awbs.FirstOrDefault(x => x.ExternalReference == reference);
                var pl = pls.FirstOrDefault(x => x.ReferenceNumber == reference);
                var ci = cis.FirstOrDefault(x => x.AWBNumber == reference);

                var prod = new Product()
                {
                    ReferenceNumber = reference,
                    Amount = awb?.Amount != string.Empty ? awb?.Amount : ci?.Amount,
                    Destination = awb?.ArrivalLocation != string.Empty ? awb?.ArrivalLocation : pl?.Destination != null ? pl?.Destination : ci?.Destination,
                    NumberOfPieces = awb?.NumberOfPieces != string.Empty ? awb?.NumberOfPieces : pl?.NumberOfPieces != null ? pl?.NumberOfPieces : ci.NumberOfPieces,
                    Origin = awb?.Origin != string.Empty ? awb?.Origin : pl?.Origin != null ? pl?.Origin : ci?.Origin,
                    TypeOfGoods = awb?.TypeOfGoods != string.Empty ? awb?.TypeOfGoods : pl?.TypeOfGoods != null ? pl?.TypeOfGoods : ci?.TypeOfGoods,
                    Volume = awb?.Volume != string.Empty ? awb?.Volume : pl?.Volume != null ? pl?.Volume : ci?.Volume,
                    Weight = awb?.Weight != string.Empty ? awb?.Weight : ci?.Weight,
                    FileUrls = awb?.FileUrl != null ? awb?.FileUrl : pl?.FileUrl != null ? pl?.FileUrl : ci.FileUrl
                };

                prod.Amount = prod.Amount ?? string.Empty;
                prod.Destination = prod.Destination ?? string.Empty;
                prod.NumberOfPieces = prod.NumberOfPieces ?? string.Empty;
                prod.Origin = prod.Origin ?? string.Empty;
                prod.TypeOfGoods = prod.TypeOfGoods ?? string.Empty;
                prod.Volume = prod.Volume ?? string.Empty;
                prod.Weight = prod.Weight ?? string.Empty;
                prod.FileUrls = prod.FileUrls ?? string.Empty;
                dbContext.Products.Add(prod);
            }
            dbContext.SaveChanges();
        }
    }
}
