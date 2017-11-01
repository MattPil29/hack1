using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
//using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	//[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class myMoodPage : ContentPage
	{
		public myMoodPage ()
		{
			InitializeComponent();
		}

        private void submit_Clicked(object sender, EventArgs e)
        {
           // DisplayAlert("Alert", "Mood =" + slide.Value.ToString(), "OK");
            GetDetail(slide.Value);
        }

        public async void GetDetail(double val)
        {

            HttpClient client;

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            var uri = new Uri("http://moodup.azurewebsites.net/api/Login?email=ian.bates@aecom.com");


            //var response = await client.GetAsync(uri);
            //if (response.IsSuccessStatusCode)
            //{
            //    var content = await response.Content.ReadAsStringAsync();
            //    //Items = JsonConvert.DeserializeObject<List<TodoItem>>(content);
            //}


            //var json = JsonConvert.SerializeObject(val);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");

            //var content = new StringContent("", Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            //response = await client.PostAsync(uri, content);
            response = await client.GetAsync(uri);
            string s = "";
            if (response.IsSuccessStatusCode)
            {

                s = await response.Content.ReadAsStringAsync();

               // Debug.WriteLine(s);

                s = s.Replace("\"", "");

                uri = new Uri("http://moodup.azurewebsites.net/api/Mood?user=" + s + "&mood=" + val.ToString());
                response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Sent");
                    await DisplayAlert("Alert", "Sent", "OK");
                }
                else
                {
                    await DisplayAlert("Alert", "Rejected", "OK");
                }
            }
            else
            {
                await DisplayAlert("Alert", "Login failed", "OK");
            }

           
        }
    }
}