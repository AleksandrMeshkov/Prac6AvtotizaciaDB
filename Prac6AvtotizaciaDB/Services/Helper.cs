using Prac6AvtotizaciaDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prac6AvtotizaciaDB.Services
{
    public class Helper
    {
        private static ClientEntities _context;


        public static ClientEntities GetContext()
        {
            if (_context == null)
            {
                _context = new ClientEntities();
            }
            return _context;
        }
    }
}
