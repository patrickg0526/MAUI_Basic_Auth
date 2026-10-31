namespace MauiBasicAuth
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            // Get the username and password from the entry fields
            string username = txtUserId.Text ?? string.Empty;
            string password = txtPassword.Text ?? string.Empty;

            // Create an instance of UserAuthentication
            var userAuth = new DataAccess.UserAuthentication();

            try
            {
                // Authenticate the user through the web service
                bool isAuthenticated = await userAuth.AuthenticateUserAsync(username, password);

                // Display the result
                if (isAuthenticated)
                {
                    await DisplayAlert("Success", "User authenticated successfully!", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "Invalid username or password.", "OK");
                }
            }
            catch (HttpRequestException)
            {
                await DisplayAlert("Error", "Could not reach the authentication service.", "OK");
            }
        }
    }
}
