using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Models.Setup;

namespace POS.DAL.Setup
{
    public class PartyGetway
    {
        PosDbContext dbContext = new PosDbContext();
        public List<Party> GetPartyList()
        {
            var list = dbContext.Parties.OrderByDescending(c=>c.Id).ToList();
            return list;
        }

        public string GetPartyCode(string preCode)
        {
            long code;

            if (dbContext.Parties.Where(x => x.PreCode == preCode).ToList().Count > 0)
            {
                code = Convert.ToInt64(dbContext.Parties.Where(x => x.PreCode == preCode).Select(x => x.Code).Max());

                if (code >= 9999)
                {
                    var allNumbers = Enumerable.Range(1, 9999).Select(y => (long)y);
                    var currentList = ((IEnumerable<string>)dbContext.Parties.Where(x => x.PreCode == preCode).Select(x => x.Code))
                        .Select(x => Convert.ToInt64(x));
                    var missingNumbersFirst = allNumbers.Except(currentList).First();
                    code = missingNumbersFirst - 1;
                }
            }
            else
            {
                code = 0;
            }

            return string.Format("{0:0000}", (code + 1));
        }
        public bool IsPartySaved(Party party)
        {
            dbContext.Parties.Add(party);
            return dbContext.SaveChanges() > 0;
        }

        public Party FindParty(long? id)
        {
            var party = dbContext.Parties.FirstOrDefault(c => c.Id == id);
            return party;
        }

        public bool IsPartyUpdated(Party party)
        {
            PosDbContext db = new PosDbContext();
            db.Parties.Attach(party);
            db.Entry(party).State= EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool IsPartyDeleted(long id)
        {
            var party = dbContext.Parties.FirstOrDefault(c => c.Id == id);
            dbContext.Parties.Remove(party);
            return dbContext.SaveChanges() > 0;
        }

        public bool IsUniqueName(string name)
        {
            return !dbContext.Parties.Any(x => x.Name == name);
        }

        public bool IsUniqueCode(string preCode, string code)
        {
            return !dbContext.Parties.Any(x => x.Code == code && x.PreCode == preCode);
        }
    }
}
