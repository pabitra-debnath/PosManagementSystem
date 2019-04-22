using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.DAL.Setup;
using POS.Models.Setup;

namespace POS.BLL.Setup
{
    public class PartyManager
    {
        PartyGetway _partyDal = new PartyGetway();

        public bool IsPartySaved(Party party)
        {
            return _partyDal.IsPartySaved(party);
        }

        public List<Party> GetPartyList()
        {
            return _partyDal.GetPartyList();
        }

        public string GetPartyPreCode()
        {
            string year = DateTime.Now.Year.ToString();
            string month = string.Format("{0:00}", DateTime.Now.Month);
            return year + month;
        }
        public string GetPartyCode()
        {
            string preCode = GetPartyPreCode();
            return _partyDal.GetPartyCode(preCode);
        }
        
        public Party FindParty(long? id)
        {
            return _partyDal.FindParty(id);
        }

        public bool IsPartyUpdated(Party party)
        {
            return _partyDal.IsPartyUpdated(party);
        }

        public bool IsPartyDeleted(long id)
        {
            return _partyDal.IsPartyDeleted(id);
        }

        public bool IsUniqueName(string name, string initialName)
        {
            if (initialName == name)
            {
                return true;
            }
            return _partyDal.IsUniqueName(name);
        }

        public bool IsUniqueCode(string preCode, string code, string initialPreCode, string initialCode)
        {
            if ((initialPreCode + initialCode) == (preCode + code))
            {
                return true;
            }
            return _partyDal.IsUniqueCode(preCode, code);
        }
    }
}
