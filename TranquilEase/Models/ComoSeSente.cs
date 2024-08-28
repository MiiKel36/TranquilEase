using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ColumnAttribute = Postgrest.Attributes.ColumnAttribute;
using TableAttribute = Postgrest.Attributes.TableAttribute;
using Postgrest.Attributes;
using Postgrest.Models;

namespace TranquilEase.Models
{
    [Table("emoçoes")]
    public class ComoSeSente : BaseModel
    {
        [PrimaryKey("emoçao_id")]
        public int emoçao_id { get; set; }

        [Column("user_id_emoçao")]
        public int user_id_emoçao { get; set; }

        [Column("emoçao_selecionada")]
        public string emoçao_selecionada { get; set; }

        [Column("emoçao_txt")]
        public string emoçao_txt { get; set; }

        [Column("feliz_txt")]
        public string feliz_txt { get; set; }

        [Column("triste_txt")]
        public string triste_txt { get; set; }

        [Column("emocao_data_hora")]
        public string emocao_data_hora { get; set; }
    }
}
