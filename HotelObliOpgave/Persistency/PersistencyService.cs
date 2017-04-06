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
        //Mangler ServerURL
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
            /* using (var client = new HttpClient())
             {
                 client.BaseAddress = new Uri(serverURL);
                 client.DefaultRequestHeaders.Clear();
                 client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                 try
                 {
                     var response = client.PostAsJsonAsync<Guest>("api/guests", PostGuest).Result;

                     if (response.IsSuccessStatusCode)
                     {
                         MessageDialog guestAdded = new MessageDialog("Guest has been added");
                         guestAdded.Commands.Add(new UICommand { Label = "Ok" });
                         guestAdded.ShowAsync().AsTask();
                     }
                     else
                     {
                         MessageDialog Error = new MessageDialog("Error");
                         Error.Commands.Add(new UICommand { Label = "Ok" });
                         Error.ShowAsync().AsTask();
                     }
                 }
                 catch (Exception e)
                 {
                     MessageDialog Error = new MessageDialog("Error : " + e);
                     Error.Commands.Add(new UICommand { Label = "Ok" });
                     Error.ShowAsync().AsTask();
                 }

             }*/

        }

        // Delete
        public static void DeleteGuest(Guest GuestToDelete)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverURL);
                string urlString = "api/guests/" + GuestToDelete.Guest_No.ToString();

                try
                {
                    var response = client.DeleteAsync(urlString).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        MessageDialog msg = new MessageDialog("Guest has been Deleted");
                        msg.Commands.Add(new UICommand { Label = "Ok" });
                        msg.ShowAsync().AsTask();

                    }
                }
                catch (Exception e)
                {
                    MessageDialog Error = new MessageDialog("Error : " + e);
                    Error.Commands.Add(new UICommand { Label = "Ok" });
                    Error.ShowAsync().AsTask();
                }
            }
        }

        // Put
        public static void PutGuest(Guest GuestToPut)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string urlString = "api/guests/" + GuestToPut.Guest_No.ToString();

                try
                {
                    var response = client.PutAsJsonAsync<Guest>(urlString, GuestToPut).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        MessageDialog msg = new MessageDialog("Guest has been edited");
                        msg.Commands.Add(new UICommand { Label = "Ok" });
                        msg.ShowAsync().AsTask();

                    }
                }
                catch (Exception e)
                {
                    MessageDialog Error = new MessageDialog("Error : " + e);
                    Error.Commands.Add(new UICommand { Label = "Ok" });
                    Error.ShowAsync().AsTask();
                }
            }

        }


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
    }
}
