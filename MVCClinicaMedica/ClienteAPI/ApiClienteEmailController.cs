using Azure;
using Microsoft.AspNetCore.Mvc;
using MVCClinicaMedica.Models;
using Newtonsoft.Json;
using System.Text;

namespace MVCClinicaMedica.ClienteAPI
{
    public class ApiClienteEmailController : Controller
    {
        private System.Timers.Timer timer;
        PacienteBL pacienteBL = new PacienteBL();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Notificaciones()
        {
            List<EmailDTO> listEmails = new List<EmailDTO>();
            return View(listEmails);
        }
        public async Task<IActionResult> Get()
        {
            List<EmailDTO> listEmails = new List<EmailDTO>();
            using (var httpClient = new HttpClient())
            {
                /// la palabra ("api") talvez sea un estandar para que funcione
                using (var response = await httpClient.GetAsync("https://localhost:7012/api/Email"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listEmails = JsonConvert.DeserializeObject<List<EmailDTO>>(apiResponse);
                }
            }
            foreach (EmailDTO c in listEmails)
            {
                Console.WriteLine("-> Para: " + c.Para + " Asunto: " + c.Asunto + " Contenido: " + c.Contenido);
                //await AddEmail(c);
            }

            return View("Notificaciones", listEmails);
        }
        public async Task<IActionResult> AddEmail(EmailDTO email)
        {
            EmailDTO _email = new EmailDTO();
            using (var httpClient = new HttpClient())
            {
                //cliente.Edad = 22;

                ///Convertimos en JSON para poder enviarselo a nuestr api
                string json = JsonConvert.SerializeObject(email);
                Console.WriteLine(json);
                //StringContent content = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json");
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                /// Aqui ya mandamos a gruardar con el metodo POST y se envia coomo JSON(serializada)
                /// Recuerda aqui en la Url poner el nombre de la API si esta quedama como aqui, o si la traes de otro lado
                /// y la pasas como parametro poner correctamente el puerto y el nombre de la API.
                
                using (var response = await httpClient.PostAsync("https://localhost:7012/api/Email/Email/enviarEmail", content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{response.Content}"+"estra a enviar el email");
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        /// Deserializamos para poder enviarla como objeto en una lista y verla en nuestra vista, 
                        /// porque ya enviamos a la API en json (serializada)
                        _email = JsonConvert.DeserializeObject<EmailDTO>(apiResponse);
                    }
                    else
                        /// para mostrar por vista el estado de la transaccion si fue 200 o 400
                        ViewBag.StatusCode = response.StatusCode + " " + response.RequestMessage;
                        ViewData["Correos"] = response.StatusCode + " " + response.RequestMessage;
                }
            }
            /// Creamos una lista de tipo de nuestro modelo y guardamos el objeto (cli) porque ahi se leyo y se escribio
            /// los daos del JSON y desearilazo (OBJETO) para poder guradarla en una lista y enviarla hacia la vista
            List<EmailDTO> listEmail = new List<EmailDTO>();
            listEmail.Add(_email);
            foreach (EmailDTO c in listEmail)
            {
                Console.WriteLine(">>>ClienteApiControlador:AddEmail = " + c.Para);
            }
            return View("Notificaciones", listEmail);
        }
        ///------------------------------------------------------------------------------------------------ <summary>
        /// ------------------------------------------------------------------------------------------------

        public IActionResult ActivarEnvioEmails(EmailDTO email)
        {
            if (timer == null)
            {
                timer = new System.Timers.Timer(30000);
                timer.Elapsed += (sender, e) => EnvioEmails(email);
            }
            timer.Start();
            List<EmailDTO> listaEMAILS = new List<EmailDTO> { email };

            //DesactivarEnvioEmails(timer, false);
            return View("Notificaciones", listaEMAILS);
        }
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>

        public void EnvioEmails(EmailDTO email)
        {
            //timer = new System.Timers.Timer(300000);
            ///metodo para conseguir la lista de clientes(pacientes)
            ///por ejemplo traeremos desde la api una lista quemada
            List<Paciente> personas = new List<Paciente>();
            personas = pacienteBL.retornarPacientesBL();
            int num = 0;
            foreach (Paciente person in personas)
            {
                num++;
                email.Para = person.Correo;
                ViewData["Correo"] = person.Correo;
                Console.WriteLine("CORREO: " + email.Para);
                Console.WriteLine("Contenido: " + email.Contenido);
                Console.WriteLine("Asunto: " + email.Asunto + num);
                ///Enviamos el email
                AddEmail(email);
            }
        }
        public void DesactivarEnvioEmails(bool apagar)
        {
            timer.Stop();
        }
    }
}
