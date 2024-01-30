using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRODUCT.BOL.Dto
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Matricule { get; set; }
        public string Slug { get; set; }
        public DateTime DateEdit { get; set; }
        public string DateEditStr { 
            get { return DateEdit.ToString("dd/MM/yyyy HH:mm:ss"); }
        }
        public DateTime CreateDate { get; set; }
        public string CreateDateStr {
            get { return CreateDate.ToString("dd/MM/yyyy HH:mm:ss"); }
        }
    }
}
