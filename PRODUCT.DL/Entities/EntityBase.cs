using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRODUCT.DL.Entities
{
    public class EntityBase
    {
        public EntityBase()
        {
            this.DateCreate = DateTime.Now;
        }

        /// <summary>
        /// The unique id and primary key for object
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Date of creation of the object 
        /// </summary>
        [Column("Date_Create")]
        public DateTime DateCreate { get; set; }
    }
}
