using ExamenAPP_KevinR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAPP_KevinR.ViewModels
{
    class AskViewModel : BaseViewModel
    {
        public AskStatus MyAskStatus { get; set; }
        public User MyUser { get; set; }

        public Ask MyAsk { get; set; }


        public AskViewModel()
        {
            MyAskStatus = new AskStatus();
            MyUser = new User();
            MyAsk = new Ask();
        }


        public async Task<List<AskStatus>?> VmGetAskStatusAsync()
        {
            try
            {
                List<AskStatus>? status = new List<AskStatus>();

                status = await MyAskStatus.GetAskStatusAsync();

                if (status == null) return null;

                return status;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<User>?> VmGetUserAsync()
        {
            try
            {
                List<User>? names = new List<User>();

                names = await MyUser.GetUserAsync();

                if (names == null) return null;

                return names;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //funcion para agregar pregunta
        public async Task<bool> VmAddAsk(DateTime pFecha, string pPregunta, bool pStrike, string pUrlImage, string pAskDetail, int pUsuarioID, int pStatusID)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {

                MyAsk = new ()
                {
                    Fecha = pFecha,
                    Pregunta1 = pPregunta,
                    EsStrike = pStrike,
                    DireccionImagen = pUrlImage,
                    DetallePregunta = pAskDetail,
                    IdUsuario = pUsuarioID,
                    IdPreguntaEstado = pStatusID,

                };

                bool Ret = await MyAsk.AddAskAsync();

                return Ret;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            { IsBusy = false; }
        }

    }
}
