using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using ExamenAPP_KevinR.Models;

namespace ExamenAPP_KevinR.ViewModels
{
    class UserViewModel : BaseViewModel
    {
        public User MyUser { get; set; }

        public UserViewModel()
        {
            MyUser = new User();
        }

        // Método para consultar un usuario por ID
        public async Task<User?> VmConsultarUsuarioPorID(int IDUsuario)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                var user = await MyUser.ConsultarUsuarioPorID(IDUsuario);

                if (user != null)
                {
                    MyUser = user;
                }

                return user;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
