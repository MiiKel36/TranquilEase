using Postgrest.Attributes;
using Postgrest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ColumnAttribute = Postgrest.Attributes.ColumnAttribute;
using TableAttribute = Postgrest.Attributes.TableAttribute;

namespace TranquilEase.Models
{
    [Table("usuario")]
    public class Usuario : BaseModel
    {
        private string _user;
        private string _senha;
        private string _email;


        [PrimaryKey("user_id")]
        public int user_id { get; set; }
        [Column("nome")]
        public string nome { get; set; }        
        [Column("email")]
        public string email
        {
            get { return _email; }
            set
            {
                try
                {
                    MailAddress mailAddress;
                    mailAddress = new MailAddress(value);

                    _email = value;
                }
                catch (Exception e)
                {
                    throw new ArgumentException("O endereço de e-mail fornecido é inválido.");
                }
            }
        }
        [Column("senha")]
        public string senha { get; set; }
              
    }


}
