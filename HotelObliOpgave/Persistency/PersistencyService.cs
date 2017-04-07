using HotelObliOpgave.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace HotelObliOpgave.Persistency
{
    class PersistencyService
    {
        
        const string serverURL = "http://localhost:18543/";

        // Post 
        public static void PostGuestAsync(Guest PostGuest)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverURL);
                client.DefaultRequestHeaders.Clear();
                string urlStringCreate = "api/guests";

                try
                {
                    var createResponse = client.PostAsJsonAsync<Guest>(urlStringCreate, PostGuest).Result;

                    if (createResponse.IsSuccessStatusCode)
                    {
                        MessageDialog guestCreated = new MessageDialog("Guest is Created");
                    }
                    else
                    {
                        MessageDialog guestNotCreated = new MessageDialog("Create guest failed");
                    }
                }
                catch (Exception e)
                {
                    MessageDialog guestNotCreated = new MessageDialog("Create guest falied" + e);
                }
            }           
        }
       
        // Delete
        public static void DeleteGuestAsync(Guest DeleteGuest)
        {
            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri(serverURL);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/guests/" + DeleteGuest.Guest_No.ToString();

                try
                {
                    var Response = client.DeleteAsync(urlString).Result;
                    
                }
                catch (Exception e)
                {
                    MessageDialog guestNotCreated = new MessageDialog("Delete guest failed" + e);
                }
            }
        }

        //Get        
        public static async Task<ObservableCollection<Guest>> GetGuestAsync()
        {
            ObservableCollection<Guest> TempGuestCollection = new ObservableCollection<Guest>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverURL);
                client.DefaultRequestHeaders.Clear();
                string urlstring = "api/guests";
                try
                {
                    HttpResponseMessage response = await client.GetAsync(urlstring);
                    if (response.IsSuccessStatusCode)
                    {
                        TempGuestCollection = response.Content.ReadAsAsync<ObservableCollection<Guest>>().Result;

                    }
                }
                catch (Exception e)
                {
                    MessageDialog exception = new MessageDialog(e.Message);
                    return TempGuestCollection = null;
                }
                return TempGuestCollection;
            }
        }
        //Put - Virker Ikke
        public static void UpdateGuestListJsonAsync(Guest guest)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverURL);
                client.DefaultRequestHeaders.Clear();
                try
                {
                    var response = client.PutAsJsonAsync<Guest>("api/guests/" + guest.Guest_No, guest).Result;
                }
                catch (Exception e)
                {
                    MessageDialog guestNotCreated = new MessageDialog("Guest Blev ikke opdateret" + e);
                }
            }
        }
    }
}
