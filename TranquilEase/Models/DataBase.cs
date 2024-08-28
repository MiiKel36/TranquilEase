using Newtonsoft.Json;
using Postgrest.Attributes;
using Postgrest.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Postgrest.Constants;


namespace TranquilEase.Models
{
    internal class DataBase
    {

        //Conecta com o baco de dados
        //To-Do: Tirar do hardCode
        //informações retiradas por segurança

        private string url = "";
        private string key = "";

        #region pagina de cadastro
        public async void InsertUserOnBD(dynamic user_data)
        {
            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            var supabase = new Supabase.Client(url, key, options);

            await supabase.InitializeAsync();
            await supabase.From<Usuario>().Insert(user_data);
        }

        public async Task<bool> ReturnIfExistUserEmailOnBD(string email)
        {
            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            var supabase = new Supabase.Client(url, key, options);

            var count = await supabase
                        .From<Usuario>()
                        .Select(x => new object[] { x.email })
                        .Where(x => x.email == email)
                        .Count(Postgrest.Constants.CountType.Exact);

            if(count>=1)
            {
                return false;
            }

            return true; 
        }

        #endregion

        #region pagina de login

        public async Task<string> ReturnIfAccountExist(Usuario user_info)
        {

            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            var supabase = new Supabase.Client(url, key, options);

            var count = await supabase
            .From<Usuario>()
            .Select(x => new object[] { x.user_id })
            .Where(x => x.email == user_info.email)
            .Count(Postgrest.Constants.CountType.Exact);

            var exist = await supabase
            .From<Usuario>()
            .Select(x => new object[] { x.user_id, x.senha})
            .Where(x => x.email == user_info.email)
            .Get();

            Console.WriteLine();

            if (count == 0)
            {
                return "email_nao_encontrado";
            }

            List<ObjIdFromApi> usuarios = JsonConvert.DeserializeObject<List<ObjIdFromApi>>(exist.Content);
            ObjIdFromApi userInfo = usuarios[0];
            
            string userId  = Convert.ToString(userInfo.user_id);
            string userSenha = userInfo.senha;

            if (userSenha != user_info.senha)
            {
                return "senha_incorreta";
            }

            return userId;
        }

        #endregion

        #region desabafo

        public async void InsertDesabafoOnBD(dynamic desabafo_data)
        {
            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            var supabase = new Supabase.Client(url, key, options);
            var supabase22 = new Supabase.Client(url, key, options);

            await supabase.InitializeAsync();
            await supabase.From<Desabafo>().Insert(desabafo_data);
        }
        public async Task<List<Desabafo>> ReturnAllDesabafosOfUser(string userId)
        {
            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            var supabase = new Supabase.Client(url, key, options);

            int userIdConverted = Convert.ToInt32(userId);

            var count = await supabase
            .From<Desabafo>()
            .Where(x => x.user_id_desabafo == userIdConverted)
            .Count(CountType.Exact);

            var desabafosFromBD = await supabase
            .From<Desabafo>()
            .Where(x => x.user_id_desabafo == userIdConverted)
            .Get();

            List<Desabafo> listOfDesabafos = JsonConvert.DeserializeObject<List<Desabafo>>(desabafosFromBD.Content);

            return listOfDesabafos;
        }

        
        public async void DeleteDesabafosOfUser(int desabafoId)
        {
            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            var supabase = new Supabase.Client(url, key, options);

            await supabase
            .From<Desabafo>()
            .Where(x => x.desabafo_id == desabafoId)
            .Delete();

        }
        #endregion

        #region sentimento

        public async void InsertSentimentoOnBD(dynamic sentimento_data)
        {
            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            var supabase = new Supabase.Client(url, key, options);

            await supabase.InitializeAsync();
            await supabase.From<ComoSeSente>().Insert(sentimento_data);
        }
        public async Task<List<ComoSeSente>> ReturnAllSentimentoOfUser(string userId)
        {
            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            var supabase = new Supabase.Client(url, key, options);

            int userIdConverted = Convert.ToInt32(userId);

            var count = await supabase
            .From<ComoSeSente>()
            .Where(x => x.user_id_emoçao == userIdConverted)
            .Count(CountType.Exact);

            var sentimentoFromBD = await supabase
            .From<ComoSeSente>()
            .Where(x => x.user_id_emoçao == userIdConverted)
            .Get();

            List<ComoSeSente> listOfDesabafos = JsonConvert.DeserializeObject<List<ComoSeSente>>(sentimentoFromBD.Content);

            return listOfDesabafos;
        }



        public async void DeleteSentimentoOfUser(int emocaoId)
        {
            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            var supabase = new Supabase.Client(url, key, options);

            await supabase
            .From<ComoSeSente>()
            .Where(x => x.emoçao_id == emocaoId)
            .Delete();

        }

        #endregion

    }
}

