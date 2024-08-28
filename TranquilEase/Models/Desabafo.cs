using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using ColumnAttribute = Postgrest.Attributes.ColumnAttribute;
using TableAttribute = Postgrest.Attributes.TableAttribute;
using Postgrest.Attributes;
using Postgrest.Models;

namespace TranquilEase.Models
{
    [Table("desabafo")]
    class Desabafo : BaseModel
    {
        [PrimaryKey("desabafo_id")]
        public int desabafo_id { get; set; }

        [Column("user_id_desabafo")]
        public int user_id_desabafo { get; set; }

        [Column("desabafo_txt")]
        public string desabafo_txt { get; set; }

        [Column("desabafo_date_time")]
        public string desabafo_date_time { get; set; }
    }
}
